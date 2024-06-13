using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Commands.Contracts;
using TechFix.Domain.Enums;

namespace TechFix.Domain.Commands.Providers
{
    public class AddProviderServiceCommand : Notifiable, ICommand
    {
        public AddProviderServiceCommand() { }

        public AddProviderServiceCommand(string title, Category category, string description, double amount, Guid id)
        {
            Title = title;
            Category = category;
            Description = description;
            Amount = amount;
            Id = id;
        }

        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Amount, 0, "amount", "Valo do serviço não pode ser menor do que 0")
                    .HasMinLen(Description, 20, "description", "Descrição deve conter ao menos 20 caracteres")
                    .HasMinLen(Title, 3, "title", "O titulo precisa ter mais do que 3 caracteres")
                    .HasMaxLen(Title, 50, "title", "O titulo não pode ultrapassar 50 caracteres")
                    .IsNotNull(Id, "Id", "Prestador inválido")
                );
        }
    }
}
