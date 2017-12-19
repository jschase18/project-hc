using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthCatalyst.Data.People.Schema.Mapping
{
    public class ContactMethodTypeMap : EntityTypeConfiguration<ContactMethodType>
    {
        public ContactMethodTypeMap()
        {
            // Primary Key
            HasKey(t => t.ContactMethodTypeId);

            // Properties
            Property(t => t.ContactMethodTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            ToTable("ContactMethodType", "catalog");
            Property(t => t.ContactMethodTypeId).HasColumnName("ContactMethodTypeId");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}
