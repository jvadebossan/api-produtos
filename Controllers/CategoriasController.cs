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
    public class CategoriasController : Controller
    {

        private readonly NHibernate.ISession _session;
        private readonly IMapper _mapper;

        public CategoriasController(NHibernate.ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        [Authorize(Roles = "shop-admin, admin")]
        [HttpPost]
        public IActionResult CriarCategoria([FromBody] CategoriaInserir categoriaDto)
        {
            var menu = _session.Get<Menu>(categoriaDto.MenuId);
            if (menu == null) return NotFound(LogUtils.MsgErro(categoriaDto.MenuId, "Menu"));

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            categoria.Menu = menu;

            using var transaction = _session.BeginTransaction();
            _session.Save(categoria);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgInsert(categoria));
            return CreatedAtAction(nameof(CategoriaPorId), new { categoria.Id }, categoria);
        }
        
        [HttpGet("{id}")]
        public IActionResult CategoriaPorId(int id)
        {
            var categoria = _session.Get<Categoria>(id);

            if (categoria == null) return NotFound(LogUtils.MsgErro(id));

            Console.WriteLine(LogUtils.MsgGet(categoria));
            return Ok(categoria);
        }

        [Authorize(Roles = "shop-admin, admin")]
        [HttpPut("{id}")]
        public IActionResult AtualizarCategoria(int id, CategoriaAtualizar categoriaDto)
        {
            var categoria = _session.Get<Categoria>(id);
            if (categoria == null) return NotFound(LogUtils.MsgErro(id));

            _mapper.Map(categoriaDto, categoria);

            using var transaction = _session.BeginTransaction();
            _session.Update(categoria);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgUpdate(categoria));
            return NoContent();
        }

        [Authorize(Roles = "shop-admin, admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletarCategoria(int id)
        {
            var categoria = _session.Get<Categoria>(id);
            if (categoria == null) return NotFound(LogUtils.MsgErro(id));

            using var transaction = _session.BeginTransaction();
            _session.Delete(categoria);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgDelete(categoria));
            return NoContent();
        }
    }
}
