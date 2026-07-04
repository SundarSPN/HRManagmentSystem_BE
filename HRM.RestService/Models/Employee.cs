using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.RestService.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Doj { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public int QualificationId { get; set; }
        public string Qualification { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string EmergencyContact { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
}