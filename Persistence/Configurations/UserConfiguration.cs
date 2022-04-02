using Lucca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.Property(user => user.Name).IsRequired();

            builder.Property(user => user.LastName).IsRequired();

            builder.Property(user => user.Currency_ISO).IsRequired();

            builder.HasMany(user => user.Expenses)
                .WithOne()
                .HasForeignKey(expense => expense.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Anthony",
                    LastName = "Stark",
                    Currency_ISO = "USD"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Romanova ",
                    LastName = "Natasha ",
                    Currency_ISO = "RUB"
                });
        }
    }
}