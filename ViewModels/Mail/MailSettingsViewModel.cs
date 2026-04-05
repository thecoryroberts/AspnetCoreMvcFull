using AspnetCoreMvcFull.Models.Email;

namespace AspnetCoreMvcFull.ViewModels.Mail;

public sealed class MailSettingsViewModel
{
    public IReadOnlyList<MailAccountSettingsItemViewModel> Accounts { get; set; } = Array.Empty<MailAccountSettingsItemViewModel>();
}

public sealed class MailAccountSettingsItemViewModel
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public EmailProviderType Provider { get; set; }
    public DateTimeOffset TokenExpiresUtc { get; set; }
}
