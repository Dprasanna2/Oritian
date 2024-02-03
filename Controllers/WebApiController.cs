using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OritainAPI.Data;
using OritainAPI.ViewModels;
using OritainAPI.Interfaces;

namespace OritainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        //private readonly DataContext _context;

        //public WebApiController(DataContext context)
        //{
        //    _context = context;
        //}

        private readonly IEmployeeData _employeeDetailsService;

        public WebApiController(IEmployeeData employeeDetailsService)
        {
            this._employeeDetailsService = employeeDetailsService;
        }

        [HttpGet]
        [Route("GetAllEmployeePersonalData")]
        public List<EmployeeData> GetAllEmployeePersonalData()
        {
            return this._employeeDetailsService.GetAllEmployeePersonalData();
        }

        [HttpGet]
        [Route("GetEmployeeDetails")]
        public List<EmployeeData> GetEmployeeDetails()
        {
            return this._employeeDetailsService.GetEmployeeDetails();

        }

        [HttpPost]
        [Route("AddEmployeeData")]
        public int AddEmployeeData(EmployeeData employeeData)
        {
            return this._employeeDetailsService.AddEmployeeData(employeeData);
        }

        [HttpGet]
        [Route("GetEmployeeDetailsByID")]
        public EmployeeData GetEmployeeDetailsByID(int id)
        {
            return this._employeeDetailsService.GetEmployeeDetailsByID(id);
        }

        [HttpGet]
        [Route("CheckEmailIdExists")]
        public bool CheckEmailIdExists(string emailId)
        {
            return this._employeeDetailsService.CheckEmailIdExists(emailId);
        }

        [HttpDelete]
        [Route("DeleteEmployeeTask")]
        public EmployeeData DeleteEmployeeTask(int id)
        {
            return this._employeeDetailsService.DeleteEmployeeTask(id);
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public EmployeeData DeleteEmployee(int id)
        {
            return this._employeeDetailsService.DeleteEmployee(id);
        }

        [HttpPut]
        [Route("UpdateEmployeeTask")]
        public int UpdateEmployeeTask(EmployeeData employeeData)
        {
            return this._employeeDetailsService.UpdateEmployeeTask(employeeData);
        }


        [HttpPost]
        [Route("AssignTaskToEmployee")]
        public int AssignTaskToEmployee(EmployeeData employeeData)
        {
            return this._employeeDetailsService.AssignTaskToEmployee(employeeData);
        }



        //[HttpGet]
        //public async Task<ActionResult<List<EmployeeDetails>>> GetEmployeeList()
        //{
        //    return Ok(await _context.Employees.ToListAsync());

        //}

        //[HttpPost]
        //public async Task<ActionResult<List<EmployeeDetails>>> CreateEmployee(EmployeeDetails employee)
        //{
        //    _context.Employees.Add(employee);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Employees.ToListAsync());
        //}

        //[HttpPut]
        //public async Task<ActionResult<List<EmployeeDetails>>> UpdateEmployee(EmployeeDetails employee)
        //{
        //    var dbemployee = await _context.Employees.FindAsync(employee.ID);
        //    if (dbemployee == null)
        //        return BadRequest("Employee not found");
        //    dbemployee.FirstName = employee.FirstName;
        //    dbemployee.LastName = employee.LastName;
        //    dbemployee.EmailAddress = employee.EmailAddress;
        //    dbemployee.Password = employee.Password;

        //    await _context.SaveChangesAsync();
        //    return Ok(await _context.Employees.ToListAsync());

        //}

        //[HttpDelete("{id}")]

        //public async Task<ActionResult<List<EmployeeDetails>>> DeleteEmployee(int id)
        //{
        //    var dbemployee = await _context.Employees.FindAsync(id);
        //    if (dbemployee == null)
        //        return BadRequest("Employee not found");
        //    _context.Employees.Remove(dbemployee);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Employees.ToListAsync());
        //}






        //[HttpGet]
        //public List<EmployeeTask> GetEmployeeTaskDetails()
        //{
        //    return new List<EmployeeTask>
        //    {
        //    new EmployeeTask
        //         {
        //            TaskID=1,
        //            TaskName = "Report",
        //            Status = "Not completed",
        //            Priority = "Low",
        //            PersonID = 1

        //         }
        //    };

        //}
    }
}
