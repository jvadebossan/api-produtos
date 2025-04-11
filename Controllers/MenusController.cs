using apiProdutos2.Dtos;
using apiProdutos2.Infra;
using apiProdutos2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apiProdutos2.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MenusController : Controller
    {
        private readonly NHibernate.ISession _session;
        private readonly IMapper _mapper;

        public MenusController(NHibernate.ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CriarMenu([FromBody] MenuInserir menuDto)
        {
            var menu = _mapper.Map<Menu>(menuDto);

            var loja = _session.Get<Loja>(menuDto.LojaId);
            if (loja == null) return NotFound(LogUtils.MsgErro(menuDto.LojaId, "Loja"));

            menu.Loja = loja;

            _session.Save(menu);

            Console.WriteLine(LogUtils.MsgInsert(menu));
            return CreatedAtAction(nameof(MenuPorId), new { id = menu.Id }, menu);
        }

        [HttpGet("{id}")]
        public IActionResult MenuPorId(int id)
        {
            Menu menu = _session.Get<Menu>(id);
            if (menu == null) return NotFound(LogUtils.MsgErro(id));

            Console.WriteLine(LogUtils.MsgGet(menu));
            return Ok(menu);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarMenu(int id, [FromBody] MenuAtualizar menuDto)
        {
            var menu = _session.Get<Menu>(id);
            if (menu == null) return NotFound(LogUtils.MsgErro(id));

            menu = _mapper.Map(menuDto, menu);

            using var transaction = _session.BeginTransaction();
            _session.Save(menu);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgUpdate(menu));
            return Ok(menu);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarMenu(int id)
        {
            var menu = _session.Get<Menu>(id);

            if (menu == null) return NotFound(LogUtils.MsgErro(id));

            using var transaction = _session.BeginTransaction();
            _session.Delete(menu);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgDelete(menu));
            return NoContent();
        }
    }
}