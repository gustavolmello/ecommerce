using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoECommerce.Data.Entities;
using ProjetoECommerce.Data.Interfaces;
using ProjetoECommerce.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public PedidosController(IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository, IClienteRepository clienteRepository, IProdutoRepository produtoRepository, IEnderecoRepository enderecoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itemPedidoRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _enderecoRepository = enderecoRepository;
        }

        [HttpPost]
        public IActionResult Post(PedidoCadastroModel model)
        {
            try
            {
                //obter o cliente autenticado atraves do email gravado no TOKEN..
                var cliente = _clienteRepository.Get(User.Identity.Name);

                var pedido = new Pedido
                {
                    Data = model.Data,
                    Valor = model.Valor,
                    ClienteId = cliente.Id
                };

                //cadastrando o pedido
                _pedidoRepository.Create(pedido);

                //cadastrando os itens do pedido
                foreach (var item in model.Itens)
                {
                    _itemPedidoRepository.Create(new ItemPedido
                    {
                        Id = Guid.NewGuid(),
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade,
                        PedidoId = pedido.Id
                    });
                }

                return Ok(new { Mensagem = "Pedido realizado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //capturar o email do cliente autenticado, este email está gravado
                //no TOKEN que o cliente enviou para acessar este serviço
                var email = User.Identity.Name;

                //consultar no repositorio os dados do cliente atraves do email
                var cliente = _clienteRepository.Get(email);

                var pedidos = new List<PedidoConsultaModel>();

                //consultar todos os pedidos do cliente
                foreach (var item in _pedidoRepository.GetByCliente(cliente.Id))
                {
                    pedidos.Add(new PedidoConsultaModel
                    {
                        Id = item.Id,
                        Data = item.Data,
                        Valor = item.Valor
                    });
                }

                //adicionar o cliente e o endereço dos pedidos
                foreach (var item in pedidos)
                {
                    item.Cliente = new ClienteConsultaModel
                    {
                        Id = cliente.Id,
                        Nome = cliente.Nome,
                        Email = cliente.Email,
                        DataCadastro = cliente.DataCadastro
                    };

                    var endereco = _enderecoRepository.GetByCliente(cliente.Id);

                    item.Cliente.Endereco = new EnderecoConsultaModel
                    {
                        Id = endereco.Id,
                        Logradouro = endereco.Logradouro,
                        Numero = endereco.Numero,
                        Complemento = endereco.Complemento,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade,
                        Estado = endereco.Estado,
                        Cep = endereco.Cep
                    };
                }

                //adicionar os itens do pedido
                foreach (var item in pedidos)
                {
                    var itensPedido = _itemPedidoRepository.GetByPedido(item.Id);

                    var listaItensPedido = new List<ItemPedidoConsultaModel>();
                    foreach (var itemPedido in itensPedido)
                    {
                        var produto = _produtoRepository.GetById(itemPedido.ProdutoId);

                        listaItensPedido.Add(new ItemPedidoConsultaModel
                        {
                            Quantidade = itemPedido.Quantidade,
                            Produto = new ProdutoConsultaModel
                            {
                                Id = produto.Id,
                                Nome = produto.Nome,
                                Descricao = produto.Descricao,
                                Preco = produto.Preco,
                                Foto = produto.Foto
                            }
                        });
                    }

                    item.ItensPedido = listaItensPedido;
                }

                //retornando os pedidos..
                return Ok(pedidos);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}





