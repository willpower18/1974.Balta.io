using System;
using BaltaStore.Domain.StoreContext.CustomerComands.Inputs;
using BaltaStore.Domain.StoreContext.CustomerComands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerComand>,
        ICommandHandler<AddAddressComand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerComand command)
        {
            //Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já esta em uso");

            //Verificar se o Email ja existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este Email já esta em uso");

            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar a Entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar a entidade e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;
            //Persistir o cliente
            _repository.Save(customer);

            //Enviar um email de boas vindas
            _emailService.Send(email.Address, "teste@teste.com", "Bem Vindo!", "Seja Bem Vindo!");

            //Retornar o resultado para a tela
            return new CreateCustomerComandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressComand command)
        {
            throw new System.NotImplementedException();
        }
    }
}