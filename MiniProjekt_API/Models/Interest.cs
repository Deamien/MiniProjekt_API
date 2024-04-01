using System;

namespace MiniProjekt_API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? PersonId { get; set; }
        public Person Person { get; set; }

        public List<Link> Links { get; set; } = new List<Link>();
    }
}
