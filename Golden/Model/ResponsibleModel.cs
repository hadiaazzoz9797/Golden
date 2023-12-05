using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using ServiceStack.DataAnnotations;

namespace Golden.Model
{
//    public enum Type
//    {
//        Value1 = 1,
//        Value2 = 2
//    }
    public enum Type
    {
        [Description("1-supervisor")]
        Supervisor = 1,

        [Description("2-contractor")]
        Contractor = 2
    }
    public class ResponsibleModel
    {
        public string Name { get; set; }

        [Description("1-supervisor,2-contractor")]
        public Type Type { get; set; } 
       


    }
    //public class ResponsibleApiModel
    //{
    //    public string Name { get; set; }

    //    [SwaggerSchema(Description = "1-supervisor, 2-contractor")]
    //    public Type Type { get; set; }
    //}
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
