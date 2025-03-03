using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lezione9.Dev.Data
{

    [PrimaryKey("UserId", "CityId")]
    public class Favcity
    {
        public int CityId { get; set;}    
        public int UserId { get; set;}  

        [ForeignKey("CityId")] 
        public City? City {get; set;}

        [ForeignKey("UserId")]
        public  User? User {get; set;}
  

    }
}
