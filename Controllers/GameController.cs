using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class GameController : Controller
    {
        // POST: Game
        public ActionResult Create()
        {
            return View();
        }

        // GET: Game
        public ActionResult Games()
        {
            return View();
        }
    }
}