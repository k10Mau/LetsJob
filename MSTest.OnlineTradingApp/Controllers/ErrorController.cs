using MSTest.OnlineTradingApp.Contract;
using MSTest.OnlineTradingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSTest.OnlineTradingApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error

        private ILoghandler _log;
        public ErrorController()
        {
            _log = new LogHandler();
        }
        public ActionResult Index()
        {
            _log.LogError("some error");
            return View();
        }
    }
}