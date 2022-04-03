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
                    Id = new Guid("BF57AB6D-FD05-4B64-A878-3867C90F6FAD"),
                    Name = "Anthony",
                    LastName = "Stark",
                    Currency_ISO = "USD"
                },
                new User
                {
                    Id = new Guid("C45F61DF-73B5-4D23-991A-29E513F7DA4F"),
                    Name = "Romanova ",
                    LastName = "Natasha ",
                    Currency_ISO = "RUB"
                });
        }
    }
}