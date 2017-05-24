namespace Bookstore.DataAccess.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Entity mapping configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> b);

        /// <summary>
        /// Map function to configure
        /// </summary>
        /// <param name="b"></param>
        public void Map(ModelBuilder b)
        {
            Map(b.Entity<T>());
        }
    }
}
