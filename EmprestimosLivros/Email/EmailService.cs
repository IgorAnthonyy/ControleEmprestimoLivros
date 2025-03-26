using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace EmprestimosLivros.Email
{
    public class EmailService
    {
        public async Task EnviarEmailAsync(string destinatario, string assunto, string mensagem)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Biblioteca", "igor.maciel@sptech.school"));
            email.To.Add(new MailboxAddress("", destinatario));
            email.Subject = assunto;

            email.Body = new TextPart("plain")
            {
                Text = mensagem
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("igor.maciel@sptech.school", "#Gf37620373888");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
