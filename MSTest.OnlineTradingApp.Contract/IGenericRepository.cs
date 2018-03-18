using System.Linq;

namespace MSTest.OnlineTradingApp.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity FindByID(object id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
    }
}
