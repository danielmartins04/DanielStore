using FluentValidator;
using FluentValidator.Validation;

namespace DanielStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 carateres.")
                .HasMaxLen(FirstName, 30, "FirstName", "O nome deve conter no máximo 30 caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve ter no mínimo 3 caracters")
                .HasMaxLen(LastName, 30, "LastName", "O sobrenome deve ter no máximo 30 caracteres.")
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