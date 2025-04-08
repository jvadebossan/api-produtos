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

        // Atributo opcional
        public bool? Ativo { get; set; } = true;
    }
}
