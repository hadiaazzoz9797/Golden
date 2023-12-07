using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class Services
    {
        [AutoIncrement]
        [PrimaryKey]
        public int ServicesId { get; set; }
        public string ServiceName { get; set; }
 
        public string Servicetype { get; set; }
        public string Description { get; set; } 
        public List<OrderDetails> orderdetails { get; set; }
        public List<Details> Details { get; set; }
        //public List<Appointment> appointments { get; set; } 

    }
}
