using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public class CallLogger
    {
        private List<StartingCallEventArgs> _loggsIn;
        private List<StartingCallEventArgs> _loggsOut;

        public CallLogger()
        {
            _loggsIn = new List<StartingCallEventArgs>();
            _loggsOut = new List<StartingCallEventArgs>();
        }

        public void AddLoggsIn(object sender, StartingCallEventArgs args)
        {
            _loggsIn.Add(args);
            Console.WriteLine($"Лог входящий записан {(sender as Phone).PhoneNumber}");
        }

        public void AddLoggsOut(object sender, StartingCallEventArgs args)
        {
            _loggsOut.Add(args);
            Console.WriteLine($"Лог исходящий записан {(sender as Phone).PhoneNumber}");
        }
    }
}
