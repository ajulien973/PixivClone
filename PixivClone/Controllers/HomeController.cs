using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PixivClone.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}