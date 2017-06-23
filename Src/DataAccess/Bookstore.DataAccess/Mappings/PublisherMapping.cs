namespace Bookstore.DataAccess.Mappings
{
    using Bookstore.DataAccess.Configuration;
    using Bookstore.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Mapping configuration for publisher entity
    /// </summary>
    public class PublisherMapping : EntityMappingConfiguration<Publisher>
    {
        /// <summary>
        /// Mapp function with configuration
        /// </summary>
        /// <param name="entity">entity builder</param>
        public override void Map(EntityTypeBuilder<Publisher> entity)
        {
            entity.ToTable("Publisher");
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Books)
                    .WithOne(x => x.Publisher)
                    .HasForeignKey(x => x.PublisherId)
                    .IsRequired(false);
        }

        /// <summary>
        /// Generates an instance of class
        /// </summary>
        /// <returns>instance of class</returns>
        public static PublisherMapping Create() => new PublisherMapping();
    }
}
