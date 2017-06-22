namespace Bookstore.Web.Controllers.Api
{
    using Bookstore.Entities;
    using Bookstore.Infrastructure.Business;
    using Bookstore.Web.Core.Api;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class PublishersController : CoreApiController<Publisher>
    {
        public PublishersController(IBusinessCore<Publisher> service)
            : base(service)
        {
        }
    }
}
