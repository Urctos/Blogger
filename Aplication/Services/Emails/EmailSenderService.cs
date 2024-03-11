using Application.Interfaces;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;

namespace Application.Services.Emails
{
    public class EmailSenderService : IEmailSenderService

    {
        private readonly IFluentEmail _email;
        private readonly ILogger _Logger;
        public EmailSenderService(IFluentEmail email, ILogger<EmailSenderService> Logger)
        {
            _email = email;
            _Logger = Logger;
        }

        public async Task<bool> Send(string to, string subject)
        {
            var result = await _email.To(to)
                .Subject(subject)
                .SendAsync();

            if(!result.Successful)
            {
                _Logger.LogError("Faild to send email. \n{Errors}", string.Join(Environment.NewLine, result.ErrorMessages));
            }

            return result.Successful;
        }
    }
}
