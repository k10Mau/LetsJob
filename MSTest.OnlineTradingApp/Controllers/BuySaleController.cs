using System.Web.Mvc;

namespace MSTest.OnlineTradingApp.Controllers
{
    [Authorize]
    public class BuySaleController : Controller
    {
        private 
        public BuySaleController()
        {

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