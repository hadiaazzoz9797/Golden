using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class Client
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ClientId { get; set; }
       
        [StringLength(50)]
        public string? ClientName { get; set; }
        public string Email{ get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string? VertificationToken { get; set; } = string.Empty;
        public DateTime? Verified { get; set; }=DateTime.Now;
        public string? PasswordResetToken { get; set; } = string.Empty;
        public DateTime? ResetTokenExpires { get; set; }
        public List<Appointment> Appointment { get; set; }
        public List<Order> orders { get; set; }



    }
}
