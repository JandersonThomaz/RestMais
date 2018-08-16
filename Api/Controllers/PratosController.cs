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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PratosController : ControllerBase
    {
        private readonly RestMaisContext db;

        public PratosController(RestMaisContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Prato> Get(string nome = "")
        {
            return db.Pratos
                .Include(x => x.Restaurante)
                .Where(x => x.Nome.Contains(nome))
                .OrderByDescending(x => x.PratoId)
                .AsNoTracking()
                .ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prato = await db.Pratos.FindAsync(id);

            if (prato == null)
            {
                return NotFound();
            }

            return Ok(prato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PratoViewModel pratoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pratoViewModel.PratoId)
            {
                return BadRequest();
            }

            var prato = new Prato(pratoViewModel.Nome, pratoViewModel.RestauranteId, pratoViewModel.Preco, pratoViewModel.PratoId);

            db.Entry(prato).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PratoExists(id))
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
        public async Task<IActionResult> Post([FromBody] PratoViewModel pratoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prato = new Prato(pratoViewModel.Nome, pratoViewModel.RestauranteId, pratoViewModel.Preco, pratoViewModel.PratoId);

            db.Pratos.Add(prato);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = prato.PratoId }, prato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prato = await db.Pratos.FindAsync(id);
            if (prato == null)
            {
                return NotFound();
            }

            db.Pratos.Remove(prato);
            await db.SaveChangesAsync();

            return Ok(prato);
        }

        private bool PratoExists(int id)
        {
            return db.Pratos.Any(e => e.PratoId == id);
        }
    }
}