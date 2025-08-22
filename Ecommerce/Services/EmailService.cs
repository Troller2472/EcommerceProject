using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

public class EmailService
{
    private readonly IConfiguration _config;
    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public void SendMail(string to, string subject, string htmlBody)
    {
        var smtpSection = _config.GetSection("Smtp");

        using var client = new SmtpClient(smtpSection["Host"], int.Parse(smtpSection["Port"]))
        {
            Credentials = new NetworkCredential(smtpSection["UserName"], smtpSection["Password"]),
            EnableSsl = bool.Parse(smtpSection["EnableSSL"])
        };

        var mail = new MailMessage
        {
            From = new MailAddress(smtpSection["UserName"], "Sonadezi Shop"),
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true
        };

        mail.To.Add(to);

        client.Send(mail);
    }
}
