using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "First name is required.")]
         public string FirstName { get; set; } = string.Empty;
       [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")]
         [EmailAddress(ErrorMessage = "Invalid email Address.")]
         public string Email { get; set; } = string.Empty;
        
        public string PhoneNumber { get; set; }
        //biterwa na application urigisteruserdto
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
         public string Password { get; set; } = string.Empty;

    }
     public class UserDetailDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
       public  bool EmailConfirmed { get; set; }
       public DateTime CreatedAt { get; set; }
       public DateTime UpdatedAt { get; set; }
    }

    public class UpdateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName{get; set; }
        public string PhoneNumber { get; set; }
        //biterwa na application urigisteruserdto
        public string Password { get; set; }
    }

    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
         [EmailAddress(ErrorMessage = "Invalid email Address.")]
         public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
    
      
}