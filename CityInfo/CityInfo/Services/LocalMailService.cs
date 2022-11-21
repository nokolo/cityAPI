using System;
namespace CityInfo.Services
{
    public class LocalMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettigns:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Subject: {subject}");

            Console.WriteLine($"Subject: {message}");
        }

    }
}

