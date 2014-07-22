using PixivClone.Models;
using PixivClone.ServiceLayers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public ActionResult Register(string email)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { Username = model.Username, Email = model.Email, Password = model.Password };
                _entityService.Add(user);
            }
            return View(model);
        }
	}
}