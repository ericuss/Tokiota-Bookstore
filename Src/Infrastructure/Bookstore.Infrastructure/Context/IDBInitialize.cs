namespace Bookstore.Infrastructure.Context
{
    using System.Threading.Tasks;

    /// <summary>
    /// Initialize context
    /// </summary>
    public interface IDBInitialize
    {

        /// <summary>
        /// Initialize function
        /// </summary>
        Task Initialize();
    }
}
