using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Infra.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClientClaims(this ClientEntity client)
        {
            var result = new List<Claim>
            {
                new (ClaimTypes.Name, client.Id.ToString()),
                new (ClaimTypes.Role, "cliente")
            };

            return result;
        }

        public static IEnumerable<Claim> GetProviderClaims(this ProviderEntity provider)
        {
            var result = new List<Claim>
            {
                new (ClaimTypes.Name, provider.Id.ToString()),
                new (ClaimTypes.Role, "prestador")
            };

            return result;
        }
    }
}
