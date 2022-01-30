using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoECommerce.Data.Interfaces;
using ProjetoECommerce.Presentation.Models;
using ProjetoECommerce.Security.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly TokenService _tokenService;

        public LoginController(IClienteRepository clienteRepository, TokenService tokenService)
        {
            _clienteRepository = clienteRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Post(LoginModel model)
        {


            try
            {
                //obter o cliente pelo email e senha
                var cliente = _clienteRepository.Get(model.Email, MD5Service.Encrypt(model.Senha));

                //verificar se o cliente foi encontrado
                if (cliente != null)
                {
                    //autenticando o cliente
                    return Ok(new
                    {
                        Mensagem = $"Cliente {cliente.Nome} autenticado com sucesso.",
                        AccessToken = _tokenService.GenerateToken(cliente.Email),
                        Cliente = new
                        {
                            Nome = cliente.Nome,
                            Email = cliente.Email,
                            DataCadastro = cliente.DataCadastro
                        }
                    });
                }
                else
                {
                    return StatusCode(401, new { Mensagem = "Acesso negado. Dados inválidos." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
