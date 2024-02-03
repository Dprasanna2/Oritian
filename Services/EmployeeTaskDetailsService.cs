using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using OritainAPI.Interfaces;
using OritainAPI.ViewModels;

namespace OritainAPI.Services
{
    public class EmployeeTaskDetailsService : IEmployeeData
    {

        private readonly IConfiguration _configuration;

        public EmployeeTaskDetailsService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// CODE TO GET EMPLOYEE PERSONAL DETAILS
        /// </summary>
        /// <returns></returns>
        public List<EmployeeData> GetAllEmployeePersonalData ()
        {
            List<EmployeeData> employeeDetailsList = new List<EmployeeData>();
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    employeeDetailsList = connection.Query<EmployeeData>("SP_GetAllEmployeePersonalData", parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return employeeDetailsList;
        }


        /// <summary>
        /// CODE TO GET ALL EMPLOYEE DETAILS WITH TASK DETAILS
        /// </summary>
        /// <returns></returns>
        public List<EmployeeData> GetEmployeeDetails()
        {
            List<EmployeeData> employeeDetailsList = new List<EmployeeData>();
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    employeeDetailsList = connection.Query<EmployeeData>("SP_GetAllEmployeeDetail", parameter, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return employeeDetailsList;
        }

        /// <summary>
        /// CODE TO GET EMPLOYEE DETAILS WITH ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeData GetEmployeeDetailsByID(int id)
        {
            EmployeeData employeeDetailsList = new EmployeeData();
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@ID", id);
                    employeeDetailsList = connection.Query<EmployeeData>("SP_GetEmployeeTaskDetail", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return employeeDetailsList;
        }

        /// <summary>
        /// CODE TO CHECK IF EMAIL ADDRESS EXISTS
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns>boolean</returns>
        public bool CheckEmailIdExists(string emailId)
        {

            EmployeeData employeeData = new EmployeeData();
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@EmailAddress", emailId);
                    employeeData = connection.Query<EmployeeData>("SP_CheckEmailIdExists", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return employeeData != null? true : false;
        }



        /// <summary>
        /// DELETE EMPLOYEE TASK
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeData DeleteEmployeeTask(int id)
        {
             EmployeeData employeetask = new EmployeeData();
           try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@TaskID", id);
                    employeetask = connection.Query<EmployeeData>("SP_DeleteEmployeeDetails", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return employeetask;
        }

        /// <summary>
        /// DELETE EMPLOYEE DATA WITH TASK
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeData DeleteEmployee(int id)
        {
            EmployeeData employee = new EmployeeData();
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@ID", id);
                    employee = connection.Query<EmployeeData>("SP_DeleteEmplpoyeeDetailsandTask", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return employee;

        }




        public int UpdateEmployeeTask(EmployeeData employeeData)
        {
            int insertData = 0;
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@ID", employeeData.ID);
                    parameter.Add("@FirstName", employeeData.FirstName);
                    parameter.Add("@LastName", employeeData.LastName);
                    parameter.Add("@EmailAddress", employeeData.EmailAddress);
                    parameter.Add("@Password", employeeData.Password);
                    parameter.Add("@TaskName", employeeData.TaskName);
                    parameter.Add("@Status", employeeData.Status);
                    parameter.Add("@Priority", employeeData.Priority);
                    insertData = connection.Query<int>("SP_UpdateEmployeeDetailsById", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            return insertData;
        }

        /// <summary>
        /// CODE TO CREATE NEW USER AND ASSIGN TASK
        /// </summary>
        /// <param name="employeeData"></param>
        /// <returns></returns>
        public int AddEmployeeData(EmployeeData employeeData) {
            int insertData = 0;
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@FirstName", employeeData.FirstName);
                    parameter.Add("@LastName", employeeData.LastName);
                    parameter.Add("@EmailAddress", employeeData.EmailAddress);
                    parameter.Add("@Password", employeeData.Password);
                    parameter.Add("@TaskName", employeeData.TaskName);
                    parameter.Add("@Status", employeeData.Status);
                    parameter.Add("@Priority", employeeData.Priority);
                    insertData = connection.Query<int>("SP_CreateEmployeeWithTask", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            return insertData;
        }


        public int AssignTaskToEmployee(EmployeeData employeeData) {
            int insertTask = 0;
            try
            {
                using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@EmailAddress", employeeData.EmailAddress);
                    parameter.Add("@TaskName", employeeData.TaskName);
                    parameter.Add("@Status", employeeData.Status);
                    parameter.Add("@Priority", employeeData.Priority);
                    insertTask = connection.Query<int>("SP_AssignTaskToEmployee", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return insertTask;
        }
    }
}
