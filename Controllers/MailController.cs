using AspnetCoreMvcFull.Services.Email;
using AspnetCoreMvcFull.ViewModels.Mail;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers;

public class MailController : Controller
{
    private readonly IEmailProvider _gmailProvider;

    public MailController(IEnumerable<IEmailProvider> providers)
    {
        _gmailProvider = providers.First(x => x.ProviderType == Models.Email.EmailProviderType.Gmail);
    }

    public async Task<IActionResult> Inbox(string accountId = "default", string folderId = "INBOX", int take = 50, CancellationToken cancellationToken = default)
    {
        var messages = await _gmailProvider.GetMessagesAsync(accountId, folderId, take, cancellationToken);

        var vm = new InboxViewModel
        {
            AccountDisplayName = accountId,
            FolderName = folderId,
            Messages = messages.Select(x => new InboxMessageItemViewModel
            {
                MessageId = x.MessageId,
                Subject = x.Subject,
                FromDisplay = x.FromDisplay,
                ReceivedAt = x.ReceivedAt,
                IsRead = x.IsRead
            }).ToList()
        };

        return View(vm);
    }

    public async Task<IActionResult> Message(string accountId, string messageId, CancellationToken cancellationToken = default)
    {
        var message = await _gmailProvider.GetMessageAsync(accountId, messageId, cancellationToken);

        if (message is null)
        {
            return NotFound();
        }

        var vm = new MessageDetailViewModel
        {
            MessageId = message.MessageId,
            Subject = message.Subject,
            From = $"{message.FromName} <{message.FromEmail}>",
            BodyHtml = message.BodyHtml,
            BodyText = message.BodyText,
            ReceivedAt = message.ReceivedAt
        };

        return View(vm);
    }

    [HttpGet]
    public IActionResult Compose(string accountId = "default")
        => View(new ComposeMessageViewModel { AccountId = accountId });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Compose(ComposeMessageViewModel vm, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        var sendEmail = new SendEmailDto
        {
            To = vm.To.Split(';', ',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries),
            Subject = vm.Subject,
            BodyHtml = vm.BodyHtml,
            BodyText = vm.BodyText
        };

        await _gmailProvider.SendAsync(vm.AccountId, sendEmail, cancellationToken);

        TempData["MailNotice"] = "Message queued for provider delivery.";

        return RedirectToAction(nameof(Inbox), new { accountId = vm.AccountId });
    }
}
