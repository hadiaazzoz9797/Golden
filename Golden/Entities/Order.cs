using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class Order
    {
        [AutoIncrement]
        [PrimaryKey]
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public string Budget { get; set; }
       
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public string BuildingArea { get; set; }

        public string Country { get; set; }
        public List<Services> services { get; set; }
        public Client Client { get; set; }
        public List<Project> projects { get; set; }
    }
}
