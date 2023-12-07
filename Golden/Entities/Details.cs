using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class Details
    {
        [AutoIncrement]
        [PrimaryKey]
        public int DetailsId { get; set; }
        public int ServicesId { get; set; }
        public string DetailName { get; set; }
        public Services Service { get; set; }

    }
}
