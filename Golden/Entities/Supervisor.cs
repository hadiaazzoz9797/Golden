using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class Supervisor
    {
        [PrimaryKey]
        [AutoIncrement]
        public int SuperVisorId { get; set; }
        public string Name { get; set; }
        public List<ProSuper> proSupers { get; set; }

    }
}
