using MSTest.OnlineTradingApp.Contract;
using MSTest.OnlineTradingApp.DAL;
using MSTest.OnlineTradingApp.Models;
using MSTest.OnlineTradingApp.Services;
using MSTest.OnlineTrandingApp.JobSchedular;
using System;
using System.Web.Mvc;

namespace MSTest.OnlineTradingApp.Controllers
{
    [Authorize]
    public class BuySaleController : Controller
    {
        private readonly JobProcessor _jobProcessor;

        private IGenericRepository<TradeTransaction> _genericTradeTransactionRepository;
        public BuySaleController()
        {
            this._jobProcessor = new JobProcessor(new MSTestTradingDBEntities());
            this._genericTradeTransactionRepository = new GenericRepository<TradeTransaction>(new MSTestTradingDBEntities());
        }
        // GET: BuySale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buy(StockViewModel model)
        {
            return View();
        }

        public ActionResult Sell()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Sell(StockViewModel model)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [ChildActionOnly]
        public void ProcessTodaysTransaction()
        {
            try
            {
                _jobProcessor.ExecuteJob(DateTime.Now);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}