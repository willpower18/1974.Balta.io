using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.CustomerComands.Inputs
{
    public class CreateCustomerComand : Notifiable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FistName", "O Nome deve conter no mínimo 3 Caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O Nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O Sobrenome deve conter no mínimo 3 Caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O Sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O Email é inválido")
                .HasLen(Document, 11, "Document", "CPF Inválido")
            );
            return Valid();
        }
    }
}