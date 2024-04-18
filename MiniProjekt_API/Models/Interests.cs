namespace MiniProjekt_API.Models
{
    public class Interests
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection <People> People { get; set; }
        public virtual ICollection<InterestUrls> InterestUrls { get; set; }
    }
}
