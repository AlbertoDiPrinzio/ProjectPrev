using Lezione9.Dev.Data;
using Lezione9.Dev.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Lezione9.Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ForecastDbContext _ctx;
        private readonly Mapper _mapper;

        public CityController(ForecastDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Cities.ToList().ConvertAll(_mapper.MapEntityToDTO);
            return Ok(result);

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingle(int id)
        {
            var result = _ctx.Cities.Include(w => w.Favcities).ThenInclude(a => a.User).SingleOrDefault(w => w.Id == id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.MapEntityToDTO(result));
        }

     
     
        [HttpPost]
        public IActionResult Create(CityDTO dto)
        {
            try
            {
                var entity = _mapper.MapDTOToEntity(dto);
                entity.Id = 0;
                _ctx.Cities.Add(entity);
                return _ctx.SaveChanges() == 1
                    ? Created("", _mapper.MapEntityToDTO(entity))
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(CityDTO City)
        {
            try
            {
                var entity = _ctx.Cities.Find(City.Id);
                if (entity == null)
                {
                    return BadRequest();
                }
                entity.Name = City.Name;
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
                var entity = _ctx.Cities.Find(id);
                if (entity == null)
                {
                    return BadRequest();
                }
                _ctx.Cities.Remove(entity);

                //Inutilmente più complicato per ottenere lo stesso risultato ed Esotico, mi dicono
                //_ctx.Cities.RemoveRange(_ctx.Cities.Where(w => w.Id == id));
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
