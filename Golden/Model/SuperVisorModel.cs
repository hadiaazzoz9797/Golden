namespace Golden.Model
{
    public class SuperVisorModel
    {
        public string Name { get; set; }
    }
    public class SuperVisorUpdate
    {
        public string? Name { get; set; }
    }
    public class SuperVisorDto
    {
        public int SuperVisorId { get; set; }
        public string Name { get; set; }
    }
}
