using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PhoneStation;

namespace PhoneStation
{
    public class Phone
    {
        public event EventHandler<StartingCallEventArgs> StartCall;

        public CallLogger CallLogger { get; }

        public string PhoneNumber { get; private set; }

        public Phone(string phoneNumber)
        {
            CallLogger = new CallLogger();
            PhoneNumber = phoneNumber;
        }

        public void Call(string targetPhoneNumber)
        {
            if (targetPhoneNumber == PhoneNumber)
            {
                throw new Exception();
            }
            Console.WriteLine($"Вызов начат {PhoneNumber}");
            OnStartCall(this, new StartingCallEventArgs(PhoneNumber, targetPhoneNumber));
        }

        protected virtual void OnStartCall(object sender, StartingCallEventArgs args)
        {
            if (StartCall != null)
            {
                StartCall(this, args);
                CallLogger.AddLoggsOut(this, args);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void OnRequest(object sender, StartingCallEventArgs args)
        {
            Console.WriteLine($"Вызов вернулся на другой телефон {PhoneNumber}");
            CallLogger.AddLoggsIn(this, args);
            Accept();
        }

        public void Accept()
        {
            Console.WriteLine("Вызов принят");
            Console.WriteLine("Вызов завершён");
        }
    }
}