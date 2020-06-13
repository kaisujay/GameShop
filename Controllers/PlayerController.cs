using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class PlayerController : Controller
    {
        // POST: Player
        public ActionResult Create()
        {
            return View();
        }

        // GET: Player
        public ActionResult Players()
        {
            return View();
        }
    }
}