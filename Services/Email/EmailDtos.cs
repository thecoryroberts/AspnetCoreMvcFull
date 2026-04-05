namespace AspnetCoreMvcFull.Services.Email;

public sealed class EmailSummaryDto
{
    public string MessageId { get; set; } = string.Empty;
    public string ThreadId { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string FromDisplay { get; set; } = string.Empty;
    public DateTimeOffset ReceivedAt { get; set; }
    public bool IsRead { get; set; }
}

public sealed class EmailDetailDto
{
    public string MessageId { get; set; } = string.Empty;
    public string ThreadId { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public string FromEmail { get; set; } = string.Empty;
    public string BodyHtml { get; set; } = string.Empty;
    public string BodyText { get; set; } = string.Empty;
    public DateTimeOffset ReceivedAt { get; set; }
    public IReadOnlyList<EmailAddressDto> To { get; set; } = Array.Empty<EmailAddressDto>();
}

public sealed class EmailAddressDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public sealed class SendEmailDto
{
    public IReadOnlyList<string> To { get; set; } = Array.Empty<string>();
    public string Subject { get; set; } = string.Empty;
    public string BodyHtml { get; set; } = string.Empty;
    public string BodyText { get; set; } = string.Empty;
}
