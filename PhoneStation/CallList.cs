using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public class CallList
    {
        private List<CallEventArgs> _logsIn;
        private List<CallEventArgs> _logsOut;

        public CallList()
        {
            _logsIn = new List<CallEventArgs>();
            _logsOut = new List<CallEventArgs>();
        }

        public void AddCallIn(object sender, CallEventArgs args)
        {
            _logsIn.Add(args);
        }

        public void AddCallOut(object sender, CallEventArgs args)
        {
            _logsOut.Add(args);
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
