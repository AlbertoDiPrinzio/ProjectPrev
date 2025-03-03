using System.ComponentModel.DataAnnotations.Schema;

namespace Lezione9.Dev.Data
{



    public class GiornoGiornaliera
    {
        public int Id { get; set; }
        public int avgtemp { get; set; }
        public int humidity { get; set; }
        public int GiornoId { get; set; }  
        public int CityId { get; set; }
        [ForeignKey("GiornoId")]
        public Giorno? Giorno {  get; set; }
        [ForeignKey("CityId")]
        public City? City { get; set; } 
    }
}
