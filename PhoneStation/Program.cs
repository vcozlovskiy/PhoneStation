using System;
using System.Collections.Generic;
using NLog;

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

            User user = new User(port, phone);
            User user1 = new User(port1, phone1);
            user.Account = 100;
            user1.Account = 100;

            DateTime dateTimest = DateTime.Now;

            List<User> users = new List<User>();
            users.Add(user);
            users.Add(user1);

            Dictionary<Phone, Port> pairs = new Dictionary<Phone, Port>();

            pairs.Add(phone, port);
            pairs.Add(phone1, port1);

            Station station = new Station(pairs);
            BillingSystem billingSystem = new BillingSystem(station);
            billingSystem.RegisteredUsers = users;

            station.CallStarted += billingSystem.OnCallRecord;

            user1.Phone = phone;
            user.Phone = phone1;

            phone1.Call("123"); 

            DateTime dateTimeend = DateTime.Now;
        }
    }
}
