using Microsoft.EntityFrameworkCore;
using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Persistence.EFConfiguration
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
        : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Payment>()
                   .Property(p => p.PaymentId)
                   .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Entity<Payment>()
                   .Property(p => p.CardHolderName)
                   .HasMaxLength(60);

            builder.Entity<Payment>()
                   .Property(p => p.CardNumber)
                   .HasMaxLength(16);

            builder.Entity<Payment>()
                   .Property(p => p.Currency)
                   .HasMaxLength(3);

            builder.Entity<Payment>()
                   .Property(p => p.Cvv)
                   .HasMaxLength(3);

            builder.Entity<Payment>()
                  .Property(p => p.ExpiryMonth)
                  .HasMaxLength(2);

            builder.Entity<Payment>()
                  .Property(p => p.ExpiryYear)
                  .HasMaxLength(2);

            builder.Entity<Merchant>()
                  .Property(p => p.MerchantId)
                  .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Entity<Payment>()
                   .HasOne(s => s.Merchant)
                   .WithMany(g => g.Payments)
                   .HasForeignKey(s => s.MerchantId);

            builder.Entity<Merchant>()
                   .HasData(
                      new Merchant
                      {
                          MerchantId = Guid.NewGuid(),
                          MerchantName = "Apple",
                          AcquirerBank = "BNF",
                          Description = "Online shop for Mac",
                          MerchantIdentificationNumber = Guid.NewGuid().ToString(),
                      },
                      new Merchant
                      {
                          MerchantId = Guid.NewGuid(),
                          MerchantName = "Amazon",
                          AcquirerBank = "BOV",
                          Description = "Online shop for all Items",
                          MerchantIdentificationNumber = Guid.NewGuid().ToString(),
                      });
        }
    }
}
