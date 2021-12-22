using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStation;

namespace PhoneStation
{
    public class StartingCallEventArgs
    {
        public StartingCallEventArgs(string sourcePhoneNumber, string targetPhoneNumber )
        {
            SourcePhoneNumber = sourcePhoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
        }
        public string SourcePhoneNumber { get; }
        public string TargetPhoneNumber { get; }
    }
}
