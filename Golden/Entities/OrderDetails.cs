using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class OrderDetails
    {
        [PrimaryKey]
        [AutoIncrement]
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ServicesId { get; set; }
        public Order order { get; set; }
        public Services Services { get; set; }
    }
}
