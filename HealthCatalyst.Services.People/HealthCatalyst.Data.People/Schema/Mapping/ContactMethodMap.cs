using System.Data.Entity.ModelConfiguration;

namespace HealthCatalyst.Data.People.Schema.Mapping
{
    public class ContactMethodMap : EntityTypeConfiguration<ContactMethod>
    {
        public ContactMethodMap()
        {
            // Primary Key
            HasKey(t => t.ContactMethodId);

            // Properties
            Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(250);

            Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            ToTable("ContactMethod", "hc");
            Property(t => t.ContactMethodId).HasColumnName("ContactMethodId");
            Property(t => t.PersonId).HasColumnName("PersonId");
            Property(t => t.Value).HasColumnName("Value");
            Property(t => t.ContactMethodTypeId).HasColumnName("ContactMethodTypeId");
            Property(t => t.Created).HasColumnName("Created");
            Property(t => t.Updated).HasColumnName("Updated");
            Property(t => t.RowVersion).HasColumnName("RowVersion");

            // Relationships
            HasRequired(t => t.ContactMethodType)
                .WithMany(t => t.ContactMethods)
                .HasForeignKey(d => d.ContactMethodTypeId);
            HasRequired(t => t.Person)
                .WithMany(t => t.ContactMethods)
                .HasForeignKey(d => d.PersonId);
        }
    }
}
