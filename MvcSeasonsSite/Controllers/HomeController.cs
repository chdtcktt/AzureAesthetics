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
        private Login OLogin { get; set; }

        public HomeController()
        {
            Db = new SeasonSiteContext();
           
        }

        #region Index


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

        #region admin
        
    
        public ActionResult Admin()
        {
            if (Session["isUserAuthenticated"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            
            if ((bool)Session["isUserAuthenticated"]) // return the admin view if authenticated
                return View();
            else
            {
               

                return RedirectToAction("AdminLogin"); // redirect to login page if not authenticate
            }
           

        }


        [ValidateInput(false)]
        public ActionResult AdminSpecial()
        {
            var viewModel = (from s in Db.Specials
                             where s.Id == 1
                             select s).FirstOrDefault();

            return View(viewModel);
        }
        
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult AdminSpecial(Special input)
        {
            var viewModel = (from s in Db.Specials
                             where s.Id == input.Id
                             select s).FirstOrDefault();
            Db.Entry(viewModel).CurrentValues.SetValues(input);
            Db.SaveChanges();

            return View();
            

        }

       
        public ActionResult AdminEmailAddress()
        {
            var viewModel = from s in Db.Contacts
                           
                            select s;
            return PartialView(viewModel);
        }

        public ActionResult AdminEmailAddressDelete(int id)
        {
            var viewModelDelete = (from s in Db.Contacts
                                 where s.Id == id
                                 select s).FirstOrDefault();




            Db.Contacts.Remove(viewModelDelete);
            Db.SaveChanges();

            return RedirectToAction("Admin");
           
        }

        public ActionResult AdminEmailVomit()
        {
            List<string> emailAddresses = (from s in Db.Contacts
                                 select s.Email).ToList();

            return View(emailAddresses);

        }

      
        #endregion

        #region Login

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult AdminLogin(Login login)
        {
            // if the session variable is null or set to false, this user is not authenticated
            if (Session["isUserAuthenticated"] == null || (bool)Session["isUserAuthenticated"] == false)
            {
                // if the user and pass are a match, let them in!
                if (login.User == "season" && login.Pass == "letmein")
                {
                    Session["isUserAuthenticated"] = true;
                    return RedirectToAction("Admin");
                    

                }
            }

            //send error is user is not authenticated
            ModelState.AddModelError("LoginError", "There is a problem with the username or password.....are you a terrorist?!!!"); 
            
            // if not a match, go back to teh login view
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
