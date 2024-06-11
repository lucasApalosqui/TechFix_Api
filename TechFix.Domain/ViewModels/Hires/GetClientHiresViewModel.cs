using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ViewModels.Hires
{
    public class GetClientHiresViewModel
    {
        public Guid ClientId { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public double ServiceAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date {  get; set; }
    }
}
