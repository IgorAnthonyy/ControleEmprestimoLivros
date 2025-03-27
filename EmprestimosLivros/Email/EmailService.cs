using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace EmprestimosLivros.Email
{
    public class EmailService
    {
        public async Task EnviarEmailAsync(string destinatario, string assunto, List<string> bodyEmail)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Biblioteca", "igor.maciel@sptech.school"));
            email.To.Add(new MailboxAddress("", destinatario));
            email.Subject = assunto;

            email.Body = new TextPart("html") 
            {
                Text = $@"
                    <html>
                    <body>
                        <h1 style='color: #007bff;'>Olá, {bodyEmail[0]}!</h1>
                        <p>Seu empréstimo do livro <strong>{bodyEmail[1]}</strong> foi realizado com sucesso!</p>
                        <p><strong>Data de empréstimo:</strong> {bodyEmail[2]}</p>
                        <p><strong>Data de devolução:</strong> {bodyEmail[3]}</p>
                        <hr>
                        <p style='font-size: 12px; color: #666;'>Este é um e-mail automático. Não responda.</p>
                    </body>
                    </html>"
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("igor.maciel@sptech.school", "#Gf37620373888");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

    }
}
