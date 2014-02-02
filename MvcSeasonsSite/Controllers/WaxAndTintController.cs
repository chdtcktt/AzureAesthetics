using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSeasonsSite.Controllers
{
    public class WaxAndTintController : Controller
    {
        //
        // GET: /WaxAndTint/

        public ActionResult WaxServices()
        {
            return View();
        }

        public ActionResult TintServices()
        {
            return View();
        }

    }
}
