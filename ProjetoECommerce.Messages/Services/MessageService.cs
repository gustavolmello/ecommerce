using ProjetoECommerce.Messages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoECommerce.Messages.Services
{
    public class MessageService
    {
        public void SendMessage(MessageModel model)
        {
            var conta = "cotiaulasnoreply@gmail.com";
            var senha = "@Admin123456";

            var message = new MailMessage(conta, model.Destinatario);
            message.Subject = model.Assunto;
            message.Body = model.Mensagem;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(conta, senha);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
        }
    }
}