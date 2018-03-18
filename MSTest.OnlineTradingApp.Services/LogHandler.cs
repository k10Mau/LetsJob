using MSTest.OnlineTradingApp.Contract;

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
