using Lezione9.Dev.Dto;

namespace Lezione9.Dev.Data
{
    public class Giorno
    {


        public int Id { get; set; }
        public DateTime giorno { get; set; } 
        public List<GiornoGiornaliera>? PG { get; set; }   



    }
}
