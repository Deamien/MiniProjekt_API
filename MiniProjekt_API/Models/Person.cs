namespace MiniProjekt_API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }

        public List<Interest> Interests { get; set; } = new List<Interest>();
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
