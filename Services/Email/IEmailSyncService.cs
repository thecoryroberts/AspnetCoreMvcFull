namespace AspnetCoreMvcFull.Services.Email;

public interface IEmailSyncService
{
    Task SyncAccountAsync(int emailAccountId, CancellationToken cancellationToken = default);
}
