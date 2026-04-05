using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.ViewModels.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Controllers;

public class MailSettingsController : Controller
{
    private readonly AspnetCoreMvcFullContext _dbContext;

    public MailSettingsController(AspnetCoreMvcFullContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        var accounts = await _dbContext.EmailAccounts
            .AsNoTracking()
            .OrderBy(x => x.EmailAddress)
            .Select(x => new MailAccountSettingsItemViewModel
            {
                Id = x.Id,
                EmailAddress = x.EmailAddress,
                Provider = x.Provider,
                TokenExpiresUtc = x.TokenExpiresUtc
            })
            .ToListAsync(cancellationToken);

        return View(new MailSettingsViewModel { Accounts = accounts });
    }
}
