using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.ViewModels.Clients
{
    public class UpdateClientUrlViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UrlImage { get; set; }
    }
}
