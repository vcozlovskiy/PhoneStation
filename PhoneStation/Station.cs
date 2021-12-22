using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Station
    {
        public PortController portController { get; set; }

        public Station(PortController controller)
        {
            portController = controller;
        }

        public void OnPhoneStartingCall(object sender, StartingCallEventArgs args)
        {
            Console.WriteLine($"Вызов на станции: {System.Reflection.MethodInfo.GetCurrentMethod().Name}");

            portController.Ports[args.TargetPhoneNumber].PhoneCallingByStation(args);
        }
    }
}