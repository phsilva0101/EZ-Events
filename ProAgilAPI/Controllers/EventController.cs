using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entities;
using ProAgil.Repository.Data;
using ProAgil.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgilAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IProAgilRepository _repos;

        public EventController(IProAgilRepository repos)
        {
            _repos = repos;
        }



        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repos.GetAllEventAsync(true);
                return Ok(results);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }

        }

        // GET api/values/5
        [HttpGet("{eventId}")]
        public async Task<IActionResult> Get(int eventId)
        {
            try
            {
                var result = await _repos.GetEventAsyncById(eventId, true);
                return Ok(result);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpGet("getByTheme{theme}")]
        public async Task<IActionResult> Get(string theme)
        {
            try
            {
                var result = await _repos.GetAllEventAsyncByTheme(theme, true);
                return Ok(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Event model)
        {
            try
            {
                _repos.Add(model);

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



        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(int eventId, Event model)
        {
            try
            {
                var evento = _repos.GetEventAsyncById(eventId, false);
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

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int eventId)
        {
            try
            {
                var evento = _repos.GetEventAsyncById(eventId, false);
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
