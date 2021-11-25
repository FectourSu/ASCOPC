using ASCOPC.Domain.Contracts;
using ASCOPC.Shared;
using ASCOPC.Shared.Requests;
using ASOPC.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ASCOPC.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IResult> SendMessage(MessageRequest message)
        {
            var result = OperationResult.CreateBuilder();

            if (message == null)
                return result.AppendError($"{message} is null")
                    .BuildResult();

            try
            {
                var emailMessage = new MailMessage(message.UserName, message.Email)
                {
                    Body = $"<h4>Contact me by email: {message.Email}</h4>{message.TextMessage}",
                    Subject = $"Feedback"
                };

                NetworkCredential nc = new(_configuration["Email:Name"],
                    _configuration["Email:Password"]);

                using var smtpClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 465,
                    UseDefaultCredentials = true,
                    EnableSsl = true,
                    Credentials = nc
                };

                await smtpClient.SendMailAsync(emailMessage)
                    .ConfigureAwait(true);

                smtpClient.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return result.BuildResult();
        }
    }
}
