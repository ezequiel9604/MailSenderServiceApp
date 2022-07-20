
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using MailSenderServiceApp.Models;
using MailSenderServiceApp.Settings;
using Microsoft.Extensions.Options;

namespace MailSenderServiceApp.Services;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(MailRequest mailRequest)
    {

        try
        {
            var message = new MimeMessage();

            message.Sender = MailboxAddress.Parse(_mailSettings.UserName);
            message.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            message.Subject = mailRequest.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailRequest.Body;
            message.Body = bodyBuilder.ToMessageBody();

            var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
            await smtp.SendAsync(message);

            smtp.Disconnect(true);
            smtp.Dispose();
        }
        catch(ArgumentNullException e)
        {
            throw new ArgumentNullException(nameof(e));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message+"\n"+e.StackTrace);
        }

    }
}

