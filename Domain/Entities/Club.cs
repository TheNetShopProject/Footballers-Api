using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Club :AuditableEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedYear { get; set; }
        public string League { get; set; }
        public ICollection<Fotballer> Fotballers { get; set; } = new HashSet<Fotballer>();
    }
}