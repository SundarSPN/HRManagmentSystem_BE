using Model;
using BusinessLogicLayer;
using System.Web.Http;
using System;
using LoggerLayer;
using System.Threading;

namespace HRM.RestService.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeBL _empBLL;
        private readonly ILogger _logger;
        public EmployeeController(IEmployeeBL empBLL,ILogger logger)
        {
            this._empBLL = empBLL;
            this._logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [Route("api/Employee/InsertEmployee")]
        [HttpPost]
        public HRMResponse<Employee> InsertEmployee([FromBody] Employee employee)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            try
            {
                _response= _empBLL.InsertEmployee(employee);
            }
            catch(Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee:InsertEmployee : " + ex.Message.ToString();
                _logger.log(_response.Message, employee.CreatedBy);
            }
            return _response;
        }


        [Route("api/Employee/UpdateEmployee")]
        [HttpPost]
        public HRMResponse<Employee> UpdateEmployee([FromBody] Employee employee)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            try
            {
                _response=_empBLL.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee:UpdateEmployee : " + ex.Message.ToString();
                _logger.log(_response.Message, employee.CreatedBy);
            }
            return _response;
        }

        [Route("api/Employee/DeleteEmployee/{id:int}/{updatedBy}")]
        [HttpPost]
        public HRMResponse<Employee> DeleteEmployee(int id,string updatedBy)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            try
            {
                _response= _empBLL.DeleteEmployee(id, updatedBy);
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee:DeleteEmployee : " + ex.Message.ToString();
                _logger.log(_response.Message, updatedBy);
            }
            return _response;
        }

        [Route("api/Employee/GetEmployeeById/{id:int}")]
        [HttpGet]
        public HRMResponse<Employee> GetEmployeeById(int id)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            try
            {
                _response= _empBLL.GetEmployeeByID(id);
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee:GetEmployeeById : " + ex.Message.ToString();
                _logger.log(_response.Message, "");
            }
            return _response;
        }

        [Route("api/Employee/GetAllEmployee")]
        [HttpPost]
        public HRMResponse<Employee> GetAllEmployees()
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            try
            {
               // Thread.Sleep(1000);
                _response= _empBLL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee:GetAllEmployees : " + ex.Message.ToString();
                _logger.log(_response.Message, "");
            }
            return _response;
        }








    }
}
