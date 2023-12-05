using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class Responsible
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ResponsibleId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public List<ProResponsible> proResponsibles { get; set; }

    }
}
