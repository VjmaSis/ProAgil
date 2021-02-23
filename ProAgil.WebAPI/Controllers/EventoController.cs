using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domen.DTOs;
using ProAgil.Domen.ModelBD;
using ProAgil.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public EventoController(IEventoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _repositorio.GetAllEventosAsync(true);

                var result = _mapper.Map<IEnumerable<EventoDTO>>(eventos);

                return Ok(result);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados: {erro.Message}");
            }
        }

        [HttpPost("Upload")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folder = Path.Combine("Resources", "Images");
                var pathDirectory = Path.Combine(Directory.GetCurrentDirectory(), folder);

                if (file.Length > 0)
                {
                    var filePath = Path.Combine(pathDirectory, file.FileName.Replace("\"", " ").Trim());
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok();
                
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados: {erro.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var evento = await _repositorio.GetEventoAsyncById(id, true);
                var result = _mapper.Map<EventoDTO>(evento);

                return Ok(result);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados: {erro.Message}");
            }
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var evento = await _repositorio.GetAllEventosAsyncBtTema(tema, true);
                var result = _mapper.Map<IEnumerable<EventoDTO>>(evento);

                return Ok(result);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados: {erro.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(EventoDTO model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                _repositorio.Add(evento);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Created($"/api/evento/{evento.ID}", _mapper.Map<EventoDTO>(evento));
                }
                else
                {
                    return BadRequest();
                }

                
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados: {erro.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EventoDTO model)
        {
            try
            {
                var evento = await _repositorio.GetEventoAsyncById(id, false);
                if (evento is null)
                {
                    return NotFound();
                }

                _mapper.Map(model, evento);

                _repositorio.Update(evento);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Created($"/api/evento/{evento.ID}", _mapper.Map<EventoDTO>(evento));
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados: {erro.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _repositorio.GetEventoAsyncById(id, false);
                if (evento is null)
                {
                    return NotFound();
                }

                _repositorio.Delete(evento);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro no banco de dados: {erro.Message}");
            }
        }

    }
}
