using System.ComponentModel.DataAnnotations;

namespace ClinicDM.ViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public String Email { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
