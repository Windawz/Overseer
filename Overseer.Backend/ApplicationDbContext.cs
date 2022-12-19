﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using Overseer.Data;
using Overseer.Data.Auth;

namespace Overseer.Backend;
public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    [AllowNull]
    public DbSet<Account> Accounts { get; set; }
    [AllowNull]
    public DbSet<Session> Sessions { get; set; }
    [AllowNull]
    public DbSet<Tax> Taxes { get; set; }
    [AllowNull]
    public DbSet<ServiceKind> ServiceKinds { get; set; }
    [AllowNull]
    public DbSet<Service> Services { get; set; }
    [AllowNull]
    public DbSet<Bank> Banks { get; set; }
    [AllowNull]
    public DbSet<Body> Bodies { get; set; }
    [AllowNull]
    public DbSet<Debt> Debts { get; set; }
    [AllowNull]
    public DbSet<RedemptionAttempt> RedemptionAttempts { get; set; }
    [AllowNull]
    public DbSet<RedemptionConclusion> RedemptionConclusions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter, DateOnlyComparer>();
        configurationBuilder.Properties<AccountKind>().HaveConversion<int>();
        configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}