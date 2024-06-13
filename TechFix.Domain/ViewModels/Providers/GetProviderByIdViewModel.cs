using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.ValueObjects;

namespace TechFix.Domain.ViewModels.Providers
{
    public class GetProviderByIdViewModel
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Phone { get; set; }
        public string UrlImage { get;  set; }
        public string Cnpj { get;  set; }
    }
}
