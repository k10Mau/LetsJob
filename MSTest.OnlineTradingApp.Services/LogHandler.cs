using MSTest.OnlineTradingApp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest.OnlineTradingApp.Services
{
    public class LogHandler : ILoghandler
    {
        public void LogError(string errorMessage)
        {
           // log exception in DB
        }
    }
}
