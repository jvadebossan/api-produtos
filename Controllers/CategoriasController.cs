using apiProdutos2.Dtos;
using apiProdutos2.Infra;
using apiProdutos2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apiProdutos2.Controllers
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

        [HttpPost]
        public IActionResult CriarCategoria([FromBody] CategoriaInserir categoriaDto)
        {
            var menu = _session.Get<Menu>(categoriaDto.MenuId);
            if (menu == null) return NotFound(LogUtils.MsgErro(categoriaDto.MenuId, "Menu"));

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            categoria.Menu = menu;

            _session.Save(categoria);

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

        [HttpGet]
        public IActionResult CategoriaPorMenuId([FromQuery] int menuId)
        {
            var categorias = _session.Query<Categoria>().Where(c => c.Menu.Id == menuId).ToList();

            if (!categorias.Any()) return NotFound(LogUtils.MsgErro(menuId));

            Console.WriteLine(LogUtils.MsgGet(categorias));
            return Ok(categorias);
        }

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
