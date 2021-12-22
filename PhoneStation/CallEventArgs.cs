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
        public DateTime TimeCall { get; }

        public CallEventArgs(string sourcePhoneNumber, string targetPhoneNumber )
        {
            SourcePhoneNumber = sourcePhoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
            TimeCall = DateTime.Now;
        }
    }
}
