using PixivClone.Models;
using PixivClone.ServiceLayers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PixivClone.Controllers 
{
    public class AccountController : Controller, IAccountController
    {
        private IEntityService<User> _entityService;

        public AccountController(IEntityService<User> entityService)
        {
            _entityService = entityService;
        }

        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _entityService.Add(user);
            return View();
        }
	}
}