using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechFix.Domain.Entities
{
    public abstract class Entity : Notifiable, IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Slug { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }

    }
}
