using System.ComponentModel.DataAnnotations;

namespace apiProdutos2.Dtos
{
    public class CategoriaInserir
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição da categoria é obrigatória")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 300 caracteres")]
        public string Descricao { get; set; }

        // Atributos opcionais
        [Range(0, 999, ErrorMessage = "A ordem de exibição deve estar entre 0 e 999")]
        public int? OrdemExibicao { get; set; }

        [Url(ErrorMessage = "A URL da imagem é inválida")]
        [StringLength(300, ErrorMessage = "A URL da imagem deve ter no máximo 300 caracteres")]
        public string? ImagemUrl { get; set; }

        public bool? Ativo { get; set; } = true;
    }

    public class CategoriaAtualizar
    {
        // Atributos opcionais
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int? OrdemExibicao { get; set; }
        public string? ImagemUrl { get; set; }
        public bool? Ativo { get; set; } = true;
    }

}
