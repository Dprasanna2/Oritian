using OritainAPI.ViewModels;
namespace OritainAPI.Interfaces
{
    public interface IEmployeeData
    {
        public List<EmployeeData> GetEmployeeDetails();

        public List<EmployeeData> GetAllEmployeePersonalData();
        public int AddEmployeeData(EmployeeData employeeData);
        public int AssignTaskToEmployee(EmployeeData employeeData);
        public EmployeeData GetEmployeeDetailsByID(int id);
        public EmployeeData DeleteEmployeeTask(int id);
        public EmployeeData DeleteEmployee(int id);
        public bool CheckEmailIdExists(string emailId);
        public int UpdateEmployeeTask(EmployeeData employeeData);
    }
}
