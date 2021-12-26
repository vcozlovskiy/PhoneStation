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
        public event EventHandler<CallEventArgs> StartCall;
        public string PhoneNumber { get; private set; }

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void Call(string targetPhoneNumber)
        {
            Console.WriteLine($"Вызов начат {PhoneNumber}");
            OnStartCall(this, new CallEventArgs(PhoneNumber, targetPhoneNumber));
        }

        protected virtual void OnStartCall(object sender, CallEventArgs args)
        {
            if (StartCall != null)
            {
                StartCall(this, args);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void OnRequest(object sender, CallEventArgs args)
        {
            if (sender is Port port) 
            {
                Accept(port, args);
            }
            else
            {

            }
        }

        private void Accept(Port port, CallEventArgs args)
        {
            if(port != null)
            {
                args.IncommingCall = true;
                port.OnPhoneStartingInCall(port,args);
            }
        }
    }
}