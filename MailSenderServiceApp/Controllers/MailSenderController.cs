
using Microsoft.AspNetCore.Mvc;
using MailSenderServiceApp.Models;
using MailSenderServiceApp.Services;

namespace MailSenderServiceApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailSenderController : ControllerBase
{

    private readonly IMailService _mailService;
    public MailSenderController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost("SendMail")]
    public async Task<IActionResult> SendMail(MailRequest mailRequest)
    {

        try
        {
            await _mailService.SendEmailAsync(mailRequest);

            return Ok("Mail was Sent sucessfuly!");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

}