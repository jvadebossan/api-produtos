using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using apiProdutos2.Dtos;
using apiProdutos2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace apiProdutos2.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LojasController : Controller
    {
        private readonly NHibernate.ISession _session;
        private readonly IMapper _mapper;

        public LojasController(NHibernate.ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CriaLoja([FromForm] LojaInserir lojaDto)
        {
            var loja = _mapper.Map<Loja>(lojaDto);
            _session.Save(loja);
            Console.WriteLine($"➕ Loja adicionado: {loja.Nome}");
            return CreatedAtAction(nameof(LojaPorId), new { id = loja.Id }, loja);

        }

        [HttpGet()]
        public IActionResult Lojas(int quantidade = 10, int pagina = 1)
        {
            //paginacâo simples
            var lojas = _session.Query<Loja>();

            return Ok(new
            {
                total = lojas.Count(),
                lojas = lojas.Skip((pagina - 1) * quantidade).Take(quantidade)
            });
        }

        [HttpGet("{id}")]
        public IActionResult LojaPorId(int id)
        {
            var loja = _session.Get<Loja>(id);
            if (loja == null) return NotFound();

            return Ok(loja);
        }

        [HttpPut()]
        public IActionResult EditarLoja(int id, [FromForm] LojaInserir lojaDto)
        {
            var loja = _session.Get<Loja>(id);

            if (loja == null)
                return NotFound(new { mensagem = $"Loja com ID {id} não encontrada." });

            _mapper.Map(lojaDto, loja);

            using var transaction = _session.BeginTransaction();
            _session.Update(loja);
            transaction.Commit();

            return NoContent();
        }

        [HttpDelete()]
        public IActionResult DeletarLojar(int id)
        {
            var loja = _session.Get<Loja>(id);

            if (loja == null)
                return NotFound(new { mensagem = $"Loja com ID {id} não encontrada." });
            
            using var transaction = _session.BeginTransaction();
            _session.Delete(loja);
            transaction.Commit();

            return NoContent();
        }
    }
}