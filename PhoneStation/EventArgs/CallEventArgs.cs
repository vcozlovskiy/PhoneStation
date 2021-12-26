using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStation;

namespace PhoneStation
{
    public class CallEventArgs
    {
        public string SourcePhoneNumber { get; }
        public string TargetPhoneNumber { get; }
        public bool IncommingCall { get; set; }
        public DateTime TimeCall { get; }

        public DateTime TimeEndCall { get; set; }

        public CallEventArgs(string sourcePhoneNumber, string targetPhoneNumber )
        {
            SourcePhoneNumber = sourcePhoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            IncommingCall = false;
            TimeCall = DateTime.Now;
        }
    }
}
