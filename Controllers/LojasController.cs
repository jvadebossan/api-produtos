using apiProdutos2.Dtos;
using apiProdutos2.Infra;
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

            Console.WriteLine(LogUtils.MsgInsert(loja));
            return CreatedAtAction(nameof(LojaPorId), new { id = loja.Id }, loja);
        }

        [HttpGet()]
        public IActionResult Lojas(int quantidade = 10, int pagina = 1)
        {
            //paginacâo simples
            var lojas = _session.Query<Loja>();
            var total = lojas.Count();
            var lojasPaginadas = lojas.Skip((pagina - 1) * quantidade).Take(quantidade).ToList();

            Console.WriteLine(LogUtils.MsgGet(lojas));
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
            if (loja == null) return NotFound(LogUtils.MsgErro(id));

            Console.WriteLine(LogUtils.MsgGet(loja));
            return Ok(loja);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLoja(int id, [FromBody] LojaAtualizar lojaDto)
        {
            var loja = _session.Get<Loja>(id);

            if (loja == null)
                return NotFound(LogUtils.MsgErro(id));

            _mapper.Map(lojaDto, loja);

            using var transaction = _session.BeginTransaction();
            _session.Update(loja);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgUpdate(loja));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarLoja(int id)
        {
            var loja = _session.Get<Loja>(id);

            if (loja == null)
                return NotFound(LogUtils.MsgErro(id));

            using var transaction = _session.BeginTransaction();
            _session.Delete(loja);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgDelete(loja));
            return NoContent();
        }
    }
}