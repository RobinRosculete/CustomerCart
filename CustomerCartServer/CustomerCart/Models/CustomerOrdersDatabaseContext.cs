﻿using Microsoft.EntityFrameworkCore;


namespace CustomerCartModel;

public partial class CustomerOrdersDatabaseContext : DbContext
{
    public CustomerOrdersDatabaseContext()
    {
    }

    public CustomerOrdersDatabaseContext(DbContextOptions<CustomerOrdersDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json");
        IConfiguration configuration = builder.Build();
        // Handeling Null refrence error
        
        string? connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string is null.");
        var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql");
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
        
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.TotalAmount).HasPrecision(10, 2);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("orders_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
