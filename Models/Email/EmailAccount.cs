using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Email;

public class EmailAccount
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public EmailProviderType Provider { get; set; }

    [Required, EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    public string AccessToken { get; set; } = string.Empty;

    [Required]
    public string RefreshToken { get; set; } = string.Empty;

    public DateTimeOffset TokenExpiresUtc { get; set; }

    public string ExternalAccountId { get; set; } = string.Empty;

    public ICollection<EmailFolder> Folders { get; set; } = new List<EmailFolder>();
}
