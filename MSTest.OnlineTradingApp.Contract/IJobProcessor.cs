using System;

namespace MSTest.OnlineTradingApp.Contract
{
    public interface IJobProcessor
    {
        void ExecuteJob(DateTime today);
    }
}
