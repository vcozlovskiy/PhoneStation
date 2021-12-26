using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public class PortIsBusy : Exception
    {
        public PortIsBusy() : base()
        {

        }
        public PortIsBusy(string messege, Exception inner) : base(messege, inner)
        {

        }
    }
}
