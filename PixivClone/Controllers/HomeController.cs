using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PixivClone.Models;

namespace PixivClone.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private IRepository<User> _repo;

        public HomeController(IRepository<User> repo)
        {
            _repo = repo;
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}