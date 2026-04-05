using AspnetCoreMvcFull.Models.Email;

namespace AspnetCoreMvcFull.Services.Email;

public sealed class GmailEmailProvider : IEmailProvider
{
    public EmailProviderType ProviderType => EmailProviderType.Gmail;

    public Task<IReadOnlyList<EmailSummaryDto>> GetMessagesAsync(string accountId, string folderId, int take = 50, CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyList<EmailSummaryDto>>(Array.Empty<EmailSummaryDto>());

    public Task<EmailDetailDto?> GetMessageAsync(string accountId, string messageId, CancellationToken cancellationToken = default)
        => Task.FromResult<EmailDetailDto?>(null);

    public Task SendAsync(string accountId, SendEmailDto email, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    public Task SyncAsync(string accountId, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
