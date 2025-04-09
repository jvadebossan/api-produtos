
using System.Text.Json;
using apiProdutos2.Dtos;
using apiProdutos2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CriaLoja([FromBody] LojaInserir lojaDto)
        {
            var loja = _mapper.Map<Loja>(lojaDto);

            _session.Save(loja);
            Console.WriteLine($"🆙 Loja adicionada: {loja.Nome}");

            return CreatedAtAction(nameof(LojaPorId), new { id = loja.Id }, loja);
        }

        [HttpGet()]
        public IActionResult Lojas(int quantidade = 10, int pagina = 1)
        {
            //paginacâo simples
            var lojas = _session.Query<Loja>();
            var total = lojas.Count();
            var lojasPaginadas = lojas.Skip((pagina - 1) * quantidade).Take(quantidade).ToList();

            Console.WriteLine($"✅ Loja encontrada [ID]: \n{JsonSerializer.Serialize(lojas)}");
            return Ok(new
            {
                total,
                lojas = lojasPaginadas
            });
        }

        [HttpGet("{id}")]
        public IActionResult LojaPorId(int id)
        {
            var loja = _session.Get<Loja>(id);
            if (loja == null) return NotFound(new { mensagem = $"Loja com ID {id} não encontrada." });

            Console.WriteLine($"✅ Loja encontrada [ID]: \n{JsonSerializer.Serialize(loja)}");
            return Ok(loja);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLoja(int id, [FromBody] LojaAtualizar lojaDto)
        {
            var loja = _session.Get<Loja>(id);

            if (loja == null)
                return NotFound(new { mensagem = $"Loja com ID {id} não encontrada." });

            _mapper.Map(lojaDto, loja);

            using var transaction = _session.BeginTransaction();
            _session.Update(loja);
            transaction.Commit();
            Console.WriteLine($"🔄️ Loja atualizada: {loja.Nome}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarLoja(int id)
        {
            var loja = _session.Get<Loja>(id);

            if (loja == null)
                return NotFound(new { mensagem = $"Loja com ID {id} não encontrada." });

            using var transaction = _session.BeginTransaction();
            _session.Delete(loja);
            transaction.Commit();
            Console.WriteLine($"❌ Loja deletada: {loja.Nome}");

            return NoContent();
        }
    }
}