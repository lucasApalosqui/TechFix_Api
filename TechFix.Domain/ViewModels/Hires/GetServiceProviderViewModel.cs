using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ViewModels.Hires
{
    public class GetServiceProviderViewModel
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public DateTime HireDate { get; set; }
        public bool HireIsActive { get; set; }
    }
}
