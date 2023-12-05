using ServiceStack.DataAnnotations;
namespace Golden.Entities
{
    public class Admin
    {
        [PrimaryKey]
        [AutoIncrement]
        public int AdminId { get; set; }
        [Required]
        [Unique]
        public string UserName { get; set; }
        public string? Token { get; set; }
        public string Role { get; set; }

        [Required]

        public string Password { get; set; }
    }
}
