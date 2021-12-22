using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public class CallLogger
    {
        private List<CallEventArgs> _logsIn;
        private List<CallEventArgs> _logsOut;

        public CallLogger()
        {
            _logsIn = new List<CallEventArgs>();
            _logsOut = new List<CallEventArgs>();
        }

        public void AddLoggsIn(object sender, CallEventArgs args)
        {
            _logsIn.Add(args);
            Console.WriteLine($"Лог входящий записан {(sender as Phone).PhoneNumber}");
        }

        public void AddLoggsOut(object sender, CallEventArgs args)
        {
            _logsOut.Add(args);
            Console.WriteLine($"Лог исходящий записан {(sender as Phone).PhoneNumber}");
        }

        public void LogsShow()
        {
            foreach (var log in _logsIn)
            {
                Console.WriteLine($"Incoming call to {log.TargetPhoneNumber}," +
                                  $" call time {log.TimeCall}");
            }
            foreach (var log in _logsOut)
            {
                Console.WriteLine($"Outgoing call from {log.SourcePhoneNumber}, " +
                                  $" call time {log.TimeCall}");
            }
        }
    }
}
