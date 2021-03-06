using FluentValidation;
using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.ApiResource
{
    public abstract class ApiScopeValidation<T> : AbstractValidator<T> where T : ApiScopeCommand
    {

        protected void ValidateScopeName()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Invalid scope");
        }
        protected void ValidateResourceName()
        {
            RuleFor(c => c.ResourceName).NotEmpty().WithMessage("ClientId must be set");
        }


    }
}