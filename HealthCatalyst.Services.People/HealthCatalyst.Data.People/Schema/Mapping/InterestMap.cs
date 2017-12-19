using System.Data.Entity.ModelConfiguration;

namespace HealthCatalyst.Data.People.Schema.Mapping
{
    public class InterestMap : EntityTypeConfiguration<Interest>
    {
        public InterestMap()
        {
            // Primary Key
            HasKey(t => t.InterestId);

            // Properties
            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(250);

            Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            ToTable("Interest", "hc");
            Property(t => t.InterestId).HasColumnName("InterestId");
            Property(t => t.PersonId).HasColumnName("PersonId");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Created).HasColumnName("Created");
            Property(t => t.Updated).HasColumnName("Updated");
            Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            HasRequired(t => t.Person)
                .WithMany(t => t.Interests)
                .HasForeignKey(d => d.PersonId);
        }
    }
}
