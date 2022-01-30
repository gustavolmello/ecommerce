using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoECommerce.Data.Entities;
using ProjetoECommerce.Data.Interfaces;
using ProjetoECommerce.Messages.Models;
using ProjetoECommerce.Messages.Services;
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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClientesController(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model)
        {
            try
            {
                //verificar se o email informado já está cadastrado no sistema
                if (_clienteRepository.Get(model.Email) != null)
                    return StatusCode(422, new {Mensagem = "O email informado já está cadastrado, tente outro." });

                var cliente = new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = MD5Service.Encrypt(model.Senha),
                    DataCadastro = DateTime.Now
                };

                var endereco = new Endereco
                {
                    Id = Guid.NewGuid(),
                    Logradouro = model.Logradouro,
                    Complemento = model.Complemento,
                    Numero = model.Numero,
                    Bairro = model.Bairro,
                    Cidade = model.Cidade,
                    Estado = model.Estado,
                    Cep = model.Cep,
                    ClienteId = cliente.Id
                };

                //cadastrando o cliente
                _clienteRepository.Create(cliente);
                _enderecoRepository.Create(endereco);

                var messageModel = new MessageModel
                {
                    Destinatario = cliente.Email,
                    Assunto = "Conta criada com sucesso - ECommerce COTI Informática",
                    Mensagem = $@"
                            <div style='text-align: center; margin: 40px; padding: 60px; border: 2px solid #ccc; font-size: 16pt;'>
                            <img src='https://www.cotiinformatica.com.br/imagens/logo-coti-informatica.png' />
                            <br/><br/>
                            Olá <strong>{cliente.Nome}</strong>,
                            <br/><br/>    
                            Seja bem vindo a nossa loja online, seu cadastro foi  criado com sucesso!
                            <br/><br/>              
                            Att<br/>   
                            Equipe COTI Informatica
                            </div>
                        "
                };

                //enviando mensagem por email..
                var messageService = new MessageService();
                messageService.SendMessage(messageModel);

                return Ok(new
                {
                    Mensagem = "Parabéns, sua conta foi criada com sucesso." });
                }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
