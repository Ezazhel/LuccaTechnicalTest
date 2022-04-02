using Lucca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable(nameof(Expense));

            builder.HasKey(expense => expense.Id);

            builder.Property(expense => expense.Id).ValueGeneratedOnAdd();

            builder.Property(expense => expense.Amount).HasColumnType("decimal(5,2)");

            builder.Property(expense => expense.Comment).IsRequired();
        }
    }
}