using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using LoggerLayer;
using BusinessLogicLayer.Helper;

namespace BusinessLogicLayer
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly ILogger _logger;
        public EmployeeBL(ILogger logger)
        {
                this._logger  = logger;
        }
        public HRMResponse<Employee> InsertEmployee(Employee employee)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            List<SqlParameter> paramterList = new List<SqlParameter>();
            int ret;
            try
            {
                SqlParameter FirstName = new SqlParameter();
                FirstName.ParameterName = "@FirstName";
                FirstName.SqlDbType = SqlDbType.VarChar;
                FirstName.Value = employee.FirstName;
                FirstName.Size = 150;
                FirstName.Direction = ParameterDirection.Input;
                paramterList.Add(FirstName);

                SqlParameter LastName = new SqlParameter();
                LastName.ParameterName = "@LastName";
                LastName.SqlDbType = SqlDbType.VarChar;
                LastName.Size = 150;
                LastName.Value = employee.LastName;
                LastName.Direction = ParameterDirection.Input;
                paramterList.Add(LastName);

                SqlParameter Gender = new SqlParameter();
                Gender.ParameterName = "@Gender";
                Gender.SqlDbType = SqlDbType.VarChar;
                Gender.Size = 6;
                Gender.Value = employee.Gender;
                Gender.Direction = ParameterDirection.Input;
                paramterList.Add(Gender);

                SqlParameter MaritalStatus = new SqlParameter();
                MaritalStatus.ParameterName = "@MaritalStatus";
                MaritalStatus.SqlDbType = SqlDbType.VarChar;
                MaritalStatus.Size = 10;
                MaritalStatus.Value = employee.MaritalStatus;
                MaritalStatus.Direction = ParameterDirection.Input;
                paramterList.Add(MaritalStatus);

                SqlParameter Dob = new SqlParameter();
                Dob.ParameterName = "@Dob";
                Dob.SqlDbType = SqlDbType.DateTime;
                Dob.Value = employee.Dob;
                Dob.Direction = ParameterDirection.Input;
                paramterList.Add(Dob);

                SqlParameter Doj = new SqlParameter();
                Doj.ParameterName = "@Doj";
                Doj.SqlDbType = SqlDbType.DateTime;
                Doj.Value = employee.Doj;
                Doj.Direction = ParameterDirection.Input;
                paramterList.Add(Doj);

                SqlParameter DepartmentId = new SqlParameter();
                DepartmentId.ParameterName = "@DepartmentId";
                DepartmentId.SqlDbType = SqlDbType.SmallInt;
                DepartmentId.Value = employee.DepartmentId;
                DepartmentId.Direction = ParameterDirection.Input;
                paramterList.Add(DepartmentId);

                SqlParameter DesignationId = new SqlParameter();
                DesignationId.ParameterName = "@DesignationId";
                DesignationId.SqlDbType = SqlDbType.SmallInt;
                DesignationId.Value = employee.DesignationId;
                DesignationId.Direction = ParameterDirection.Input;
                paramterList.Add(DesignationId);

                SqlParameter QualificationId = new SqlParameter();
                QualificationId.ParameterName = "@QualificationId";
                QualificationId.SqlDbType = SqlDbType.SmallInt;
                QualificationId.Value = employee.QualificationId;
                QualificationId.Direction = ParameterDirection.Input;
                paramterList.Add(QualificationId);

                SqlParameter ContactNo = new SqlParameter();
                ContactNo.ParameterName = "@ContactNo";
                ContactNo.SqlDbType = SqlDbType.VarChar;
                ContactNo.Size = 20;
                ContactNo.Value = employee.ContactNo;
                ContactNo.Direction = ParameterDirection.Input;
                paramterList.Add(ContactNo);

                SqlParameter EmailId = new SqlParameter();
                EmailId.ParameterName = "@EmailId";
                EmailId.SqlDbType = SqlDbType.VarChar;
                EmailId.Size = 250;
                EmailId.Value = employee.EmailId;
                EmailId.Direction = ParameterDirection.Input;
                paramterList.Add(EmailId);

                SqlParameter EmergencyContact = new SqlParameter();
                EmergencyContact.ParameterName = "@EmergencyContact";
                EmergencyContact.SqlDbType = SqlDbType.VarChar;
                EmergencyContact.Size = 20;
                EmergencyContact.Value = employee.EmergencyContact;
                EmergencyContact.Direction = ParameterDirection.Input;
                paramterList.Add(EmergencyContact);

                SqlParameter Address = new SqlParameter();
                Address.ParameterName = "@Address";
                Address.SqlDbType = SqlDbType.VarChar;
                Address.Size = 4000;
                Address.Value = employee.Address;
                Address.Direction = ParameterDirection.Input;
                paramterList.Add(Address);

                SqlParameter CreatedBy = new SqlParameter();
                CreatedBy.ParameterName = "@CreatedBy";
                CreatedBy.SqlDbType = SqlDbType.VarChar;
                CreatedBy.Size = 50;
                CreatedBy.Value = employee.CreatedBy;
                CreatedBy.Direction = ParameterDirection.Input;
                paramterList.Add(CreatedBy);

                SqlParameter EmpId = new SqlParameter();
                EmpId.ParameterName = "@EmpId";
                EmpId.SqlDbType = SqlDbType.Int;
                EmpId.Size = -1;
                EmpId.Value = 0;
                EmpId.Direction = ParameterDirection.Output;
                paramterList.Add(EmpId);

                SqlParameter Message = new SqlParameter();
                Message.ParameterName = "@Message";
                Message.SqlDbType = SqlDbType.VarChar;
                Message.Size = -1;
                Message.Value = string.Empty;
                Message.Direction = ParameterDirection.Output;
                paramterList.Add(Message);


                ret = ADODAL.ExecuteNonQueryWithOutParam("InsertEmployee", paramterList);

                if (ret <= 0 || Convert.ToInt32(EmpId.Value) <=0)
                    _response.Status = Common.ResponseStatus.ERROR.ToString();
                
                _response.Message = Message.Value.ToString();
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee , method: InsertEmployee : " + ex.Message.ToString();
                _logger.log(_response.Message, employee.CreatedBy);
            }

            return _response;
        }

        public HRMResponse<Employee> UpdateEmployee(Employee employee)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            List<SqlParameter> paramterList = new List<SqlParameter>();
            int ret;
            try
            {
                SqlParameter EmployeeId = new SqlParameter();
                EmployeeId.ParameterName = "@EmployeeId";
                EmployeeId.SqlDbType = SqlDbType.Int;
                EmployeeId.Value = employee.EmployeeId;
                EmployeeId.Direction = ParameterDirection.Input;
                paramterList.Add(EmployeeId);

                SqlParameter FirstName = new SqlParameter();
                FirstName.ParameterName = "@FirstName";
                FirstName.SqlDbType = SqlDbType.VarChar;
                FirstName.Value = employee.FirstName;
                FirstName.Size = 150;
                FirstName.Direction = ParameterDirection.Input;
                paramterList.Add(FirstName);

                SqlParameter LastName = new SqlParameter();
                LastName.ParameterName = "@LastName";
                LastName.SqlDbType = SqlDbType.VarChar;
                LastName.Size = 150;
                LastName.Value = employee.LastName;
                LastName.Direction = ParameterDirection.Input;
                paramterList.Add(LastName);

                SqlParameter Gender = new SqlParameter();
                Gender.ParameterName = "@Gender";
                Gender.SqlDbType = SqlDbType.VarChar;
                Gender.Size = 6;
                Gender.Value = employee.Gender;
                Gender.Direction = ParameterDirection.Input;
                paramterList.Add(Gender);

                SqlParameter MaritalStatus = new SqlParameter();
                MaritalStatus.ParameterName = "@MaritalStatus";
                MaritalStatus.SqlDbType = SqlDbType.VarChar;
                MaritalStatus.Size = 10;
                MaritalStatus.Value = employee.MaritalStatus;
                MaritalStatus.Direction = ParameterDirection.Input;
                paramterList.Add(MaritalStatus);

                SqlParameter Dob = new SqlParameter();
                Dob.ParameterName = "@Dob";
                Dob.SqlDbType = SqlDbType.DateTime;
                Dob.Value = employee.Dob;
                Dob.Direction = ParameterDirection.Input;
                paramterList.Add(Dob);

                SqlParameter Doj = new SqlParameter();
                Doj.ParameterName = "@Doj";
                Doj.SqlDbType = SqlDbType.DateTime;
                Doj.Value = employee.Doj;
                Doj.Direction = ParameterDirection.Input;
                paramterList.Add(Doj);

                SqlParameter DepartmentId = new SqlParameter();
                DepartmentId.ParameterName = "@DepartmentId";
                DepartmentId.SqlDbType = SqlDbType.SmallInt;
                DepartmentId.Value = employee.DepartmentId;
                DepartmentId.Direction = ParameterDirection.Input;
                paramterList.Add(DepartmentId);

                SqlParameter DesignationId = new SqlParameter();
                DesignationId.ParameterName = "@DesignationId";
                DesignationId.SqlDbType = SqlDbType.SmallInt;
                DesignationId.Value = employee.DesignationId;
                DesignationId.Direction = ParameterDirection.Input;
                paramterList.Add(DesignationId);

                SqlParameter QualificationId = new SqlParameter();
                QualificationId.ParameterName = "@QualificationId";
                QualificationId.SqlDbType = SqlDbType.SmallInt;
                QualificationId.Value = employee.QualificationId;
                QualificationId.Direction = ParameterDirection.Input;
                paramterList.Add(QualificationId);

                SqlParameter ContactNo = new SqlParameter();
                ContactNo.ParameterName = "@ContactNo";
                ContactNo.SqlDbType = SqlDbType.VarChar;
                ContactNo.Size = 20;
                ContactNo.Value = employee.ContactNo;
                ContactNo.Direction = ParameterDirection.Input;
                paramterList.Add(ContactNo);

                SqlParameter EmailId = new SqlParameter();
                EmailId.ParameterName = "@EmailId";
                EmailId.SqlDbType = SqlDbType.VarChar;
                EmailId.Size = 250;
                EmailId.Value = employee.EmailId;
                EmailId.Direction = ParameterDirection.Input;
                paramterList.Add(EmailId);

                SqlParameter EmergencyContact = new SqlParameter();
                EmergencyContact.ParameterName = "@EmergencyContact";
                EmergencyContact.SqlDbType = SqlDbType.VarChar;
                EmergencyContact.Size = 20;
                EmergencyContact.Value = employee.EmergencyContact;
                EmergencyContact.Direction = ParameterDirection.Input;
                paramterList.Add(EmergencyContact);

                SqlParameter Address = new SqlParameter();
                Address.ParameterName = "@Address";
                Address.SqlDbType = SqlDbType.VarChar;
                Address.Size = 4000;
                Address.Value = employee.Address;
                Address.Direction = ParameterDirection.Input;
                paramterList.Add(Address);

                SqlParameter CreatedBy = new SqlParameter();
                CreatedBy.ParameterName = "@LastUpdatedBy";
                CreatedBy.SqlDbType = SqlDbType.VarChar;
                CreatedBy.Size = 50;
                CreatedBy.Value = employee.CreatedBy;
                CreatedBy.Direction = ParameterDirection.Input;
                paramterList.Add(CreatedBy);

                SqlParameter EmpId = new SqlParameter();
                EmpId.ParameterName = "@EmpId";
                EmpId.SqlDbType = SqlDbType.Int;
                EmpId.Size = -1;
                EmpId.Value = 0;
                EmpId.Direction = ParameterDirection.Output;
                paramterList.Add(EmpId);

                SqlParameter Message = new SqlParameter();
                Message.ParameterName = "@Message";
                Message.SqlDbType = SqlDbType.VarChar;
                Message.Size = -1;
                Message.Value = string.Empty;
                Message.Direction = ParameterDirection.Output;
                paramterList.Add(Message);


                ret = ADODAL.ExecuteNonQueryWithOutParam("UpdateEmployee", paramterList);

                if (ret <= 0 || Convert.ToInt32(EmpId.Value) <= 0)
                    _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = Message.Value.ToString();
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee , method: UpdateEmployee : " + ex.Message.ToString();
                _logger.log(_response.Message, employee.CreatedBy);
            }

            return _response;
        }

        public HRMResponse<Employee> DeleteEmployee(int employeeId,string updatedBy)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            List<SqlParameter> paramterList = new List<SqlParameter>();
            int ret;
            try
            {
                SqlParameter EmployeeId = new SqlParameter();
                EmployeeId.ParameterName = "@EmployeeId";
                EmployeeId.SqlDbType = SqlDbType.Int;
                EmployeeId.Value = employeeId;
                EmployeeId.Direction = ParameterDirection.Input;
                paramterList.Add(EmployeeId);


                SqlParameter UpdatedBy = new SqlParameter();
                UpdatedBy.ParameterName = "@LastUpdatedBy";
                UpdatedBy.SqlDbType = SqlDbType.VarChar;
                UpdatedBy.Size = 50;
                UpdatedBy.Value = updatedBy;
                UpdatedBy.Direction = ParameterDirection.Input;
                paramterList.Add(UpdatedBy  );

                SqlParameter EmpId = new SqlParameter();
                EmpId.ParameterName = "@EmpId";
                EmpId.SqlDbType = SqlDbType.Int;
                EmpId.Size = -1;
                EmpId.Value = 0;
                EmpId.Direction = ParameterDirection.Output;
                paramterList.Add(EmpId);

                SqlParameter Message = new SqlParameter();
                Message.ParameterName = "@Message";
                Message.SqlDbType = SqlDbType.VarChar;
                Message.Size = -1;
                Message.Value = string.Empty;
                Message.Direction = ParameterDirection.Output;
                paramterList.Add(Message);

                ret = ADODAL.ExecuteNonQueryWithOutParam("DeleteEmployee", paramterList);

                if (ret <= 0 || Convert.ToInt32(EmpId.Value) <= 0)
                    _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = Message.Value.ToString();
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in EmployeeRepo - UpdateEmployee : " + ex.Message.ToString();
                _logger.log(_response.Message, updatedBy);
            }

            return _response;
        }
        
        public HRMResponse<Employee> GetEmployeeByID(int employeeId)
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            List<SqlParameter> paramterList = new List<SqlParameter>();
            DataSet ret;
            try
            {
                SqlParameter EmployeeId = new SqlParameter();
                EmployeeId.ParameterName = "@EmployeeId";
                EmployeeId.SqlDbType = SqlDbType.Int;
                EmployeeId.Value = employeeId;
                EmployeeId.Direction = ParameterDirection.Input;
                paramterList.Add(EmployeeId);

                ret = ADODAL.ExecuteStoredProcedureReturnDataSet("GetEmployeeById", paramterList);

                if (ret!= null && ret.Tables.Count>0)
                {
                    if(ret.Tables[0].Rows.Count == 0)
                    {
                        _response.Status = Common.ResponseStatus.ERROR.ToString();
                        _response.Message = "No record found";
                    }
                    else
                    {
                        List<Employee> employeeDetails = new List<Employee>();
                        employeeDetails = CommonBehaviour.ConvertDataTableToList<Employee>(ret.Tables[0]);
                        _response.ReturnList = employeeDetails;
                    }

                }
                else
                {
                    _response.Status = Common.ResponseStatus.ERROR.ToString();
                    _response.Message = "No record found";
                }
                
            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee , method: GetEmployeeByID : " + ex.Message.ToString();
                _logger.log(_response.Message, "System");
            }

            return _response;
        }

        public HRMResponse<Employee> GetAllEmployees()
        {
            HRMResponse<Employee> _response = new HRMResponse<Employee>();
            List<SqlParameter> paramterList = new List<SqlParameter>();
            DataSet ret;
            try
            {
                ret = ADODAL.ExecuteStoredProcedureReturnDataSet("GetAllEmployees", paramterList);

                if (ret != null && ret.Tables.Count > 0)
                {
                    if (ret.Tables[0].Rows.Count == 0)
                    {
                        _response.Status = Common.ResponseStatus.ERROR.ToString();
                        _response.Message = "No record found";
                    }
                    else
                    {
                        List<Employee> employeeDetails = new List<Employee>();
                        employeeDetails = CommonBehaviour.ConvertDataTableToList<Employee>(ret.Tables[0]);
                        _response.ReturnList = employeeDetails;
                    }

                }
                else
                {
                    _response.Status = Common.ResponseStatus.ERROR.ToString();
                    _response.Message = "No record found";
                }

            }
            catch (Exception ex)
            {
                _response.Status = Common.ResponseStatus.ERROR.ToString();
                _response.Message = "Error in controller: Employee , method: GetAllEmployees : " + ex.Message.ToString();
                _logger.log(_response.Message, "System");
            }

            return _response;
        }

       
    }
}