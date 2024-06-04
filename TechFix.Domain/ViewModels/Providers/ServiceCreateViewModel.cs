using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ViewModels.Providers
{
    public class ServiceCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }

    }
}
