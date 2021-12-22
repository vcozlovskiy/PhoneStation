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

            Station station = new Station()
            {
                portController = new PortController(new List<Port>() { port, port1})
            };

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
