namespace Lezione9.Dev.Dto
{    public class UserDTO

     {
        //Questa classe serve per l'interazione con la programmazione frontend
        //Verra' riempita dai metodi del mapper per diversi scopi
        //Puo' essere riempita per ottenere:
        //1) uno Usere senza lista di sbj,
        //2) una sorta di FavcityDTO con User fisso e lista di materie, al fine di restituire uno Usere con lista di SbjDTO (esse stesse in versione DTO senza lista [vedi punto 1)])
        public int Id { get; set; }             
        public required string Name { get; set; }
        public string? Email {  get; set; }
        public List<CityDTO>? Cities { get; set; } 



     }
}
