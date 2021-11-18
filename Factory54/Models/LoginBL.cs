using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class LoginBL
    {

        Factory54Entities3 db = new Factory54Entities3();

       

        public bool UserConfirmation(string UserName, string Password)
        {
            User User = db.Users.Where(x => x.UserName == UserName && x.Password == Password).First();
            if (User==null)
            {
                return false;
            }
            else
            {
                var time = DateTime.UtcNow.DayOfYear;
                                                                           //is it a New dateTime of Login
                User UserDate = db.Users.Where(x => x.UserName == UserName && x.LoginDate == time).FirstOrDefault();
                if (UserDate !=null)
                {                                                       //if it is the same date,checking for the action count saved in system
                    User UserAction =  db.Users.Where(x => x.UserName == UserName && x.ActionCounter < x.NumOfActions).FirstOrDefault();
                    if (UserAction == null)
                    {
                        return false;
                    }
               
                }

                return true;

            } 
        }


        public User GetUser(string UserName)
        {
            var User = db.Users.Where(x => x.UserName == UserName ).First();
            return User;
        }

     
        public void LogOutStatus(string UserName,int counter)
        {

            User LoggedUser = db.Users.Where( x =>x.UserName == UserName).First();
            LoggedUser.ActionCounter = counter;

            var time = DateTime.UtcNow.DayOfYear;
            LoggedUser.LoginDate = time;


            db.SaveChanges();


        }
    


    }
}