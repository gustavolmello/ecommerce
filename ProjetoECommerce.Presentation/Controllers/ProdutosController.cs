using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoECommerce.Data.Interfaces;
using ProjetoECommerce.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //consultando os produtos do banco de dados
                var produtos = _produtoRepository.GetAll();

                var model = new List<ProdutoConsultaModel>();
                foreach (var item in produtos)
                {
                    model.Add(new ProdutoConsultaModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        Foto = item.Foto,
                        Preco = item.Preco
                    });
                }

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
