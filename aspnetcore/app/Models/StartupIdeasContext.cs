using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using StartupIdeas.Models.EFCore;

namespace StartupIdeas.Models
{
    public class StartupIdeasContext : DbContext
    {
        public StartupIdeasContext (DbContextOptions<StartupIdeasContext> options)
            : base(options)
        { }

        public DbSet<Idea> Ideas { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateTrackableDateTimes();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateTrackableDateTimes();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateTrackableDateTimes()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTimeOffset.UtcNow;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            trackable.Created = now;
                            trackable.Modified = now;
                            break;

                        case EntityState.Modified:
                            trackable.Modified = now;
                            break;
                    }
                }
            }
        }
    }
}
