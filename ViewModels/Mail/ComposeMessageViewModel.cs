using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.ViewModels.Mail;

public sealed class ComposeMessageViewModel
{
    [Required]
    public string AccountId { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string To { get; set; } = string.Empty;

    [Required]
    public string Subject { get; set; } = string.Empty;

    public string BodyText { get; set; } = string.Empty;

    public string BodyHtml { get; set; } = string.Empty;
}
