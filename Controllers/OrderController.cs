using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order/AllOrders
        public ActionResult AllOrders()
        {
            return View();
        }

        // POST: Order/CreateOrder
        public ActionResult CreateOrder()
        {
            return View();
        }
    }
}