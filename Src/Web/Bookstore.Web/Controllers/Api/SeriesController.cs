namespace Bookstore.Web.Controllers.Api
{
    using Bookstore.Entities;
    using Bookstore.Infrastructure.Business;
    using Bookstore.Web.Core.Api;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class SeriesController : CoreApiController<Serie>
    {

        public SeriesController(IBusinessCore<Serie> service)
            : base(service)
        {
        }
    }
}
