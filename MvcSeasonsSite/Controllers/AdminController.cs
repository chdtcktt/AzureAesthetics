using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSeasonsSite.Models;

namespace MvcSeasonsSite.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/


        private SeasonSiteContext Db { get; set; }
        private Login OLogin { get; set; }

        public AdminController()
        {
            Db = new SeasonSiteContext();

        }

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

        public ActionResult Login()
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



    }
}
