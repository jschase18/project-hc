using System.Data.Entity.ModelConfiguration;

namespace HealthCatalyst.Data.People.Schema.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            HasKey(t => t.AddressId);

            // Properties
            Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Address2)
                .HasMaxLength(100);

            Property(t => t.City)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            ToTable("Address", "hc");
            Property(t => t.AddressId).HasColumnName("AddressId");
            Property(t => t.PersonId).HasColumnName("PersonId");
            Property(t => t.Address1).HasColumnName("Address1");
            Property(t => t.Address2).HasColumnName("Address2");
            Property(t => t.City).HasColumnName("City");
            Property(t => t.StateId).HasColumnName("StateId");
            Property(t => t.PostalCode).HasColumnName("PostalCode");
            Property(t => t.Created).HasColumnName("Created");
            Property(t => t.Updated).HasColumnName("Updated");
            Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            HasRequired(t => t.State)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.StateId);
            HasRequired(t => t.Person)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.PersonId);
        }
    }
}
