using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory54.Models;

namespace Factory54.Controllers
{
    public class ShiftController : Controller
    {
        public ShiftBL ShiftBL = new ShiftBL();
        public EmployeeBL EmployeeBL = new EmployeeBL();
      
        
        public ActionResult Index()
        {
            List<Shift> Shifts = ShiftBL.GetAllShifts();
            ViewBag.Shifts = Shifts;

             List <WhoWorksWhen> WorkingEmp =   ShiftBL.GetWhoWorksWhen();
            ViewBag.WorkingEmp = WorkingEmp;

            return View("ShiftData");
        }




         public  ActionResult  DeleteShift(int id)
        {
            ShiftBL.DeleteshiftById(id);
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult AddShiftForm()
        {
           return View("AddForm");
        }

        public ActionResult AddingNewShift(Shift NewShift)
        {
            ShiftBL.AddShift(NewShift);
            return RedirectToAction("Index");
        }

        public ActionResult AddShiftById(int id)
        {
            List<WhoWorksWhen> WorkingEmp = ShiftBL.GetWhoWorksWhen();
            
            
            
            ViewBag.WorkingEmp = WorkingEmp;
            return RedirectToAction("Index");
        }


    }
}