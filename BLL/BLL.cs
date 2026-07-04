using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class BLL
    {

        public static int InsertEmployee(Employee employee)
        {
            List<SqlParameter> paramterList = new List<SqlParameter>();
            int ret = 0;

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
                DesignationId.Value = employee.QualificationId;
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

                if(ret<=0 && Message.Value.ToString()!="")
                {
                    employee.Message = Message.Value.ToString();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string msg2 = ex.StackTrace;
            }

            return ret;
        }
        public static int UpdateEmployee(Employee employee)
        {
            List<SqlParameter> paramterList = new List<SqlParameter>();
            int ret = 0;

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
                DesignationId.Value = employee.QualificationId;
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

                if (ret <= 0 && Message.Value.ToString() != "")
                {
                    employee.Message = Message.Value.ToString();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string msg2 = ex.StackTrace;
            }

            return ret;
        }
    }
}
