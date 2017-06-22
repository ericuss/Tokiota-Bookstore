namespace Bookstore.DataAccess.Mappings
{
    using Bookstore.DataAccess.Configuration;
    using Bookstore.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Mapping configuration for serie entity
    /// </summary>
    public class SerieMapping : EntityMappingConfiguration<Serie>
    {
        /// <summary>
        /// Mapp function with configuration
        /// </summary>
        /// <param name="entity">entity builder</param>
        public override void Map(EntityTypeBuilder<Serie> entity)
        {
            entity.ToTable("Serie");
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Books)
                    .WithOne(x => x.Serie)
                    .HasForeignKey(x => x.SerieId)
                    .IsRequired(false);
        }

        /// <summary>
        /// Generates an instance of class
        /// </summary>
        /// <returns>instance of class</returns>
        public static SerieMapping Create() => new SerieMapping();
    }
}
