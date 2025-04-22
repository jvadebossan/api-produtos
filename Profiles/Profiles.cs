using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuOn.Dtos;
using MenuOn.Models;
using AutoMapper;

namespace MenuOn.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ProdutoInserir, Produto>();
            CreateMap<LojaInserir, Loja>();
            CreateMap<LojaAtualizar, Loja>();
            CreateMap<Loja, LojaDto>()
            .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src.Usuarios.Select(u => u)
            .ToList())); ;
            CreateMap<MenuInserir, Menu>();
            CreateMap<MenuAtualizar, Menu>();
            CreateMap<CategoriaInserir, Categoria>();
            CreateMap<CategoriaAtualizar, Categoria>();
            CreateMap<ProdutoInserir, Produto>();
            CreateMap<ProdutoAtualizar, Produto>();
            CreateMap<UsuarioInserir, Usuario>();
            CreateMap<UsuarioAtualizar, Usuario>();
        }
    }
}