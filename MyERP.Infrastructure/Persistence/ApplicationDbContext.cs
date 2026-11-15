using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    // ---- Shared (Section 22: one Customers table for POS and CRM) ----
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerContact> CustomerContacts => Set<CustomerContact>();
    public DbSet<CustomerNote> CustomerNotes => Set<CustomerNote>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<CustomerTag> CustomerTags => Set<CustomerTag>();

    // ---- POS ----
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Inventory> Inventory => Set<Inventory>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();
    public DbSet<SaleReturn> SaleReturns => Set<SaleReturn>();
    public DbSet<SaleReturnItem> SaleReturnItems => Set<SaleReturnItem>();

    // ---- CRM ----
    public DbSet<LeadSource> LeadSources => Set<LeadSource>();
    public DbSet<LeadStatus> LeadStatuses => Set<LeadStatus>();
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<OpportunityStage> OpportunityStages => Set<OpportunityStage>();
    public DbSet<Opportunity> Opportunities => Set<Opportunity>();
    public DbSet<ActivityType> ActivityTypes => Set<ActivityType>();
    public DbSet<Activity> Activities => Set<Activity>();
    public DbSet<FollowUp> FollowUps => Set<FollowUp>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        // Section 41: every monetary value is DECIMAL(18,2), every
        // timestamp is DATETIME2. Set once, globally, instead of
        // repeating HasPrecision/HasColumnType on dozens of
        // properties across 23 entity configurations.
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Discovers every IEntityTypeConfiguration<T> in the project
        // — shared, POS, and CRM alike — regardless of which folder
        // it lives in. Adding a future module's entities only means
        // adding more entities + configurations; nothing here has to
        // change.
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
