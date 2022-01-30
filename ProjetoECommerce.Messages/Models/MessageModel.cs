using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Messages.Models
{
    public class MessageModel
    {
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}
