using MSTest.OnlineTradingApp.DAL;
using MSTest.OnlineTrandingApp.JobSchedular;
using System.Web.Mvc;

namespace MSTest.OnlineTradingApp.Controllers
{
    [Authorize]
    public class BuySaleController : Controller
    {
        private readonly JobProcessor _jobProcessor;
        public BuySaleController()
        {
            _jobProcessor = new JobProcessor(new MSTestTradingDBEntities());
        }
        // GET: BuySale
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ChildActionOnly]
        public void ProcessTodaysTransaction()
        {
        }
    }
}