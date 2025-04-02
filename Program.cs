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

        //* Create
        //Cliente cliente = new Cliente("Jv", "jv@email.com", "1234");
        //session.Save(cliente);


        //* Read
        Cliente cliente1 = session.Get<Cliente>(1);
        Cliente cliente2 = session.Get<Cliente>(2);

        // cliente2.Nome = "Maria";
        // cliente2.Email = "maria@gmail.com";
        // cliente2.Senha = "5678";

        //* Update (need to change object before)
        //session.Update(cliente2);

        //* Delete
        //session.Delete(cliente3);

        transaction.Commit();

    }   
}