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
            CreateMap<CategoriaInserir, Categoria>();
            CreateMap<MenuInserir, Menu>();
        }
    }
}