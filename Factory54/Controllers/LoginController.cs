using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory54.Models;

namespace Factory54.Controllers
{
    public class LoginController : Controller
    {
        public  LoginBL LoginBL = new LoginBL();
       
        public ActionResult Index()
        {
            return View("Login");
        }

       public ActionResult LoginConfirmation(string UserName ,string Password)
        {
            var DoesExsist = LoginBL.UserConfirmation( UserName,  Password);
            if (DoesExsist == false)
            {
                return RedirectToAction("Index");
            }
            else 
            {   //Hey,Yaniv :)
                //this is for checking about the date (of login) saved in the system,is it today or not...
                //according to answer the counter will be 0 or the counter from last logout
                User LoggedIn = LoginBL.GetUser(UserName);
                if(LoggedIn.LoginDate !=  DateTime.UtcNow.DayOfYear)
                {
                    Session["counter"] = 0;
                }else
                {
                    Session["counter"] = LoggedIn.ActionCounter;
                }
                Session["Authorized"] = true;
                Session["FullName"] = LoggedIn.FullName;
                Session["UserName"] = LoggedIn.UserName;
                Session["NumOfActionAllowd"] = LoggedIn.NumOfActions;
                return View("HomePage");
                
            }
        }


        public ActionResult LogOut()
        {   //saving Logout Status in DB
            var UserName = (string)Session["UserName"];
            var FinalCounter = (int)Session["counter"];
            LoginBL.LogOutStatus(UserName, FinalCounter);
            return RedirectToAction("Index");
        }

        public ActionResult Homepage()
        {
            return View("HomePage");
        }




    }
}