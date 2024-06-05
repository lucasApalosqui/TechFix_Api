using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ViewModels.Address
{
    public class GetAddressViewModel
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
    }
}
