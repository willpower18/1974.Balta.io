using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FistName", "O Nome deve conter no mínimo 3 Caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O Nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O Sobrenome deve conter no mínimo 3 Caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O Sobrenome deve conter no máximo 40 caracteres")
            );
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}