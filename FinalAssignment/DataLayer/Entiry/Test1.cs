using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Entiry
{
    public class Test1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Test2> Test2s { get; set; }
    }
}
