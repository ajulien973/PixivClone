using PixivClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PixivClone.Controllers
{
    public interface IAccountController
    {
        ActionResult Index();
        ActionResult Create();
    }
}
