using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HealthCatalyst.Data.People.Schema.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            // Primary Key
            HasKey(t => t.StateId);

            // Properties
            Property(t => t.StateId)
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
            ToTable("State", "catalog");
            Property(t => t.StateId).HasColumnName("StateId");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}
