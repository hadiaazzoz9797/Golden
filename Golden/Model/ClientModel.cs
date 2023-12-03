using System.ComponentModel.DataAnnotations;

namespace Golden.Model
{
    public class ClientModel
    {

        [Required, EmailAddress(ErrorMessage = "Email Should Be Like That : Example@Gmail.Com")]

        public string Email { get; set; }

        
        public string ClientName { get; set; }

        [Required, MinLength(6, ErrorMessage = " your password should be more 6 ")]
        public string Password { get; set; }


        public string? PhoneNumber { get; set; }


    }
    
    public class EditClientModel
    {

        public string? Email { get; set; }

        public string? ClientName { get; set; }

        public string? Password { get; set; }



        public string? PhoneNumber { get; set; }


    }


    public class ClientDto
    {

        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        //public string Role { get; set; }
    }

}
