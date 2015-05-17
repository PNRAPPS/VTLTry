using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class PostalCodeMap : EntityTypeConfiguration<PostalCode>
    {
        public PostalCodeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OriginCountry)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.OriginPostalCodeMin)
                .HasMaxLength(10);

            this.Property(t => t.OriginPostalCodeMax)
                .HasMaxLength(10);

            this.Property(t => t.DestinationCountry)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.DestinationPostalCodeMin)
                .HasMaxLength(10);

            this.Property(t => t.DestinationPostalCodeMax)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PostalCodes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OriginCountry).HasColumnName("OriginCountry");
            this.Property(t => t.OriginPostalCodeMin).HasColumnName("OriginPostalCodeMin");
            this.Property(t => t.OriginPostalCodeMax).HasColumnName("OriginPostalCodeMax");
            this.Property(t => t.DestinationCountry).HasColumnName("DestinationCountry");
            this.Property(t => t.DestinationPostalCodeMin).HasColumnName("DestinationPostalCodeMin");
            this.Property(t => t.DestinationPostalCodeMax).HasColumnName("DestinationPostalCodeMax");
        }
    }
}
