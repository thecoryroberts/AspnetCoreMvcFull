using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Email;

public class EmailFolder
{
    public int Id { get; set; }

    public int EmailAccountId { get; set; }

    public EmailAccount EmailAccount { get; set; } = default!;

    [Required]
    public string FolderName { get; set; } = string.Empty;

    [Required]
    public string ExternalFolderId { get; set; } = string.Empty;

    public bool IsSystemFolder { get; set; }

    public ICollection<EmailMessage> Messages { get; set; } = new List<EmailMessage>();
}
