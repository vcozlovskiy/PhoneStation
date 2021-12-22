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

        public string PhoneNumber { get; private set; }

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void Call(string targetPhoneNumber)
        {
            Console.WriteLine($"Вызов начат {PhoneNumber}: {System.Reflection.MethodInfo.GetCurrentMethod().Name}");
            OnStartCall(this, new StartingCallEventArgs(PhoneNumber, targetPhoneNumber));
        }

        protected virtual void OnStartCall(object sender, StartingCallEventArgs args)
        {
            StartCall(sender, args);
        }

        public void OnRequest(object sender, StartingCallEventArgs args)
        {
            Console.WriteLine($"Вызов вернулся на другой телефон: {args.TargetPhoneNumber}: {System.Reflection.MethodInfo.GetCurrentMethod().Name}");
        }

        public void Accept()
        {

        }
    }
}