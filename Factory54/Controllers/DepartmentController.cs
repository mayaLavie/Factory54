using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory54.Models;

namespace Factory54.Controllers
{

    public class DepartmentController : Controller
    {
       
         public DepartmentBL DepartmentBL = new DepartmentBL();

        public ActionResult Index()
        {
        #region Session
            if (Session["Authorized"] != null  && (int)Session["counter"]< (int)Session["NumOfActionAllowd"])
            {   
                    var counter = (int)Session["counter"];
                    counter++;
                    Session["counter"] = counter;

        #endregion Session
                var AllDepartments = DepartmentBL.DepatrmentData();
                ViewBag.DepartmentData = AllDepartments;

                var NewTbl = DepartmentBL.GetEmployeeName();
                ViewBag.ManagerTable = NewTbl;

                var ListOfEmp = DepartmentBL.GetAllEmployee();
                ViewBag.EmployeeList = ListOfEmp;

                return View("DepartmentData");
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
        #endregion Session
        }



        public ActionResult EditDepForm(int id)
        {
        #region Session
            if (Session["Authorized"] != null  && (int)Session["counter"]< (int)Session["NumOfActionAllowd"])
            {   

                    var counter = (int)Session["counter"];
                    counter++;
                    Session["counter"] = counter;
        #endregion Session
            var ReqDepartment = DepartmentBL.GetDepartmentByID(id);

            List<Employee> ListOfEmp = DepartmentBL.GetAllEmployee();
            ViewBag.EmployeeList = ListOfEmp;
            return View("Editform", ReqDepartment);
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
        #endregion Session

        }

        public ActionResult EditDepartment(Department Dep)
        {
        #region NoCounter
            if (Session["Authorized"] != null)
            {   
        #endregion NoCounter
            DepartmentBL.EditDepartmentTestBL(Dep);
            return RedirectToAction("Index");
        #region NoCounter
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
            #endregion NoCounter
        }


        public ActionResult AddForm()
        {
        #region Session
                 if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
                 {
                var counter = (int)Session["counter"];
                counter++;
                Session["counter"] = counter;
        #endregion Session
            var ListOfEmp = DepartmentBL.GetAllEmployee();
            ViewBag.EmployeeList = ListOfEmp;
            return View("AddForm");
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
        #endregion Session

        }

        public ActionResult AddingNewDep(Department NewDep)
        {
        #region NoCounter
            if (Session["Authorized"] != null )
            {
        #endregion NoCounter
            DepartmentBL.AddDepartment(NewDep);
            return RedirectToAction("Index");
        #region NoCounter
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
        #endregion NoCounter

        }

        public ActionResult DeleteDepartment(int id)
        {
        #region Session
            if (Session["Authorized"] != null && (int)Session["counter"] < (int)Session["NumOfActionAllowd"])
            {

                var counter = (int)Session["counter"];
                counter++;
                Session["counter"] = counter;
        #endregion Session
            DepartmentBL.DeleteDepartmentByID(id);
            return RedirectToAction("Index");
        #region Session
            }
            else
            {
                return RedirectToAction("LogOut", "Login");
            }
        #endregion Session

        }



    }
}