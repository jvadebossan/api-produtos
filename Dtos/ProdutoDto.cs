using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutos2.Dtos
{
    public class ProdutoInserir
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public float Preco { get; set; }

        // Atributos opcionais
        public bool? Disponivel { get; set; } = true;
    }
}