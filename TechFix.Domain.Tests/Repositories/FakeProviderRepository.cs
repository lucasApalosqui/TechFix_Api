﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;
using TechFix.Domain.Repositories;

namespace TechFix.Domain.Tests.Repositories
{
    internal class FakeProviderRepository : IProviderRepository
    {
        public void Create(ProviderEntity provider)
        {
            
        }

        public ProviderEntity GetById(Guid id)
        {
            return new ProviderEntity("testando", "teste@email.com","11939512568", "12345678", "12345678912365");
        }

        public void Update(ProviderEntity provider)
        {
            
        }
    }
}