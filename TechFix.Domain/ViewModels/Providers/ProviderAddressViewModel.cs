using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ViewModels.Providers
{
    public class ProviderAddressViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
    }
}
