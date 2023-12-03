using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class ProSuper
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ProSuperId { get; set; }
        public int SuperVisorId { get; set; }
        public Project Project { get; set; }

    }
}
