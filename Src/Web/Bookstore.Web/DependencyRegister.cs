namespace Bookstore.Web
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Register dependencies
    /// </summary> 
    public static class DependencyRegister
    {
        /// <summary>
        /// Register function
        /// </summary>
        /// <param name="services">service collection</param>
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            Business.DependencyRegister.Register(services, configuration);
        }
    }
}
