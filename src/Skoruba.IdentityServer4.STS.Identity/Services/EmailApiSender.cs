using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Skoruba.IdentityServer4.STS.Identity.Configuration;

namespace Skoruba.IdentityServer4.STS.Identity.Services
{
    public class EmailApiSender : IEmailSender
    {
        private readonly EmailApiConfiguration _configuration;
        private readonly ILogger<EmailApiSender> _logger;

        public EmailApiSender(EmailApiConfiguration configuration, ILogger<EmailApiSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation($"Email: {email}, subject: {subject}, message: {htmlMessage}");

            using (var client = new HttpClient())
            {
                var values = new StringContent(JsonConvert.SerializeObject(new
                {
                    SendTo = email,
                    Subject = subject,
                    Body = htmlMessage,
                    Password = _configuration.Password
                }), Encoding.UTF8, "application/json");

                var response = client.PostAsync(_configuration.Url, values).GetAwaiter().GetResult();

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    _logger.LogError($"Exception {e} during sending email: {email}, subject: {subject}");
                    throw;
                }
            }

            return Task.CompletedTask;
        }
    }
}
