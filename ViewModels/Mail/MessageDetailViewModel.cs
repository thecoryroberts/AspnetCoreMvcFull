namespace AspnetCoreMvcFull.ViewModels.Mail;

public sealed class MessageDetailViewModel
{
    public string MessageId { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string BodyHtml { get; set; } = string.Empty;
    public string BodyText { get; set; } = string.Empty;
    public DateTimeOffset ReceivedAt { get; set; }
}
