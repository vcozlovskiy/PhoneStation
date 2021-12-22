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

            pairs.Add(phone.PhoneNumber, port);
            pairs.Add(phone1.PhoneNumber, port1);

            Station station = new Station(pairs);
            station.Bind(port, phone);
            station.Bind(port1, phone1);

            phone1.Call("123");

            Console.WriteLine();

            phone.Call("321");

        }
    }
}
