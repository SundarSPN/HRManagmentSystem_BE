using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IEmployeeBL
    {
        HRMResponse<Employee> InsertEmployee(Employee employee);
        HRMResponse<Employee> UpdateEmployee(Employee employee);
        HRMResponse<Employee> DeleteEmployee(int employeeId, string updatedBy);
        HRMResponse<Employee> GetEmployeeByID(int employeeId);
        HRMResponse<Employee> GetAllEmployees();


    }
}
