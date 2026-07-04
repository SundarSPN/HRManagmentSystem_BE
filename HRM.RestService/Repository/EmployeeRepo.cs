using HRM.RestService.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogicLayer;

namespace HRM.RestService.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public HRMResponse<Employee> InsertEmployee(Employee employee)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            int ret;
            try
            {
                ret = BLL.InsertEmployee(employee);
                if(ret > 0)
                {
                    _response.ReturnObject = employee;
                }
                else
                {
                    _response.Status = Common.ResponseStatus.Error.ToString();
                    _response.Message = employee.Message.ToString();
                }
            }
            catch(Exception ex)
            {
                _response.Status = Common.ResponseStatus.Error.ToString();
                _response.Message = "Error in EmployeeRepo - InsertEmployee : " + ex.Message.ToString();
            }

            return _response;
        }


        public HRMResponse<Employee> UpdateEmployee(Employee employee)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            int ret;
            try
            {
                ret = BLL.UpdateEmployee(employee);
                if (ret > 0)
                {
                    _response.ReturnObject = employee;
                }
                else
                {
                    _response.Status = Common.ResponseStatus.Error.ToString();
                    _response.Message = employee.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.Error.ToString();
                _response.Message = "Error in EmployeeRepo - InsertEmployee : " + ex.Message.ToString();
            }

            return _response;
        }


        public int DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByID(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

    }
}