using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutos2.Dtos
{
    public class MenuInserir
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }


        // Atributos opcionais
        public bool Ativo { get; set; }
    }
}