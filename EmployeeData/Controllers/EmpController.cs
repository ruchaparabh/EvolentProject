using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using EmployeeData.Repository;
using Newtonsoft.Json;
using System.Web.Http;
using DataAccessLayer;
using System.Web.Http.Cors;

namespace EmployeeData.Controllers
{
    public class EmpController : ApiController
    {
        // GET: Employees  
        [HttpGet]
        public JsonResult<List<Models.EmpData>> GetAllEmployees()
        {
            EntityMapper<DataAccessLayer.EmployeeDetail, Models.EmpData> mapObj = new EntityMapper<DataAccessLayer.EmployeeDetail, Models.EmpData>();
            List<DataAccessLayer.EmployeeDetail> empList = DAL.GetAllProducts();
            List<Models.EmpData> emps = new List<Models.EmpData>();
            foreach (var item in empList)
            {
                emps.Add(mapObj.Translate(item));
            }
            return Json<List<Models.EmpData>>(emps);
        }
        [HttpGet]
        public JsonResult<Models.EmpData> GetEmployee(int id)
        {
            EntityMapper<DataAccessLayer.EmployeeDetail, Models.EmpData> mapObj = new EntityMapper<DataAccessLayer.EmployeeDetail, Models.EmpData>();
            DataAccessLayer.EmployeeDetail dalEmp = DAL.GetEmployee(id);
            Models.EmpData empDt = new Models.EmpData();
            empDt = mapObj.Translate(dalEmp);
            return Json<Models.EmpData>(empDt);
        }
        [HttpPut]
        public bool PostEmployee(Models.EmpData empDt)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.EmpData, DataAccessLayer.EmployeeDetail> mapObj = new EntityMapper<Models.EmpData, DataAccessLayer.EmployeeDetail>();
                DataAccessLayer.EmployeeDetail empObj = new DataAccessLayer.EmployeeDetail();
                empObj = mapObj.Translate(empDt);
                status = DAL.InsertEmployee(empObj);
            }
            return status;

        }
        [HttpPut]
        public bool UpdateEmployee(Models.EmpData empdt)
        {
            EntityMapper<Models.EmpData, DataAccessLayer.EmployeeDetail> mapObj = new EntityMapper<Models.EmpData, DataAccessLayer.EmployeeDetail>();
            DataAccessLayer.EmployeeDetail empObj = new DataAccessLayer.EmployeeDetail();
            empObj = mapObj.Translate(empdt);
            var status = DAL.UpdateEmployee(empObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteEmployee(int id)
        {
            var status = DAL.DeleteEmployee(id);
            return status;
        }
}
}