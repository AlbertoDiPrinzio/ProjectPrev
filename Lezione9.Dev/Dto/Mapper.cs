using Lezione9.Dev.Data;

namespace Lezione9.Dev.Dto
{
    public class Mapper
    {
        public UserDTO MapEntityToDTO(User entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Cities= entity.Favcities?.ConvertAll(MapFavcityToCityDTO)
            };
        }
        public User MapDTOToEntity(UserDTO dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email
            };
        }
        public City MapDTOToEntity(CityDTO dto)
        {
            return new City
            {
                Id = dto.Id,
                Name = dto.Name,   
                
            };
        }
        public CityDTO MapEntityToDTO(City entity)
        {
            return new CityDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Users = entity.Favcities?.ConvertAll(MapFavcityToUserDTO),
                Previsioni = entity.Previsioni?.ConvertAll(MapPrevisioniGToPrevisioni),              
            };
        }
        public GiornoDTO MapEntityToDTO(Giorno entity)
        {
            return new GiornoDTO
            {
                Id = entity.Id,
                 giorno = entity.giorno,    
                Cities= entity.PG?.ConvertAll(MapPrevisioniGToCityDTO),
            };
        }
        public GiornoDTO MapEntityToDTO (GiornoGiornaliera entity)
        { 
            return new GiornoDTO
            {
                Id= entity.Id,  
                giorno=entity.Giorno.giorno,
                
            };
        }

        public CityDTO MapPrevisioniGToCityDTO(GiornoGiornaliera e)
        {
            return new CityDTO
            {
                Id = e.CityId,
                Name = e.City?.Name ?? "not found",
           
            };
          }
        public GiornoDTO MapPrevisioniGToPrevisioni(GiornoGiornaliera e)
        {
            return new GiornoDTO
            {
               Id = e.GiornoId,
               giorno=e.Giorno.giorno,
               humidity= e.humidity,
               avgtemp=e.avgtemp,
            };
        }


        public UserDTO MapFavcityToUserDTO(Favcity entity) //metodo utilizzato per appiattire i dati di un esame specifico in uno UserDTO, non riportando la lista di City di cui ha svolto il rispettivo esame
        {
            return new UserDTO
            {
                Id= entity.UserId,
                Name=entity.User.Name ?? "Not Provided", 
            };
        }
        public CityDTO MapFavcityToCityDTO(Favcity entity) //metodo utilizzato per appiattire i dati di un esame specifico in una materiaDTO, non riportando la lista di Useri che hanno dato il rispettivo esame
        {
            return new CityDTO
            {
                Id = entity.CityId,
                Name = entity.City.Name ?? "Not Provided",             
                Previsioni = entity.City?.Previsioni?.ConvertAll(MapPrevisioniGToPrevisioni),   
            };
        }
    }
}
