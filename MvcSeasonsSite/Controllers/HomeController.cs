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
     

        #region Index
        private SeasonSiteContext Db { get; set; }
        private Login OLogin { get; set; }

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

        #endregion

        #region Skin and Body
        public ActionResult Facials() 
        {
            return View();
        }
        public ActionResult Makeup()
        {
            return View();
        }

        public ActionResult Body()
        {
            return View();
        }

        public ActionResult BodyBronzing()
        {
            return View();
        }
        public ActionResult BioslimmingWrap()
        {
            return View();
        }
        #endregion

        #region Wax and Tint
        public ActionResult WaxServices()
        {
            return View();
        }
        
        public ActionResult TintServices()
        {
            return View();
        }
        #endregion

        #region NonInvasive LipoLaser
        public ActionResult LipoLaser()
        {
            return View();

        }
        public ActionResult LipoLaserBNA()
        {
            return View();
        }

        #endregion

        #region Infared and Detox

        public  ActionResult InfaredSlimming()
        {
            return View();
        }

        public ActionResult InfaredDetox()
        {
            return View();
        }

        public ActionResult WBV()
        {
            return View();
        }

        public ActionResult DetoxFootBath()
        {
            return View();
        }

        #endregion

        #region Products

        public ActionResult ThreeOTwoSkinCare()
        {
            return View();
        }

        public ActionResult JIMC()
        {
            return View();
        }

        public ActionResult Bioslimming()
        {
            return View();

        }

        public ActionResult OtherProducts()
        {
            return View();
        }

       

        #endregion


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
