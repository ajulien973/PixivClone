using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PixivClone.Models;
using PixivClone.ServiceLayers;
using System.Diagnostics;

namespace PixivClone.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private IEntityService<User> _entityService;

        public HomeController(IEntityService<User> entityService)
        {
            _entityService = entityService;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterMail(RegisterMailViewModel model)
        {
            if (ModelState.IsValid)
            {
                Debug.Write("success");
                return RedirectToAction("Register", "Account", new { email = model.Email });
            }
            return View("Index");
        }
    }
}