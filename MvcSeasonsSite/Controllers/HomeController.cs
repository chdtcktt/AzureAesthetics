using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcSeasonsSite.Models;


namespace MvcSeasonsSite.Controllers
{
    public class HomeController : Controller
    {
      
        //
        // GET: /Home/
     

        private SeasonSiteContext Db { get; set; }

        public HomeController()
        {
            Db = new SeasonSiteContext();

        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var data = new Contact {CreatedDate = DateTime.Now, Email = contact.Email};
                Db.Contacts.Add(data);
                Db.SaveChanges();

                return View("Thanks", contact);
            }
            else
            {
                return View();

            }


        }



        public ActionResult Specials()
        {
            var viewModel = (from s in Db.Specials
                             where s.Id == 1
                             select s).FirstOrDefault();


            return View(viewModel);
        }

        public ActionResult UnderConstruction()
        {
            return View();
        }




    }
}
