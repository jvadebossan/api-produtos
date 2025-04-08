using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos2.Dtos;
using apiProdutos2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apiProdutos2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {

        private readonly NHibernate.ISession _session;
        private readonly IMapper _mapper;

        public ProdutosController(NHibernate.ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }


        [HttpGet]
        public void Status()
        {
            Console.WriteLine("running");
        }

        [HttpPost]
        public void InserirProduto(ProdutoInserir produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _session.Save(produto);
            Console.WriteLine($"➕ Produto adicionado: {produto.Nome}");
        }
    }
}