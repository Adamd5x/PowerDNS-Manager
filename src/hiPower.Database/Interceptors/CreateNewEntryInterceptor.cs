using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using hiPower.Entity;

namespace hiPower.Database.Interceptors;

internal class CreateNewEntryInterceptor: SaveChangesInterceptor
{

    public override InterceptionResult<int> SavingChanges (DbContextEventData eventData, InterceptionResult<int> result)
    {

        var changeTracker = eventData.Context?.ChangeTracker;
        if (changeTracker is not null) 
        { 
            var addedTrackList = changeTracker.Entries<EntityBase>()
                                              .Where(x => x.State == EntityState.Added)
                                              .ToList();

            foreach (var entry in addedTrackList) 
            { 
                bool canUpdateId = entry.State == EntityState.Added;

                if (canUpdateId) {
                    entry.State = EntityState.Added;
                    entry.Property (p => p.Id)
                         .CurrentValue = Guid.NewGuid ().ToString ();
                }
            }
        }

        return base.SavingChanges (eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync (DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        InterceptionResult<int> savingResult = SavingChanges (eventData, result);

        return base.SavingChangesAsync (eventData, savingResult, cancellationToken);
    }
}
