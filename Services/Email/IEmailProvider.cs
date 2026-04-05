using AspnetCoreMvcFull.Models.Email;

namespace AspnetCoreMvcFull.Services.Email;

public interface IEmailProvider
{
    EmailProviderType ProviderType { get; }

    Task<IReadOnlyList<EmailSummaryDto>> GetMessagesAsync(string accountId, string folderId, int take = 50, CancellationToken cancellationToken = default);

    Task<EmailDetailDto?> GetMessageAsync(string accountId, string messageId, CancellationToken cancellationToken = default);

    Task SendAsync(string accountId, SendEmailDto email, CancellationToken cancellationToken = default);

    Task SyncAsync(string accountId, CancellationToken cancellationToken = default);
}
