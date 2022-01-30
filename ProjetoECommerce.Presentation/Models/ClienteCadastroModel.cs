using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoECommerce.Presentation.Models
{
    public class ClienteCadastroModel
    {
        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do cliente.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a senha do cliente.")]
        public string SenhaConfirmacao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o logradouro do cliente.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Por favor, informe o complemento do endereço do cliente.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o numero do endereço do cliente.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Por favor, informe o bairro do endereço do cliente.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Por favor, informe a cidade do endereço do cliente.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estado do endereço do cliente.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cep do endereço do cliente.")]
        public string Cep { get; set; }
    }
}
