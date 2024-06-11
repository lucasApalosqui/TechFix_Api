using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ViewModels.Hires
{
    public class CancelHireViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}
