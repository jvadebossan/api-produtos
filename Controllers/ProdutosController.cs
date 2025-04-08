using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos2.Dtos;
using apiProdutos2.Infra;
using Microsoft.AspNetCore.Mvc;

namespace apiProdutos2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public void Status(){
            Console.WriteLine("running");
        }

        [HttpPost]
        public void InserirProduto(ProdutoInserir produto){
            NHibernate.ISession session = NhUtils.GetSession();

            session.Save(produto);
            Console.WriteLine($"➕ Adicionando produto {produto.Nome} - {produto.Preco}");
        }
    }
}