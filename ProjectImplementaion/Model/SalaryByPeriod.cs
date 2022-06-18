using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectImplementaion
{
    [NotMapped]
    public class SalaryByPeriod
    {
        public string Employee { get; set; }
        public string Position { get; set; }
        public string Qualification { get; set; }
        public decimal SalarySum { get; set; }


    }
}

