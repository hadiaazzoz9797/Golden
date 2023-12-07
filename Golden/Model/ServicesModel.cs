namespace Golden.Model
{
    public class ServicesModel
    {
      
        public string ServiceName { get; set; }

        public string Servicetype { get; set; }
        public string Description { get; set; }
        //public List<detailsModel> details { get; set; }
    }
    public class detailsModel
    {
        public string DetailName { get; set; }
      

    }
    public class ServicesUpdate
    {
        public string? ServiceName { get; set; }

        public string? Servicetype { get; set; }
        public string? Description { get; set; }
    }
    public class ServicesDto
    {
        public int ServicesId { get; set; }
        public string ServiceName { get; set; }

        public string Servicetype { get; set; }
        public string Description { get; set; }
        public List<DetaisDto> Details { get; set; }
    }
    public class DetaisDto
    {
        public int DetailsId { get; set; }
        
        public string DetailName { get; set; }

      



    }
}
