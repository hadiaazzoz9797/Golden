﻿using ServiceStack.DataAnnotations;

namespace Golden.Entities
{
    public class ProResponsible
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ProResponsibleId { get; set; }
        public int ResponsibleId { get; set; }
        public Project Project { get; set; }

    }
}
