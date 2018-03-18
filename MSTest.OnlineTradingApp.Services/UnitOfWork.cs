using MSTest.OnlineTradingApp.Contract;
using System.Data.Entity;

namespace MSTest.OnlineTradingApp.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
