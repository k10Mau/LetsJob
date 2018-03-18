using MSTest.OnlineTradingApp.Contract;
using MSTest.OnlineTradingApp.DAL;
using MSTest.OnlineTradingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MSTest.OnlineTradingApp.Common.Unity;

namespace MSTest.OnlineTrandingApp.JobSchedular
{
    public class JobProcessor : IJobProcessor
    {
        private MSTestTradingDBEntities mSTestTradingDBEntities;

        private IGenericRepository<TradeTransaction> _genericTradeTransactionRepository;

        private readonly IUnitOfWork _unitOfWork;
        private MSTestTradingDBEntities _dbContext;

        public JobProcessor(MSTestTradingDBEntities mSTestTradingDBEntities)
        {
            this.mSTestTradingDBEntities = mSTestTradingDBEntities;
            this._genericTradeTransactionRepository = new GenericRepository<TradeTransaction>(mSTestTradingDBEntities);
            this._unitOfWork = new UnitOfWork(mSTestTradingDBEntities);
        }

        void IJobProcessor.ExecuteJob(DateTime today)
        {
            var todaysBuyers = _genericTradeTransactionRepository.SearchFor(e => e.TransactionType == Convert.ToInt32(TransactionType.Buyer)
                                                               && e.Status == Convert.ToInt32(TransactionStatus.Active) && e.CreateDate <= today);

            Parallel.ForEach(todaysBuyers, buyer =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var sellerList = GetBuyersForThisBuyer(buyer, _genericTradeTransactionRepository);
                         
                        _unitOfWork.SaveChanges();
                        transaction.Commit(); 
                    } 
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        //log status 
                    }
                } 
            });
        }

     

        private List<SellerInfo> GetBuyersForThisBuyer(TradeTransaction buyer, IGenericRepository<TradeTransaction> _genericTradeTransactionRepository)
        {
            var sellerList = new List<SellerInfo>();
            try
            {
                var sellers = _genericTradeTransactionRepository.SearchFor(e => e.TransactionType == Convert.ToInt32(TransactionType.Seller)
                                                               && e.Status == Convert.ToInt32(TransactionStatus.Active)
                                                               && e.StockId == buyer.StockId).ToList();
                var buyerCount = buyer.StockCount;
                foreach (TradeTransaction seller in sellers)
                {
                    if (buyerCount != 0 || buyerCount > 0)
                    {
                        sellerList.Add(new SellerInfo
                        {
                            StockToConsider = buyerCount - seller.StockCount >= 0 ? seller.StockCount : buyerCount,
                            TradeTransaction = seller
                        });
                        buyerCount = buyerCount - seller.StockCount;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return sellerList;
        }
    }
    class SellerInfo
    {
        public TradeTransaction TradeTransaction { get; set; }
        public int StockToConsider { get; set; }
    }
}
