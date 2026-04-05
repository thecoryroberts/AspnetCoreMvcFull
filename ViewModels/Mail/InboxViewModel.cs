namespace AspnetCoreMvcFull.ViewModels.Mail;

public sealed class InboxViewModel
{
    public string AccountDisplayName { get; set; } = string.Empty;
    public string FolderName { get; set; } = "Inbox";
    public IReadOnlyList<InboxMessageItemViewModel> Messages { get; set; } = Array.Empty<InboxMessageItemViewModel>();
}

public sealed class InboxMessageItemViewModel
{
    public string MessageId { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string FromDisplay { get; set; } = string.Empty;
    public DateTimeOffset ReceivedAt { get; set; }
    public bool IsRead { get; set; }
}
