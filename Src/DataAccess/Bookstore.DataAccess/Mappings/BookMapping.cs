namespace Bookstore.DataAccess.Mappings
{
    using Bookstore.DataAccess.Configuration;
    using Bookstore.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Mapping configuration for book entity
    /// </summary>
    public class BookMapping : EntityMappingConfiguration<Book>
    {
        /// <summary>
        /// Mapp function with configuration
        /// </summary>
        /// <param name="entity">entity builder</param>
        public override void Map(EntityTypeBuilder<Book> entity)
        {
            entity.ToTable("Book");
            entity.HasKey(x => x.Id);
        }

        /// <summary>
        /// Generates an instance of class
        /// </summary>
        /// <returns>instance of class</returns>
        public static BookMapping Create() => new BookMapping();
    }
}
