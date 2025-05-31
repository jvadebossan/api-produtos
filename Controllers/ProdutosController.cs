using MenuOn.Dtos;
using MenuOn.Infra;
using MenuOn.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MenuOn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {

        private readonly NHibernate.ISession _session;
        private readonly IMapper _mapper;

        public ProdutosController(NHibernate.ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        [Authorize(Roles = "shop-admin, admin")]
        [HttpPost]
        public IActionResult InserirProduto(ProdutoInserir produtoDto)
        {
            var categoria = _session.Get<Categoria>(produtoDto.CategoriaId);
            if (categoria == null) return NotFound(LogUtils.MsgErro(produtoDto.CategoriaId, "Categoria"));

            var produto = _mapper.Map<Produto>(produtoDto);
            produto.Categoria = categoria;

            using var transaction = _session.BeginTransaction();
            _session.Save(produto);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgInsert(produto));
            return CreatedAtAction(nameof(ProdutoPorId), new { id = produto.Id }, produto);
        }

        [HttpGet("{id}")]
        public IActionResult ProdutoPorId(int id)
        {
            var produto = _session.Get<Produto>(id);
            if (produto == null) return NotFound(LogUtils.MsgErro(id));

            Console.WriteLine(LogUtils.MsgGet(produto));
            return Ok(produto);
        }

        [Authorize(Roles = "shop-admin, admin")]
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] ProdutoAtualizar produtoDto)
        {
            var produto = _session.Get<Produto>(id);
            if (produto == null) return NotFound(LogUtils.MsgErro(id));

            _mapper.Map(produtoDto, produto);

            using var transaction = _session.BeginTransaction();
            _session.Update(produto);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgUpdate(produto));
            return NoContent();
        }

        [Authorize(Roles = "shop-admin, admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            var produto = _session.Get<Produto>(id);
            if (produto == null) return NotFound(LogUtils.MsgErro(id));

            using var transaction = _session.BeginTransaction();
            _session.Delete(produto);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgDelete(produto));
            return NoContent();
        }
    }
}