using ServiceStack.DataAnnotations;
namespace Golden.Entities
{
    public class Contractor
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ContractorId { get; set; }
        public string Name { get; set; }
       public List<ProContractor> proContractors { get; set; }
    }
}
