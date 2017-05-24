namespace Bookstore.DataAccess.Mappings
{
    using Bookstore.DataAccess.Configuration;
    using Bookstore.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Mapping configuration for author entity
    /// </summary>
    public class AuthorMapping : EntityMappingConfiguration<Author>
    {
        /// <summary>
        /// Mapp function with configuration
        /// </summary>
        /// <param name="entity">entity builder</param>
        public override void Map(EntityTypeBuilder<Author> entity)
        {
            entity.ToTable("Author");
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.Books)
                    .WithOne(x => x.Author)
                    .HasForeignKey(x => x.AuthorId)
                    .IsRequired();
        }

        /// <summary>
        /// Generates an instance of class
        /// </summary>
        /// <returns>instance of class</returns>
        public static AuthorMapping Create() => new AuthorMapping();
    }
}
