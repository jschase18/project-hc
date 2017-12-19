using System.Data.Entity.ModelConfiguration;

namespace HealthCatalyst.Data.People.Schema.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            HasKey(t => t.PersonId);

            // Properties
            Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.ProfilePictureUrl)
                .IsRequired()
                .HasMaxLength(250);

            Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            ToTable("Person", "hc");
            Property(t => t.PersonId).HasColumnName("PersonId");
            Property(t => t.FirstName).HasColumnName("FirstName");
            Property(t => t.LastName).HasColumnName("LastName");
            Property(t => t.LastName).HasColumnName("LastName");
            Property(t => t.Age).HasColumnName("Age");
            Property(t => t.ProfilePictureUrl).HasColumnName("ProfilePictureUrl");
            Property(t => t.Created).HasColumnName("Created");
            Property(t => t.Updated).HasColumnName("Updated");
            Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}
