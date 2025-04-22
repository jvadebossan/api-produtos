using System.ComponentModel.DataAnnotations;

namespace apiProdutos2.Dtos
{
    public class MenuInserir
    {
        [Required(ErrorMessage = "O nome do menu é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do menu é obrigatória")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 300 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O id da loja é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser positivo")]
        public int LojaId { get; set; }

        // Atributo opcional
        public bool? Ativo { get; set; } = true;
    }

    public class MenuAtualizar
    {
        // Atributo opcional
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string? Nome { get; set; }

        [StringLength(300, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 300 caracteres")]
        public string? Descricao { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser positivo")]
        public int? LojaId { get; set; }

        public bool? Ativo { get; set; } = true;
    }

}
