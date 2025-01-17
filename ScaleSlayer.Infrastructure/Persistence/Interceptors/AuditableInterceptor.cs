﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ScaleSlayer.Application.Contracts.Services;
using ScaleSlayer.Domain.Common.Interfaces;

namespace ScaleSlayer.Infrastructure.Persistence.Interceptors;

public class AuditableInterceptor : SaveChangesInterceptor
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ILoggedInUserService _loggedInUserService;

    public AuditableInterceptor(IDateTimeProvider dateTimeProvider, ILoggedInUserService loggedInUserService)
    {
        _dateTimeProvider = dateTimeProvider;
        _loggedInUserService = loggedInUserService;
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateAuditingProperties(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateAuditingProperties(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    private void UpdateAuditingProperties(DbContext? context)
    {
        if (context is null)
            return;
        foreach (var entry in context.ChangeTracker.Entries<IAuditable>())
        {
            switch (entry.State)
            {
                case (EntityState.Added):
                    entry.Entity.CreatedOn = _dateTimeProvider.Now;
                    entry.Entity.CreatedByUserId = _loggedInUserService.UserId;
                    break;
                case (EntityState.Modified):
                    entry.Entity.LastModifiedOn = _dateTimeProvider.Now;
                    entry.Entity.LastModifiedByUserId = _loggedInUserService.UserId;
                    break;
            }
        }
    }
}