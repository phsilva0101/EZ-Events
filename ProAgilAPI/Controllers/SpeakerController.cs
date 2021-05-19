using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain.Entities;
using ProAgil.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgilAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : Controller
    {
        private readonly IProAgilRepository _repos;

        public SpeakerController(IProAgilRepository repos)
        {
            _repos = repos;
        }

        [HttpGet("{speakerId}")]
        public async Task<IActionResult> Get(int speakerId)
        {
            try
            {
                var results = await _repos.GetSpeakerAsyncById(speakerId, true);
                return Ok(results);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpGet("getByName{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var results = await _repos.GetAllSpeakerAsyncByName(name, true);
                return Ok(results);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Speaker model)
        {
            try
            {
                _repos.Add(model);

                if (await _repos.SaveChangesAsync())
                {
                    return Created($"/api/speaker/{model.Id}", model);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int speakerId, Speaker model)
        {
            try
            {
                var evento = _repos.GetEventAsyncById(speakerId, false);
                if (evento == null)
                {
                    return NotFound();
                }

                _repos.Update(model);

                if (await _repos.SaveChangesAsync())
                {
                    return Created($"/api/event/{model.Id}", model);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int speakerId)
        {
            try
            {
                var evento = _repos.GetEventAsyncById(speakerId, false);
                if (evento == null)
                {
                    return NotFound();
                }

                _repos.Delete(evento);

                if (await _repos.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
            return BadRequest();
        }

    }
}
