using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Entiry
{
    public class Appraisal
    {
        public int AppraisalId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CurrentAppraisal { get; set; }
        public DateTime NextAppraisal { get; set; }
        public string FilesName { get; set; }
        public string Remark { get; set; }

        public Employee Employee { get; set; }
    }
}
