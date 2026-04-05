using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Email;

public class EmailRecipient
{
    public int Id { get; set; }

    public int EmailMessageId { get; set; }

    public EmailMessage EmailMessage { get; set; } = default!;

    [Required]
    public string RecipientType { get; set; } = "To";

    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
}
