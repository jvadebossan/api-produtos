using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiProdutos2.Dtos
{
    public class LojaInserir
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string ImagemUrl { get; set; }
        public DateTime DataCadastro { get; set; }

        // Atributos opcionais
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }
}