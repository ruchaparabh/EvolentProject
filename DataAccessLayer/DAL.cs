using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer
{
    public static class  DAL
    {
        static TestProjectEntities DbContext;
        static DAL()
        {
            DbContext = new TestProjectEntities();
        }
        public static List<EmployeeDetail> GetAllProducts()
        {
            return DbContext.EmployeeDetails.ToList();
        }
        public static EmployeeDetail GetEmployee(int employeeId)
        {
            return DbContext.EmployeeDetails.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }
        public static bool InsertEmployee(EmployeeDetail emp)
        {
            bool status;
            try
            {
                DbContext.EmployeeDetails.Add(emp);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateEmployee(EmployeeDetail emp)
        {
            bool status;
            try
            {
                EmployeeDetail empObj = DbContext.EmployeeDetails.Where(e => e.EmployeeId == emp.EmployeeId).FirstOrDefault();
                if (empObj != null)
                {
                    empObj.Firstname = emp.Firstname;
                    empObj.Lastname = emp.Lastname;
                    empObj.Email = emp.Email;
                    empObj.Contact = emp.Contact;
                    empObj.Status = emp.Status;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteEmployee(int id)
        {
            bool status;
            try
            {
                EmployeeDetail empObj = DbContext.EmployeeDetails.Where(e => e.EmployeeId == id).FirstOrDefault();
                if (empObj != null)
                {
                    DbContext.EmployeeDetails.Remove(empObj);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
