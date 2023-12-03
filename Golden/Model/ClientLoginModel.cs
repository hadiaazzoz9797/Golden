using System.ComponentModel.DataAnnotations;


namespace Golden.Model
{
    public class ClientLoginModel
    {
        public class LoginModel
        {
            [Required,EmailAddress(ErrorMessage = "Email Should Be Like That : Example@Gmail.Com")]
            public string Email { get; set; }

            [Required, MinLength(6, ErrorMessage = " your password should be more 6 ")]

            public string Password { get; set; }


        }
        public class AdminLoginModel
        {
            [Required]
           
            public string UserName { get; set; }

            [Required, MinLength(6, ErrorMessage = " your password should be more 6 ")]

            public string Password { get; set; }


        }

        public class LoginDto
        {
            public string AccessToken { get; set; }
        }

        public class RegisterModel
        {
            [Required, EmailAddress]
            [ServiceStack.DataAnnotations.Unique]
            public string Email { get; set; }

            [Required, MinLength(6, ErrorMessage = " your password should be more 6 ")]
            public string Password { get; set; }
           
            public string ClientName { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
      
        }
        public class PhotoModel
        {
            public IFormFile? Photo { get; set; }

        }
        public class ForgotPasswordRegister
        {

            [Required, MinLength(6)]
            public string Password { get; set; } = string.Empty;
            [Required, Compare("Password")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }
        public class VerifyModel
        {
            //    [Required, EmailAddress]
            //    public string Email { get; set; }

            [Required]
            public string Token { get; set; } = string.Empty;

        }
        public class SimpleOrderDto
        {

            public int OrderId { get; set; }


            public int Amount { get; set; }
            public int TotalPrice { get; set; }

            public string OrderStatus { get; set; }
            public string DeleveryType { get; set; }


            //public List<ListMealDto> ListMeals { get; set; }


        }


    }
}
