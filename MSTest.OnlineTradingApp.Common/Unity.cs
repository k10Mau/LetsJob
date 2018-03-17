using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest.OnlineTradingApp.Common
{
    public class Unity
    {
        public enum TransactionType
        {
            Buyer=1,
            Seller=2
        }
        public enum TransactionStatus
        {
            Active=1,
            Completed=2,
            Declined=3
        }
    }
}
