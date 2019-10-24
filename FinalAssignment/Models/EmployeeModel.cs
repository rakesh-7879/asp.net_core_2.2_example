using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [UIHint("Your Name")]
        [Required(ErrorMessage = "Required Field")]
        [Display(Name ="Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Zip")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        [Display(Name = "Leaving Date")]
        public DateTime? LeavingDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public string Status { get; set; }
        public string Departdment { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
