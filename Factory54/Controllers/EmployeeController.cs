using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory54.Models;

namespace Factory54.Controllers
{
    public class EmployeeController : Controller
    {
            public EmployeeBL EmployeeBL = new EmployeeBL();
            public DepartmentBL DepartmentBL = new DepartmentBL();
           
            

        // GET: Employee
        public ActionResult Index()
        {
        #region Session
            if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
            {

                var counter = (int)Session["counter"];
                counter++;
                Session["counter"] = counter;
         #endregion Session
                var ListOfDepName = EmployeeBL.GetDepartmentName();
                ViewBag.DepNameList = ListOfDepName;

                var ListOfDep = EmployeeBL.GetDepartments();
                ViewBag.DepList = ListOfDep;

                //for the shifts data:
                var ListOfSchedule = EmployeeBL.GetSchedule();
                ViewBag.ScheduleList = ListOfSchedule;

                return View("EmployeeData");
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
        #endregion Session


        }

        public ActionResult EditEmpForm( int id)
        {
        #region Session
            if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
            {

                var counter = (int)Session["counter"];
                counter++;
                Session["counter"] = counter;
                #endregion Session

            var ReqEmployee = EmployeeBL.GetEmployeeByID(id);

            var ListOfDep = DepartmentBL.DepatrmentData();
            ViewBag.DepList = ListOfDep;

            return View("Editform", ReqEmployee); 
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion Session

        }



        public ActionResult EditEmployee(Employee Emp)
        {
         #region NoCounter
            if (Session["Authorized"] != null)
            {
        #endregion NoCounter

                EmployeeBL.EditEmployee(Emp);
            return RedirectToAction("Index");
         #region NoCounter
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
        #endregion NoCounter
        }



        public ActionResult AddEmpForm()
        {
        #region Session
            if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
            {

                var counter = (int)Session["counter"];
                counter++;
                Session["counter"] = counter;
                #endregion Session
                var ListOfDep = DepartmentBL.DepatrmentData();
                ViewBag.DepList = ListOfDep;
                return View("AddForm");
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion Session
        }



        public ActionResult AddingNewEmp(Employee NewEmp)
        {
        #region NoCounter
            if (Session["Authorized"] != null)
            {
                #endregion NoCounter
                EmployeeBL.AddEmployee(NewEmp);
                return RedirectToAction("Index");
        #region NoCounter
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion NoCounter
        }

        public ActionResult DeleteEmployee(int id)
        {
        #region Session
            if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
            {

                var counter = (int)Session["counter"];
                counter++;
                Session["counter"] = counter;
                #endregion Session
                EmployeeBL.DeleteEmployeeById(id);
                return RedirectToAction("DeleteShift", "Shift", new { @id = id });
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion Session

        }





        [HttpPost]
        public ActionResult SearchEmployee(string Phrase)
        {
        #region Session
                if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
                {

                    var counter = (int)Session["counter"];
                    counter++;
                    Session["counter"] = counter;
                    #endregion Session
                List<DepartmentName> ListResult = EmployeeBL.SearchPhrase(Phrase).ToList();
                if(ListResult.Count() ==0)
                {
                    return View("NoResult");
                }
                else
                {
                    ViewBag.SearchResult = ListResult;
                    return View("SearchResult");
                }
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion Session
        }


        public ActionResult AddShiftForm(int id)
        {
        #region Session
            if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
            {

                var counter = (int)Session["counter"];
                counter++;
                Session["counter"] = counter;
                #endregion Session
                Employee Emp = EmployeeBL.GetEmployeeByID(id);
                var FullName = Emp.FirstName + " "+Emp.LastName;
                ViewBag.EmpFullName = FullName;

                var ListOfShifts = EmployeeBL.GetShifts();
                ViewBag.AllShifts = ListOfShifts;

                return View("AddShiftForm",new EmployeeShift { EmployeeID=id});
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion Session
        }

        public ActionResult AddChossenShift(EmployeeShift NewEmpSft)
        {
        #region NoCounter
            if (Session["Authorized"] != null)
            {
                #endregion NoCounter
                EmployeeBL.AddShiftToEmp(NewEmpSft);
                return RedirectToAction("Index");
        #region NoCounter
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion NoCounter

        }


    }

}