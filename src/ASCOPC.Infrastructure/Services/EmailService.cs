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
                var emailMessage = new MailMessage(new MailAddress(message.Email, message.UserName), 
                                   new MailAddress(_configuration["Email:Recipient"]))
                {
                    IsBodyHtml = true,
                    Body = $"<img align='right' src='https://lh3.googleusercontent.com/pw/AM-JKLXeR7TQRtQPvfx4s-h7sJSg3GUYt9AkOYCEi2vcZTneC3x7ye_z3wHO_BV2VUggnsCbuz-9yKYOoMQaW6NyX9NC1sgJdvQKbQ3Ojis1SS2rameaymJ64SdqX406-Q6_HkNspHXmOAWetj65POzitEgG=w500-h600-no?authuser=0' width='35' height='40'>" +
                           $"<h4><strong>I'm</strong>: {message.Email}</h4>" +
                           $"<h4>Message</h3>:<br>{message.TextMessage}",
                    Subject = $"Feedback"
                };

                using var smtpClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_configuration["Email:Name"],
                    _configuration["Email:Password"])
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
