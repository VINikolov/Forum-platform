using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Common.Models.Incoming
{
    public class RegisterUserRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression
            (@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$",
            ErrorMessage = "The Email field format is invalid.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
