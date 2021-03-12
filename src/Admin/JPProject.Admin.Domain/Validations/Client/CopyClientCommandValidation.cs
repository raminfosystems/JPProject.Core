using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.Client
{
    public class CopyClientCommandValidation : ClientValidation<CopyClientCommand>
    {
        public CopyClientCommandValidation()
        {
            ValidateClientId();
        }
    }
}