using JPProject.Admin.Domain.Commands.Clients;
using JPProject.Admin.Domain.Validations.ApiResource;

namespace JPProject.Admin.Domain.Commands.ApiResource
{
    public class RemoveApiScopeCommand : ApiScopeCommand
    {

        public RemoveApiScopeCommand(string name, string resourceName)
        {
            Name = name;
            ResourceName = resourceName;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveApiScopeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}