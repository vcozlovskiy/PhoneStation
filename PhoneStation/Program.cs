using System;
using System.Collections.Generic;

namespace PhoneStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone("123");
            Port port = new Port();

            Phone phone1 = new Phone("321");
            Port port1 = new Port();

            Dictionary<string, Port> pairs = new Dictionary<string, Port>();

            pairs.Add("123", port);
            pairs.Add("321", port1);

            Station station = new Station(new PortController(pairs));

            phone1.StartCall += port.OnPhoneStartingCall;
            port1.StartCall += station.OnPhoneStartingCall;

            phone.StartCall += port.OnPhoneStartingCall;
            port.StartCall += station.OnPhoneStartingCall;

            port.PhoneReqest += phone.OnRequest;
            port1.PhoneReqest += phone1.OnRequest;

            phone.Call("321");
        }
    }
}
