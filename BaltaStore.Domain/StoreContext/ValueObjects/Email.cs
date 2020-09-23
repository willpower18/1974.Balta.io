using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O Email é inválido")
                .HasMinLen(Address, 5, "Address", "O Email deve conter no mínimo 5 Caracteres")
                .HasMaxLen(Address, 40, "Address", "O Email deve conter no máximo 40 caracteres")
            );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}