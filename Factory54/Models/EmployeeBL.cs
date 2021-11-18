using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Factory54.Models
{
    public class EmployeeBL
    {
        
        Factory54Entities3 db = new Factory54Entities3();
    
        public List<Employee> GetEmployeeData()
        {
            return db.Employees.ToList();
        }


        public List<DepartmentName> GetDepartmentName()
        {
           
            var result = from emp in db.Employees
                         join dep in db.Departments on emp.DepartmentID equals dep.ID
                         select new DepartmentName
                         {
                             EmployeeID = emp.ID,
                             FName = emp.FirstName,
                             LName = emp.LastName,
                             DepartmentID = dep.ID,
                             NameOfDepartment = dep.Name,
                             StartYear = emp.StartWorkYear
                         };

            return result.ToList();
        }


        public List<ShiftSchedule> GetSchedule()
        {
            var result = from shift in db.Shifts
                         join schd in db.EmployeeShifts on shift.ID equals schd.ShiftID
                         select new ShiftSchedule
                         {
                             ShiftID = shift.ID,
                             EmpID = schd.EmployeeID,
                             StartTime = shift.StartTime,
                             EndTime = shift.EndTime,
                             Date = shift.Date

                         };
            return result.ToList();

        }

        public List<Department>GetDepartments()
        {
           return db.Departments.ToList();
        }


        public Employee GetEmployeeByID(int id)
        {
            var Emp = db.Employees.Where(x => x.ID == id).First();

            return Emp;
        }

        public void EditEmployee(Employee Emp)
        {
            Employee OriginalEmp = db.Employees.Where(x => x.ID == Emp.ID).First();
            OriginalEmp.FirstName = Emp.FirstName;
            OriginalEmp.LastName = Emp.LastName;
            OriginalEmp.DepartmentID = Emp.DepartmentID;
            OriginalEmp.StartWorkYear = Emp.StartWorkYear;

            db.SaveChanges();
        }

        public void AddEmployee(Employee NewEmp)
        {
            db.Employees.Add(NewEmp);
            db.SaveChanges();
        }

        public void DeleteEmployeeById(int id)
        {
            var Emp = db.Employees.Where(x => x.ID == id).First();
            db.Employees.Remove(Emp);
            db.SaveChanges();
        }

        public  List < DepartmentName > SearchPhrase(string Phrase)
        {
           List<DepartmentName> DepandName  = GetDepartmentName();

           List <DepartmentName> Result1 = DepandName.Where(x => x.FName.ToLower().Contains(Phrase) ||
                                                                 x.LName.ToLower().Contains(Phrase) || 
                                                                 x.NameOfDepartment.ToLower().Contains(Phrase)).ToList();
            return Result1;
           
        }


        public List<Shift> GetShifts()
        {
            return db.Shifts.ToList();
        }
        
           public void AddShiftToEmp(EmployeeShift NewEmpSft)
           {
              
               db.EmployeeShifts.Add(NewEmpSft);
               db.SaveChanges();
           }

           

    }
}