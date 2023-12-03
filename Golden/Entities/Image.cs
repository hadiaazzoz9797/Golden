using ServiceStack.DataAnnotations;
namespace Golden.Entities
{
    public class Image
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ImageId { get; set; }
        public int ProjectId { get; set; }
        public string ImageUrl { get; set; }
        public Project Project { get; set; }
    }
}
