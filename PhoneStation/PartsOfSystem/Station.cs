using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using PhoneStation.Exceptions;
using System.Threading;

namespace PhoneStation
{
    public class Station
    {
        private static Logger loggerStation = LogManager.GetCurrentClassLogger();

        public event EventHandler<CallEventArgs> CallStarted;

        public Dictionary<string, Port> portController { get; }

        public Station(Dictionary<Phone, Port> controller)
        {
            portController = new Dictionary<string, Port>();

            foreach (var pair in controller)
            {
                Bind(pair.Key,pair.Value);
            }
        }

        public void PhoneStartingCall(object sender, CallEventArgs args)
        {
            if (args.IncommingCall == false)
            {
                loggerStation.Info($"Call from {args.SourcePhoneNumber}, to {args.TargetPhoneNumber}");
                Port portToCall = portController.Where((pair) => pair.Key == args.TargetPhoneNumber)
                              .Select((pair) => pair.Value)
                              .First();

                if (portToCall == null)
                {
                    throw new PhoneNotConnectedToStationException();
                }

                portToCall.CallFromStationToPort(args);
            }
            else
            {
                StartRecording(sender, args);
            }
        }

        protected virtual void StartRecording(object sender, CallEventArgs args)
        {
            if (CallStarted != null)
            {
                CallStarted(sender, args);
                Thread.Sleep(5000);
                args.TimeEndCall = DateTime.Now;
            }
            else
            {
                throw new PhoneNotConnectedToStationException();
            }
        }

        public void Bind(Phone phone,Port port)
        {  
            phone.StartCall += port.OnPhoneStartingInCall;
            port.StartCall += PhoneStartingCall;
            port.PhoneReqest += phone.OnRequest;

            portController.Add(phone.PhoneNumber, port);

            loggerStation.Info($"Port {port.PortID} bind to Phone {phone.PhoneNumber}");
        }

        public void UnBind(Phone phone, Port port)
        {
            phone.StartCall -= port.OnPhoneStartingInCall;
            port.StartCall -= PhoneStartingCall;
            port.PhoneReqest -= phone.OnRequest;

            portController.Remove(phone.PhoneNumber);

            loggerStation.Info($"Port {port.PortID} unbind from Phone {phone.PhoneNumber}");
        }
    }
}