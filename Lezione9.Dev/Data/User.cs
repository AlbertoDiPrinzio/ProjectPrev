using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lezione9.Dev.Data
{
    
    public class User
    {
        public int Id { get; set; } 
        public required string Name { get; set; }
        public required string Email { get; set; }
        public List<Favcity>? Favcities { get; set; }
    }
}

