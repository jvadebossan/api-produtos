using System.ComponentModel.DataAnnotations;
using apiProdutos2.Models;

namespace apiProdutos2.Dtos
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public DateTime DataCadastro { get; set; }
        public IList<Loja> Lojas { get; set; } = [];
    }

    public class UsuarioEntrar
    {
        [Required(ErrorMessage = "O e-mail deve ser informado")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Senha { get; set; }
    }

    public class UsuarioInserir
    {
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail deve ser informado")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O cargo deve ser informado")]
        [StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres")]
        public string Cargo { get; set; }
    }

    public class UsuarioAtualizar
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Cargo { get; set; }
    }
}