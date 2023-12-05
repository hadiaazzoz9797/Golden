namespace Golden.Model
{
    public enum Type
    {
        Value1 = 1,
        Value2 = 2
    }
    public class ResponsibleModel
    {
        public string Name { get; set; }
        public Type Type { get; set; }

    }
    public class ResponsibleUpdate
    {
        public string? Name { get; set; }
    }
    public class ResponsibleDto
    {
        public int ResponsibleId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
