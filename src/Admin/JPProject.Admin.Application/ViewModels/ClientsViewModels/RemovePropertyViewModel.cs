using System.ComponentModel.DataAnnotations;

namespace JPProject.Admin.Application.ViewModels.ClientsViewModels
{
    public class RemovePropertyViewModel
    {
        public RemovePropertyViewModel(string key, string clientId)
        {
            Key = key;
            ClientId = clientId;
        }
        [Required]
        public string Key { get; }

        [Required]
        public string ClientId { get; set; }

        public string Value { get; set; }
    }
}