using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Models.Email;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Data
{
    public class AspnetCoreMvcFullContext : DbContext
    {
        public AspnetCoreMvcFullContext(DbContextOptions<AspnetCoreMvcFullContext> options)
            : base(options)
        {
        }

        public DbSet<Transactions> Transactions { get; set; } = default!;
        public DbSet<EmailAccount> EmailAccounts { get; set; } = default!;
        public DbSet<EmailFolder> EmailFolders { get; set; } = default!;
        public DbSet<EmailMessage> EmailMessages { get; set; } = default!;
        public DbSet<EmailRecipient> EmailRecipients { get; set; } = default!;
        public DbSet<EmailAttachment> EmailAttachments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmailAccount>()
                .HasMany(x => x.Folders)
                .WithOne(x => x.EmailAccount)
                .HasForeignKey(x => x.EmailAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailFolder>()
                .HasMany(x => x.Messages)
                .WithOne(x => x.EmailFolder)
                .HasForeignKey(x => x.EmailFolderId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmailMessage>()
                .HasIndex(x => new { x.EmailAccountId, x.ExternalMessageId })
                .IsUnique();

            modelBuilder.Entity<EmailMessage>()
                .HasMany(x => x.Recipients)
                .WithOne(x => x.EmailMessage)
                .HasForeignKey(x => x.EmailMessageId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmailMessage>()
                .HasMany(x => x.Attachments)
                .WithOne(x => x.EmailMessage)
                .HasForeignKey(x => x.EmailMessageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
