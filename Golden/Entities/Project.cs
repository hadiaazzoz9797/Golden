using ServiceStack.DataAnnotations;
namespace Golden.Entities
{
    public class Project
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ProjectId { get; set; }
        public int OrderId { get; set; }
        public int ProResponsibleId { get; set; }

        


        public List<ProResponsible> ProResponsible { get; set; }
        public List<Image> images { get; set; }
        public Order Order { get; set; }
    }
}
