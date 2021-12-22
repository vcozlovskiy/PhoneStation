using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    class User
    {
        public Phone Phone { get; set; }

        public float account { get; }

        public void CallLogsShow()
        {
            Phone.CallLogger.LogsShow();
        }
    }
}
