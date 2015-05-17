using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vital.Data.Models.Mapping
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.NewsTitle)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.NewsDate).IsRequired();

            this.Property(t => t.NewsCaption)
                .HasMaxLength(100);

            this.Property(t => t.NewsContent).IsMaxLength();

            this.Property(t => t.DateCreated);

          

            // Table & Column Mappings
            this.ToTable("News");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.NewsTitle).HasColumnName("NewsTitle");
            this.Property(t => t.NewsDate).HasColumnName("NewsDate");
            this.Property(t => t.NewsCaption).HasColumnName("NewsCaption");
            this.Property(t => t.NewsContent).HasColumnName("NewsContent");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");

         
        }
    }
}
