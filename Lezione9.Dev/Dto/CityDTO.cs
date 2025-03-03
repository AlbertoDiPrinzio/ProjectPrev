using Lezione9.Dev.Data;

namespace Lezione9.Dev.Dto
{
    public class CityDTO
    {
        //Questa classe serve per l'interazione con la programmazione frontend
        //Verra' riempita dai metodi del mapper per diversi scopi
        //Puo' essere riempita per ottenere:
        //1) uno Usere senza lista di sbj,
        //2) una sorta di FavcityDTO con City fisso e lista di St, al fine di restituire una sbj con lista di StDTO (essi stesse in versione DTO senza lista [vedi punto 1)] )      
        public int Id {get; set;}
        public required string Name { get; set; }  
        //potrei metterlo nullable nel caso in cui in front non volessi specificatamente (quando richiedo uno User con lista di sbj (getwithsbj())) il credito dato da ogni materia
        public List<UserDTO>? Users {get; set;}
        public List<GiornoDTO>? Previsioni { get; set; }

    }
}
