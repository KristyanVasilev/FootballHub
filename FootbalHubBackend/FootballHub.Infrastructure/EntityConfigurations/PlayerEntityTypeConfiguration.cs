namespace FootallHub.Infrastructure.EntityConfigurations
{
    using FootballHub.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.LastName)
                  .IsRequired()
                  .HasMaxLength(50);


            builder.Property(p => p.Nationality)
                  .IsRequired()
                  .HasMaxLength(50);
        }
    }
}
