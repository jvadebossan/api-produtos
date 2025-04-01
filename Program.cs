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

        Cliente cliente = new Cliente("Jv", "jv@email.com", "1234");

        session.Save(cliente);
    }   
}