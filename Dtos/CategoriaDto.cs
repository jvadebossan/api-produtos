using System.ComponentModel.DataAnnotations;

namespace MenuOn.Dtos
{
    public class CategoriaInserir
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição da categoria é obrigatória")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O MenuId é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O MenuId deve ser um número positivo.")]
        public int MenuId { get; set; }

        // Atributos opcionais
        [Range(0, 999, ErrorMessage = "A ordem de exibição deve estar entre 0 e 999")]
        public int? OrdemExibicao { get; set; }

        [Url(ErrorMessage = "A URL da imagem é inválida")]
        [StringLength(250, ErrorMessage = "A URL da imagem deve ter no máximo 250 caracteres")]
        public string? ImagemUrl { get; set; }

        public bool? Ativo { get; set; } = true;
    }

    public class CategoriaAtualizar
    {
        // Atributos opcionais
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string? Nome { get; set; }

        [StringLength(500, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 500 caracteres")]
        public string? Descricao { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O MenuId deve ser um número positivo.")]
        public int? MenuId { get; set; }

        // Atributos opcionais
        [Range(0, 999, ErrorMessage = "A ordem de exibição deve estar entre 0 e 999")]
        public int? OrdemExibicao { get; set; }

        [Url(ErrorMessage = "A URL da imagem é inválida")]
        [StringLength(250, ErrorMessage = "A URL da imagem deve ter no máximo 250 caracteres")]
        public string? ImagemUrl { get; set; }
        public bool? Ativo { get; set; } = true;
    }

}
