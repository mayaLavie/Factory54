using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class ShiftBL
    {

        Factory54Entities3 db = new Factory54Entities3();

        public List<Shift> GetAllShifts()
        {
            return db.Shifts.ToList();
        }

        public List<WhoWorksWhen> GetWhoWorksWhen()
        {

            var result = from emp in db.Employees
                         join EmpShf in db.EmployeeShifts on emp.ID equals EmpShf.EmployeeID
                         select new WhoWorksWhen
                         {
                             EmpID = emp.ID,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             ShiftID = EmpShf.ShiftID,
                            
                         };

            return result.ToList();
        }

        public void DeleteshiftById(int id)
        {  

           EmployeeShift Result =  db.EmployeeShifts.Where(x => x.EmployeeID == id).FirstOrDefault();
            if (Result == null)
            {
                return ;
            }
            else
            {
                db.EmployeeShifts.Remove(Result);
                db.SaveChanges();
            }
         
        }

        public void AddShift(Shift NewShift)
        {
            db.Shifts.Add(NewShift);
            db.SaveChanges();
        }

        
    }
}