using HRM.RestService.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.RestService.Repository
{
    internal interface IEmployeeRepo
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int employeeId);
        HRMResponse<Employee> InsertEmployee(Employee employee);
        HRMResponse<Employee> UpdateEmployee(Employee employee);
        int DeleteEmployee(int employeeId);
    }
}
