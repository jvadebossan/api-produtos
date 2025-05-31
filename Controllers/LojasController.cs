using System.Text.Json;
using MenuOn.Dtos;
using MenuOn.Infra;
using MenuOn.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MenuOn.Controllers
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

        [Authorize(Roles = "shop-admin, admin")]
        [HttpPost]
        public IActionResult CriaLoja([FromBody] LojaInserir lojaDto)
        {

            var loja = _mapper.Map<Loja>(lojaDto);
            loja.Usuarios = _session.Query<Usuario>()
                .Where(u => lojaDto.UsuariosIds.Contains(u.Id))
                .ToList();

            using var transaction = _session.BeginTransaction();

            foreach (var usuario in loja.Usuarios)
            {
                if (!usuario.Lojas.Contains(loja))
                    usuario.Lojas.Add(loja);
                _session.SaveOrUpdate(usuario);
            }

            _session.SaveOrUpdate(loja);
            transaction.Commit();

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

            var lojasDto = _mapper.Map<List<LojaDto>>(lojasPaginadas);

            Console.WriteLine(LogUtils.MsgGet(lojas));
            return Ok(new
            {
                total,
                lojas = lojasDto
            });
        }

        [HttpGet("{id}")]
        public IActionResult LojaPorId(int id)
        {
            var loja = _session.Query<Loja>()
            .Fetch(x => x.Usuarios)
            .FirstOrDefault(x => x.Id == id);

            if (loja == null) return NotFound(LogUtils.MsgErro(id));

            var lojaDto = _mapper.Map<LojaDto>(loja);

            Console.WriteLine(LogUtils.MsgGet(lojaDto));
            return Ok(lojaDto);
        }

        [HttpGet("{id}/cardapio")]
        public IActionResult LojaComCardapio(int id)
        {
            var loja = _session.Get<Loja>(id);
            if (loja == null) return NotFound(LogUtils.MsgErro(id));

            Console.WriteLine(LogUtils.MsgGet(loja));
            return Ok(loja);
        }

        [Authorize(Roles = "shop-admin, admin")]
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

        [Authorize(Roles = "shop-admin, admin")]
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