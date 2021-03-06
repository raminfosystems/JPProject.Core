using FluentValidation;
using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.Client
{
    public abstract class ClientPropertyValidation<T> : AbstractValidator<T> where T : ClientPropertyCommand
    {

        protected void ValidateClientId()
        {
            RuleFor(c => c.ClientId).NotEmpty().WithMessage("ClientId must be set");
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("Value must be set");
        }
        protected void ValidateKey()
        {
            RuleFor(c => c.Key).NotEmpty().WithMessage("Please ensure you have entered key");
        }
    }
}