using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Station
    {
        public Dictionary<string, Port> portController { get; }

        public Station(Dictionary<string, Port> controller)
        {
            portController = controller;
        }

        public void PhoneStartingCall(object sender, CallEventArgs args)
        {
            Console.WriteLine($"Вызов на станции");

            portController[args.TargetPhoneNumber].CallFromStationToPort(args);
        }

        public void AddNewPair(string number, Port port)
        {
            portController.Add(number, port);
        }

        public void Bind(Port port, Phone phone)
        {
            phone.StartCall += port.OnPhoneStartingCall;
            port.StartCall += PhoneStartingCall;
            port.PhoneReqest += phone.OnRequest;
        }
    }
}