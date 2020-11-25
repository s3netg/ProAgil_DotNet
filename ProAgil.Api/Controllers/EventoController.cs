using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.Api.Controllers
{ 
    [ApiController]
    [Route("api/[Controller]")]
    public class EventoController : ControllerBase
    {

        public IProAgilRepository _repo { get; }
        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results =  await this._repo.GetAllEventosAsync(true);
                return Ok(results);
            }
            catch (System.Exception e)
            {
                 
               return this.StatusCode(StatusCodes.Status500InternalServerError,e.Message);
            }

              
        }
         [HttpGet("{id}")]
          public async Task<IActionResult> Get( int id)
        {
            try
            {
                var results =  await this._repo.GetEventoAsyncById(id,true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou ");
            }
         
        }
         [HttpGet("getbytema/{tema}")]
          public async Task<IActionResult> Get( string tema)
        {
            try
            {
                var results =  await this._repo.GetAllEventosAsyncByTema(tema,true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou ");
            }
         
        }
         [HttpPost]
          public async Task<IActionResult> Post( Evento model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/evento/{model.id}",model);
                }
            }
            catch (System.Exception)
            {
                
                 return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou ");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> Put( int id, Evento model)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(id,false);

                if(evento == null) return NotFound();

                _repo.Update(model);
              

                if(await _repo.SaveChangesAsync()){
                    return Created($"/api/evento/{model.id}",model);
                }
            }
            catch (System.Exception)
            {
                
                 return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou ");
            }
            return BadRequest();

        }
         [HttpDelete("{id}")]
          public async Task<IActionResult> Delete( int id)
        {
            try
            {
                var evento = await _repo.GetEventoAsyncById(id,false);

                if(evento == null) return NotFound();
                _repo.Delete(evento);
                if(await _repo.SaveChangesAsync()){
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                
                 return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou ");
            }
            return BadRequest();
        }

    }
}