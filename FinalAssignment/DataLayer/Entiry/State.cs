using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Entiry
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
