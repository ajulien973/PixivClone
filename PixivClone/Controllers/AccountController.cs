using PixivClone.Models;
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
        private IRepository<User> _repo;

        public AccountController(IRepository<User> repo) {
            _repo = repo;
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
            _repo.Add(user);
            return View();
        }
	}
}