using Lezione9.Dev.Data;
using Lezione9.Dev.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Collections.Generic;

namespace Lezione9.Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ForecastDbContext _ctx;

        private readonly Mapper _mapper;

        public UserController(ForecastDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _ctx.Users.ToList().ConvertAll(_mapper.MapEntityToDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/Previsioni")]
        public IActionResult GetSingleFav(int id)
        {
            var search = _ctx.Users.Include(w => w.Favcities).ThenInclude(a => a.City).ThenInclude(c => c.Previsioni).ThenInclude(c => c.Giorno).SingleOrDefault(w => w.Id == id);

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime tomorrowrow = DateTime.Today.AddDays(2);
            DateTime today = DateTime.Today.Date;
            UserDTO searchthree = new UserDTO()
            {
                Id = search.Id,
                Name = search.Name,
                Cities = search.Favcities.ConvertAll(_mapper.MapFavcityToCityDTO)
            };

            foreach (var city in searchthree.Cities)
            {
                city.Previsioni = city.Previsioni
                    .Where(previsione =>
                        previsione.giorno == today ||
                        previsione.giorno == tomorrow ||
                        previsione.giorno == tomorrowrow)
                    .ToList();
            }
            return Ok(searchthree);


        }
        [HttpGet]
        [Route("{id}/Cities")]
        public IActionResult GetWithCity(int id)
        {
            var result = _ctx.Users.Include(w => w.Favcities).ThenInclude(a => a.City).SingleOrDefault(w => w.Id == id);
            if (result == null)
            {
                return BadRequest();
            }
            UserDTO dto = _mapper.MapEntityToDTO(result);

            return Ok(dto); 
        }

        [HttpPost]
        public IActionResult Create(UserDTO dto)
        {
            try
            {
                var entity = _mapper.MapDTOToEntity(dto);
                entity.Id = 0;
                _ctx.Users.Add(entity);
                return _ctx.SaveChanges() == 1
                    ? Created("", _mapper.MapEntityToDTO(entity))
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [Route("Favcities/{id}")]
        public IActionResult AddFav(int idc, int id)
        {
            try
            {
                User? r = _ctx.Users.SingleOrDefault(w => w.Id == id);
                City? fv = _ctx.Cities.SingleOrDefault(h => h.Id == idc);
                if (r == null || fv == null)
                {
                    return BadRequest();
                }
                else
                {
                    Favcity z = new Favcity()
                    {
                        // City=fv,
                        // User=r,
                        CityId = fv.Id,
                        UserId = r.Id
                    };

                    _ctx.Favcities.Add(z);
                    _ctx.SaveChanges();
                    return (Ok());
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(UserDTO User)
        {
            try
            {
                var entity = _ctx.Users.Find(User.Id);
                if (entity == null)
                {
                    return BadRequest();
                }
                entity.Name = User.Name;
                return _ctx.SaveChanges() == 1
                    ? Ok(_mapper.MapEntityToDTO(entity))
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                User entity = _ctx.Users.Find(id);
                if (entity == null)
                {
                    return BadRequest();
                }
                _ctx.Users.Remove(entity);

                //Inutilmente più complicato per ottenere lo stesso risultato ed Esotico, mi dicono

                //_ctx.Users.RemoveRange(_ctx.Users.Where(w => w.Id == id));
                return _ctx.SaveChanges() == 1
                    ? Ok()
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
