using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiProdutos2.Dtos;
using apiProdutos2.Models;
using AutoMapper;

namespace apiProdutos2.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoInserir, Produto>();
        }
    }
}