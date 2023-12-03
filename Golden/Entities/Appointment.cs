using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class Appointment
    {
        [PrimaryKey]
        [AutoIncrement]
        public int AppointmentId { get; set; }
        public int ClientId { get; set; }
        
        //public int ServiceId { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        [Reference]
        public Client Client { get; set; }
        //[Reference]
        //public Service Service { get; set; }
    }
}
