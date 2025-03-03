using System;

namespace Lezione9.Dev.Data
{
    public class City
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Favcity>? Favcities { get; set; }
        public List<GiornoGiornaliera>? Previsioni { get; set; }
    }
}
