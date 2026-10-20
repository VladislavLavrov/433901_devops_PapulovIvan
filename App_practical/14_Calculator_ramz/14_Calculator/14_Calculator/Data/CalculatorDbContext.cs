using _14_Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace _14_Calculator.Data;

public class CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : DbContext(options)
{
    public DbSet<CalculationRecord> DataInputVariants => Set<CalculationRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<CalculationRecord>();
        entity.ToTable("DataInputVariants");
        entity.HasKey(x => x.ID_DataInputVariant);
        entity.Property(x => x.ID_DataInputVariant).ValueGeneratedOnAdd();
        entity.Property(x => x.Type_operation).HasMaxLength(20).IsRequired();
        entity.Property(x => x.Operand_1).HasColumnType("double");
        entity.Property(x => x.Operand_2).HasColumnType("double");
        entity.Property(x => x.Result).HasColumnType("double");
        entity.Property(x => x.CreatedAt).HasColumnType("datetime(6)");
    }
}
