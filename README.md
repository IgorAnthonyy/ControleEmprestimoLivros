### ControleEmprestimo

### Descrição
O **ControleEmprestimo** é um sistema desenvolvido em **C# .NET** com **ASP.NET Core** para gerenciar o empréstimo de livros. O sistema permite o cadastro de livros, usuários e o controle das datas de empréstimo e devolução.

### Requisitos para Execução
Para que o projeto funcione corretamente, é necessário:
- Ter o **.NET SDK** instalado (versão 6.0 ou superior recomendada).
- Configurar as informações do banco de dados.
- Atualizar as credenciais de e-mail no **EmailService**.

### Configuração do Banco de Dados
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```

### Configuração do EmailService
```csharp
 email.From.Add(new MailboxAddress("Biblioteca", "seuemail@seuemail.com"));
 await smtp.AuthenticateAsync("seuemail@seuemail.com", "suasenha");
```
**Importante:** Se estiver usando Gmail, habilite o acesso a apps menos seguros ou configure um App Password.

### Como Executar o Projeto
```sh
dotnet run
```
O projeto será iniciado e estará acessível na URL indicada no terminal.

### Tecnologias Utilizadas
- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- SMTP para envio de e-mails

### Contato
Caso tenha dúvidas ou sugestões, entre em contato pelo e-mail **seuemail@dominio.com**.

---

Agora o seu sistema está pronto para rodar! Qualquer problema, verifique se as configurações estão corretas. 🚀
