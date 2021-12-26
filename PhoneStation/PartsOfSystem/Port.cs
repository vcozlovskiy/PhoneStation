using System;
using System.Collections.Generic;
using System.Linq;
using PhoneStation.Exceptions;
using System.Text;

namespace PhoneStation
{
    public class Port
    {
        public PortState State { get; private set; }
        public event EventHandler<CallEventArgs> StartCall;
        public event EventHandler<CallEventArgs> PhoneReqest;

        public int PortID { get; }
        private static int portsCount;

        public Port()
        {
            State = PortState.Free;

            PortID = ++portsCount;
        }

        public void OnPhoneStartingInCall(object sender, CallEventArgs args)
        {
            if (State == PortState.Free)
            {
                State = PortState.Busy;
                OnCallingFromStationToPort(this, args);
                State = PortState.Free;
            }
            else
            {
                throw new PortIsBusy();
            }
        }

        protected virtual void OnCallingFromStationToPort(object sender, CallEventArgs args)
        {
            if (StartCall != null)
            {
                StartCall(sender, args);
            }
            else
            {
                throw new PhoneNotConnectedToStationException();
            }
        }
        public void CallFromStationToPort(CallEventArgs args)
        {
            if (State == PortState.Free)
            {
                OnReqest(this, args);
            }
            else
            {
                throw new PortIsBusy();
            }
        }

        protected void OnReqest(object sender, CallEventArgs args)
        {
            if (PhoneReqest != null)
            {
                PhoneReqest(sender, args);
                State = PortState.Free;
            }
            else
            {
                throw new PortIsBusy();
            }
        }
    }
}