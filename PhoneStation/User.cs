using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public class User
    {
        public Phone Phone { get; set; }

        public Port Port { get; set; }

        public int Tariff { get; set; }

        public float Account { get; set; }

        public User(Port port, Phone phone)
        {
            Port = port;
            Phone = phone;
        }
    }
}
