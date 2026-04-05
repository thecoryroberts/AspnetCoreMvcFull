using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Email;

public class EmailAttachment
{
    public int Id { get; set; }

    public int EmailMessageId { get; set; }

    public EmailMessage EmailMessage { get; set; } = default!;

    [Required]
    public string FileName { get; set; } = string.Empty;

    public string MimeType { get; set; } = string.Empty;

    public long SizeBytes { get; set; }

    public string ExternalAttachmentId { get; set; } = string.Empty;
}
