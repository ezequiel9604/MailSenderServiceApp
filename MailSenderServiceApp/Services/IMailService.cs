
using MailSenderServiceApp.Models;

namespace MailSenderServiceApp.Services;

public interface IMailService
{

    Task SendEmailAsync(MailRequest mailRequest);

}
