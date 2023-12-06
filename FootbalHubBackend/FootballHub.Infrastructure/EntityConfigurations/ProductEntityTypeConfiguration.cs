namespace FootallHub.Infrastructure.EntityConfigurations
{
    using FootballHub.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.Description)
                  .IsRequired()
                  .HasMaxLength(500);


            builder.Property(p => p.ImageUrl)
                  .IsRequired()
                  .HasMaxLength(500);

            builder.Property(p => p.Price)
             .IsRequired()
             .HasColumnType("decimal(18,2)");
        }
    }
}
