using System;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.CustomerComands.Outputs
{
    public class CreateCustomerComandResult : Notifiable, ICommandResult
    {
        public CreateCustomerComandResult() { }
        public CreateCustomerComandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}