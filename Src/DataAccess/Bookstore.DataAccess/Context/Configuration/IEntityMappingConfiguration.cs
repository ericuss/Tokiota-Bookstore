namespace Bookstore.DataAccess.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Interface of mapping config
    /// </summary>
    public interface IEntityMappingConfiguration
    {
        void Map(ModelBuilder b);
    }

    /// <summary>
    /// Generic interface of mapping config
    /// </summary>
    public interface IEntityMappingConfiguration<T> : IEntityMappingConfiguration where T : class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
