using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory54.Models
{
    public class DepartmentBL
    {
        
        Factory54Entities3 db = new Factory54Entities3();
        public List<Manager> GetEmployeeName()
        {  //New object for getting the manager name presented
            
            var   result = from emp in db.Employees
                         join dep in db.Departments on emp.ID equals dep.Manager
                         select  new  Manager
                         {   
                             ID = emp.ID,
                             FullName = emp.FirstName + " " + emp.LastName,
                             DepartmentID = dep.ID,
                             DepartmentName = dep.Name
                         };

            return result.ToList();
        }

        public List<Department> DepatrmentData()
        {
            return db.Departments.ToList();
        }


        public void DeleteDepartmentByID(int id)
        {
            var Dep = db.Departments.Where(x => x.ID == id).First();
            db.Departments.Remove(Dep);
            db.SaveChanges();
            
        }


       public List<Employee> GetAllEmployee()
        {
            return  db.Employees.ToList();
             
        }

        public void EditDepartmentTestBL( Department Dep)
        {
            Department OriginalDep = db.Departments.Where(x => x.ID == Dep.ID).First();
            OriginalDep.Name = Dep.Name;
            OriginalDep.Manager = Dep.Manager;

            db.SaveChanges();
        }


        public Department GetDepartmentByID(int id)
        {
           var Dep = db.Departments.Where(x => x.ID == id).First();

            return Dep;
        }

       
        public void AddDepartment(Department NewDep)
        {
            db.Departments.Add(NewDep);

            db.SaveChanges();
        }
    }
}