namespace Bookstore.Infrastructure.Entity
{
    using System;

    /// <summary>
    /// Core of entities of EF
    /// </summary>
    public interface IEntityCore
    {
        /// <summary>
        /// Primary key
        /// </summary>
        Guid Id { get; set; }
    }
}
