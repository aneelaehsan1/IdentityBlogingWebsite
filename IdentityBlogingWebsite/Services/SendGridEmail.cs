using IdentityBlogingWebsite.Helpers;
using IdentityBlogingWebsite.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Http.Headers;

namespace IdentityBlogingWebsite.Services
{
    public class SendGridEmail : ISendGridEmail
    {
        private readonly ILogger<SendGridEmail> _logger;

        public AuthMessageSenderOptions Options { get; set; }
        public SendGridEmail(IOptions<AuthMessageSenderOptions> options, ILogger<SendGridEmail> logger)
        {
            Options = options.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            
            await Execute( subject, message, toEmail);
        }

        //private async Task Execute(string apiKey, string subject, string message, string toEmail)
        //{
        //    var client = new SendGridClient(apiKey);
        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("aneelaahsan44@gmail.com"),
        //        Subject = subject,
        //        PlainTextContent = message,
        //        HtmlContent = message
        //    };
        //    msg.AddTo(new EmailAddress(toEmail));

        //    // Disable click tracking.
        //    // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        //    msg.SetClickTracking(false, false);
        //    var response = await client.SendEmailAsync(msg);
        //    var dummy = response.StatusCode;
        //    var dummy2 = response.Headers;
        //    _logger.LogInformation(response.IsSuccessStatusCode
        //                           ? $"Email to {toEmail} queued successfully!"
        //                           : $"Failure Email to {toEmail}");
        //}
        private async Task Execute( string subject, string message, string toEmail)
        {
           
            var res = "{\"personalizations\": [{\"to\": [{\"email\": \"" + toEmail + "\"}],\"subject\": \"" + subject + "\"}],\"from\": {\"email\": \"from_address@example.com\"}, \"content\": [ {\"type\": \"text/html\",\"value\": \"" + message + "\" }]}";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://rapidprod-sendgrid-v1.p.rapidapi.com/mail/send"),
                Headers =
                {

            { "X-RapidAPI-Key", "4407d98395mshdfe7b518b9f155cp1a092djsnad352c50c809" },
            { "X-RapidAPI-Host", "rapidprod-sendgrid-v1.p.rapidapi.com" },

                },
                //Content = new StringContent(res, Encoding.UTF8, "application/json"),

                Content = new StringContent(res)
                {
                    Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }



            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

            }

        }
    }
}


