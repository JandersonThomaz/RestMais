using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio.Models;
using Infra.Context;
using Api.ViewModels;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly RestMaisContext db;

        public RestaurantesController(RestMaisContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Restaurante> Get()
        {
            return db.Restaurantes.AsNoTracking().ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var restaurante = await db.Restaurantes.FindAsync(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return Ok(restaurante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] RestauranteViewModel restauranteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restauranteViewModel.RestauranteId)
            {
                return BadRequest();
            }

            var restaurante = new Restaurante(restauranteViewModel.Nome, restauranteViewModel.RestauranteId); 

            db.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RestauranteViewModel restauranteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurante = new Restaurante(restauranteViewModel.Nome);

            db.Restaurantes.Add(restaurante);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = restaurante.RestauranteId }, restaurante);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurante = await db.Restaurantes.FindAsync(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            db.Restaurantes.Remove(restaurante);
            await db.SaveChangesAsync();

            return Ok(restaurante);
        }

        private bool RestauranteExists(int id)
        {
            return db.Restaurantes.Any(e => e.RestauranteId == id);
        }
    }
}