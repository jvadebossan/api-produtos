using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos2.Dtos;
using apiProdutos2.Models;
using AutoMapper;

namespace apiProdutos2.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ProdutoInserir, Produto>();
            CreateMap<LojaInserir, Loja>();
            CreateMap<LojaAtualizar, Loja>();
            CreateMap<Loja, LojaDto>();
            CreateMap<MenuInserir, Menu>();
            CreateMap<MenuAtualizar, Menu>();
            CreateMap<CategoriaInserir, Categoria>();
            CreateMap<CategoriaAtualizar, Categoria>();
            CreateMap<ProdutoInserir, Produto>();
            CreateMap<ProdutoAtualizar, Produto>();
        }
    }
}