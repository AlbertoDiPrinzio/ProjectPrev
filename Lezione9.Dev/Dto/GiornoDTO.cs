using Lezione9.Dev.Data;

namespace Lezione9.Dev.Dto
{
    public class GiornoDTO
    {
        public int Id { get; set; }
        public DateTime giorno { get; set; }


        public int humidity { get; set; }
        public int avgtemp { get; set; }
        public List<CityDTO>? Cities { get; set; }
    }
}
