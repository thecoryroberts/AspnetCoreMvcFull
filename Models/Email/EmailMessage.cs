using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Email;

public class EmailMessage
{
    public int Id { get; set; }

    public int EmailAccountId { get; set; }

    public EmailAccount EmailAccount { get; set; } = default!;

    public int? EmailFolderId { get; set; }

    public EmailFolder? EmailFolder { get; set; }

    [Required]
    public string Provider { get; set; } = string.Empty;

    [Required]
    public string ExternalMessageId { get; set; } = string.Empty;

    public string ExternalThreadId { get; set; } = string.Empty;

    [Required]
    public string Subject { get; set; } = string.Empty;

    public string FromName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string FromEmail { get; set; } = string.Empty;

    public string BodyHtml { get; set; } = string.Empty;

    public string BodyText { get; set; } = string.Empty;

    public DateTimeOffset ReceivedAt { get; set; }

    public bool IsRead { get; set; }

    public bool HasAttachments { get; set; }

    public ICollection<EmailRecipient> Recipients { get; set; } = new List<EmailRecipient>();

    public ICollection<EmailAttachment> Attachments { get; set; } = new List<EmailAttachment>();
}
