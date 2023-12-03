using ServiceStack.DataAnnotations;
namespace Golden.Entities
{
    public class Project
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ProjectId { get; set; }
        public int OrderId { get; set; }
        public int ProSuperId { get; set; }
        public int ProContractorId { get; set; }
        

        public string CompletionPercentage { get; set; }
        public List<ProContractor> ProContractor { get; set; }
        public List<ProSuper> ProSuper { get; set; }
        public List<Image> images { get; set; }
        public Order Order { get; set; }
    }
}
