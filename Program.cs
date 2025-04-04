using System;
using apiProdutos.Entities;
using apiProdutos.Infra;
using NHibernate;

namespace apiProdutos;
class Program
{
    static void Main(string[] args)
    {
        ISession session = HibernateUtils.GetSession();
        ITransaction transaction = session.BeginTransaction();

        Cliente cliente = session.Get<Cliente>(1);
        // foreach(var i in cliente.Pedidos){
        //     Console.WriteLine($"Pedido: {i.Cliente.Nome}");
        //     foreach( var x in i.Produtos){
        //         Console.WriteLine($"Item: {x.Nome} - {x.Preco:c}");
        //     }
        // }

        Produto produto9 = session.Get<Produto>(9);
        Produto produto10 = session.Get<Produto>(10);
        Produto produto11 = session.Get<Produto>(11);

        IList<Produto> listaProdutos = new List<Produto>();

        listaProdutos.Add(produto9);
        listaProdutos.Add(produto10);
        listaProdutos.Add(produto11);

        Pedido pedido = new Pedido(cliente, listaProdutos);

        session.Save(pedido);



        transaction.Commit();

    }   
}