using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectImplementaion
{
    [NotMapped]
public    class ProjectsFinancialReport
    {
        public string Project { get; set; }
        public string Customer { get; set; }
        public string Category { get; set; }
        public decimal OrdersSum { get; set; }

        public decimal PaymentsSum { get; set; }
    }
}
