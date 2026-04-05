using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.Email;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Services.Email;

public sealed class EmailSyncService : IEmailSyncService
{
    private readonly AspnetCoreMvcFullContext _dbContext;
    private readonly IReadOnlyDictionary<EmailProviderType, IEmailProvider> _providers;

    public EmailSyncService(AspnetCoreMvcFullContext dbContext, IEnumerable<IEmailProvider> providers)
    {
        _dbContext = dbContext;
        _providers = providers.ToDictionary(provider => provider.ProviderType);
    }

    public async Task SyncAccountAsync(int emailAccountId, CancellationToken cancellationToken = default)
    {
        var account = await _dbContext.EmailAccounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == emailAccountId, cancellationToken);

        if (account is null)
        {
            return;
        }

        if (!_providers.TryGetValue(account.Provider, out var provider))
        {
            return;
        }

        await provider.SyncAsync(account.ExternalAccountId, cancellationToken);
    }
}
