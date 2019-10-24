using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Entiry
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Zip { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }

        public Department Department { get; set; }
        public City City { get; set; }

        public ICollection<Appraisal> Appraisals { get; set; }
    }
}
