using DanielStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DanielStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 carateres.")
                .HasMaxLen(FirstName, 30, "FirstName", "O nome deve conter no máximo 30 caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve ter no mínimo 3 caracters")
                .HasMaxLen(LastName, 30, "LastName", "O sobrenome deve ter no máximo 30 caracteres.")
                .IsEmail(Email, "Email", "E-mail inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );
            return IsValid;
        }
    }
}
