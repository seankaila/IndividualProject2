using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Interfaces
{
    public interface IHistory
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Probability { get; set; }

    }
}
