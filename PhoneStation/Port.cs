using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Port
    {
        public PortState State { get; private set; }
        public event EventHandler<StartingCallEventArgs> StartCall;

        public Port()
        {
            State = PortState.Free;
        }

        public void OnPhoneStartingCall(object sender, StartingCallEventArgs args)
        {
            Console.WriteLine($"Вызов на порту {args.SourcePhoneNumber}: {System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            if (State == PortState.Free)
            {
                State = PortState.Busy;
                OnStartingCall(this, args);
            }
        }

        protected virtual void OnStartingCall(object sender, StartingCallEventArgs args)
        {
            StartCall(sender, args);
        }
        public void PhoneCallingByStation(StartingCallEventArgs args)
        {
            Console.WriteLine($"Вызов вернулся на порт {args.TargetPhoneNumber}: {System.Reflection.MethodInfo.GetCurrentMethod().Name}");
            if (State == PortState.Free)
            {
                State = PortState.Busy;
                OnReqest(this, args);
            }
        }

        public event EventHandler<StartingCallEventArgs> PhoneReqest;

        protected void OnReqest(object sender, StartingCallEventArgs args)
        {

            PhoneReqest(sender, args);
        }
    }
}