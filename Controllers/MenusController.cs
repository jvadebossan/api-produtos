using MenuOn.Dtos;
using MenuOn.Infra;
using MenuOn.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MenuOn.Controllers
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

        [Authorize(Roles = "shop-admin, admin")]
        [HttpPost]
        public IActionResult CriarMenu([FromBody] MenuInserir menuDto)
        {
            var loja = _session.Get<Loja>(menuDto.LojaId);
            if (loja == null) return NotFound(LogUtils.MsgErro(menuDto.LojaId, "Loja"));

            var menu = _mapper.Map<Menu>(menuDto);
            menu.Loja = loja;

            using var transaction = _session.BeginTransaction();
            _session.Save(menu);
            transaction.Commit();

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

        [Authorize(Roles = "shop-admin, admin")]
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

        [Authorize(Roles = "shop-admin, admin")]
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