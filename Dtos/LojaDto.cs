using System.ComponentModel.DataAnnotations;
using MenuOn.Models;

namespace MenuOn.Dtos
{
    class LojaDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string ImagemUrl { get; set; }
        public List<Usuario> Usuarios { get; set; } = [];
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
    public class LojaInserir
    {
        [Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O endereço deve ser informado")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O endereço deve ter entre 5 e 200 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A URL da imagem deve ser informada")]
        [Url(ErrorMessage = "A URL da imagem é inválida")]
        [StringLength(250, ErrorMessage = "A URL da imagem deve ter no máximo 250 caracteres")]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "O Id do dono da loja deve ser informado")]
        [UmItemNaLista(ErrorMessage = "Pelo menos um usuário dono deve ser informado")]
        public List<int> UsuariosIds { get; set; } = [];

        [Phone(ErrorMessage = "O telefone informado é inválido")]
        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres")]
        public string? Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail informado é inválido")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        public string? Email { get; set; }
    }

    public class LojaAtualizar
    {
        // Atributos opcionais
        [StringLength(100, MinimumLength = 4, ErrorMessage = "O nome deve ter entre 4 e 100 caracteres")]
        public string? Nome { get; set; }

        [StringLength(200, MinimumLength = 5, ErrorMessage = "O endereço deve ter entre 5 e 200 caracteres")]
        public string? Endereco { get; set; }

        [Url(ErrorMessage = "A URL da imagem é inválida")]
        [StringLength(250, ErrorMessage = "A URL da imagem deve ter no máximo 250 caracteres")]
        public string? ImagemUrl { get; set; }

        [UmItemNaLista(ErrorMessage = "Pelo menos um usuário dono deve ser informado")]
        public List<int>? UsuariosIds { get; set; } = [];

        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres")]
        public string? Telefone { get; set; }

        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        public string? Email { get; set; }
    }

}
