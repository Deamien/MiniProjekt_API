using Microsoft.Identity.Client;
using MiniProjekt_API.Models;

namespace MiniProjekt_API.Models
{
    public class InterestUrls
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public virtual People People { get; set; }
        public virtual Interests Interests { get; set; }
    }   
}
