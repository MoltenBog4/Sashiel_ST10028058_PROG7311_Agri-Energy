using System.ComponentModel.DataAnnotations;

namespace Sashiel_ST10028058_PROG7311.Models.ViewModels
{
    public class CreateFarmerViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
