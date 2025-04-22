using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MenuOn.Dtos;
using MenuOn.Infra;
using MenuOn.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MenuOn.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        private readonly NHibernate.ISession _session;
        private readonly IMapper _mapper;

        public AuthController(NHibernate.ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        private static string GerarToken(string usuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario)
        };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "MenuOn",
                audience: "MenuOn",
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credenciais);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("criar-conta")]
        public IActionResult CriarUsuario(UsuarioInserir usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            usuario.DataCadastro = DateTime.Now;

            using var transaction = _session.BeginTransaction();
            _session.Save(usuario);
            transaction.Commit();

            Console.WriteLine(LogUtils.MsgInsert(usuario));
            return Ok();
        }

        [HttpGet("entrar")]
        public IActionResult Entrar(UsuarioEntrar usuarioDto)
        {
            var usuario = _session.Query<Usuario>()
            .Where(u => u.Email == usuarioDto.Email)
            .ToList().First();
            if (usuario == null) return Unauthorized();

            if (usuario.Email == usuarioDto.Email && usuario.Senha == usuarioDto.Senha)
            {
                var token = GerarToken(usuarioDto.Email);
                Console.WriteLine(LogUtils.MsgGet(usuario));
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}