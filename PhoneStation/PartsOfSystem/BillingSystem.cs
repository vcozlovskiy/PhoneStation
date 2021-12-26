using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public class BillingSystem
    {
        public Station Station { get; set; }
        public List<User> RegisteredUsers { get; set; }

        private List<CallEventArgs> callList;

        public BillingSystem(Station station)
        {
            Station = station;
            RegisteredUsers = new List<User>();
            callList = new List<CallEventArgs>();
        }

        public void OnCallRecord(object sender, CallEventArgs args)
        {
            callList.Add(args);

            User user = RegisteredUsers.Where((user) => user.Phone.PhoneNumber == args.SourcePhoneNumber)
                .First();
        }

        public float GetPeriodCost(User user, DateTime startPeriod,
            DateTime endPeriod)
        {
            float cost = 0;
            var callsArgs = callList.Where((args) => args.SourcePhoneNumber == user.Phone.PhoneNumber)
                              .Where((args) => args.TimeCall > startPeriod && args.TimeCall < endPeriod);

            foreach (var arg in callsArgs)
            {
                cost += (float)(arg.TimeEndCall - arg.TimeCall).TotalSeconds * user.Tariff;
            }

            return cost;
        }
    }
}
