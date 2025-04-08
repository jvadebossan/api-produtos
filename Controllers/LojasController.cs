using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using apiProdutos2.Dtos;
using apiProdutos2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apiProdutos2.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LojasController : Controller
    {
        private readonly NHibernate.ISession _session;
        private readonly IMapper _mapper;

        public LojasController(NHibernate.ISession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        [HttpPost]
        public void CriaLoja([FromForm]LojaInserir lojaDto)
        {
            var loja = _mapper.Map<Loja>(lojaDto);

            Console.WriteLine(JsonSerializer.Serialize(loja));
        }
    }
}