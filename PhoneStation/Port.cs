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
        public event EventHandler<StartingCallEventArgs> PhoneReqest;

        public Port()
        {
            State = PortState.Free;
        }

        public void OnPhoneStartingCall(object sender, StartingCallEventArgs args)
        {
            Console.WriteLine($"Вызов {(sender as Phone).PhoneNumber} на порту");

            if (State == PortState.Free)
            {
                State = PortState.Busy;
                OnCallingFromStationToPort(this, args);
                State = PortState.Free;
            }
        }

        protected virtual void OnCallingFromStationToPort(object sender, StartingCallEventArgs args)
        {
            if (StartCall != null)
            {
                StartCall(sender, args);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public void CallFromStationToPort(StartingCallEventArgs args)
        {
            Console.WriteLine($"Вызов вернулся на порт {args.TargetPhoneNumber}");
            if (State == PortState.Free)
            {
                OnReqest(this, args);
            }
            else
            {
                Console.WriteLine("Port is busy");
            }
        }

        protected void OnReqest(object sender, StartingCallEventArgs args)
        {
            if (PhoneReqest != null)
            {
                PhoneReqest(sender, args);
                State = PortState.Free;
            }
        }
    }
}