using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Enums;

namespace TechFix.Domain.Entities
{
    public class ServiceEntity : Entity
    {

        public ServiceEntity(string title, Category category, ProviderEntity provider, string description, double amount)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(amount, 0, "amount", "Valo do serviço não pode ser menor do que 0")
                    .HasMinLen(description, 20, "description", "Descrição deve conter ao menos 20 caracteres")
                    .HasMinLen(title, 3, "title", "O titulo precisa ter mais do que 3 caracteres")
                    .HasMaxLen(title, 50, "title", "O titulo não pode ultrapassar 50 caracteres")
                );
            if (provider.Invalid)
                AddNotification("Provider", "Prestador inválido");

            ProviderId = provider.Id;
            Provider = provider;
            Category = category;
            Description = description;
            Amount = amount;
            Title = title;
            Slug = GenSlug(title);

        }

        public Guid ProviderId { get; private set; }
        public ProviderEntity Provider { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public double Amount { get; private set; }
        public string Title { get; private set; }

        public void UpdateDescription(string newDescription)
        {
            if(newDescription != null && newDescription.Length > 20)
                Description = newDescription;
        }

        public void UpdateAmount(double newAmount)
        {
            if (newAmount > 0)
                Amount = newAmount;
        }

        public string GenSlug(string title)
        {
            title = title.ToLower();
            title = title.Trim();
            title = title.Replace(" ", "-");
            return title;
        }

    }
}
