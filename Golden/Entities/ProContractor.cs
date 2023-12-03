using ServiceStack.DataAnnotations;
namespace Golden.Entities
{
    public class ProContractor
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ProContractorId { get; set; }
        public int ContractorId { get; set; }
        public Project Project { get; set; }
    }
}
