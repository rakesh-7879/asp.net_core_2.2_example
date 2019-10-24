using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.Models
{
    public class AppraisalModel
    {
        public int AppraisalId { get; set; }
        [Required(ErrorMessage ="Select Any Employee")]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage ="select current Month")]
        public DateTime CurrentAppraisal { get; set; }
        public DateTime NextAppraisal { get; set; }
        public string AllFiles { get; set; }
        public string[] Files { get; set; } 
        public string Remark { get; set; }
    }
}
