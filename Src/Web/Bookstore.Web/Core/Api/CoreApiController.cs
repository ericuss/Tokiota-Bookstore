namespace Bookstore.Web.Core.Api
{
    using Bookstore.Entities.Core;
    using Bookstore.Infrastructure.Business;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class CoreApiController<TEntity> : ControllerBase
        where TEntity : EntityCore
    {
        protected readonly IBusinessCore<TEntity> service;

        public CoreApiController(IBusinessCore<TEntity> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await this.service.GetAsync();
            return this.Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            if (!id.HasValue) return this.BadRequest(new { data = id });

            var entities = await this.service.GetAsync();
            return this.Ok(entities);
        }


        [HttpPost]
        public async Task<IActionResult> Post(TEntity entity)
        {
            if (entity == null) return this.BadRequest(new { data = entity });

            await this.service.CreateAsync(entity);
            await this.service.SaveChangesAsync();

            return this.Ok(new { data = entity });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid? id, [FromBody] TEntity entity)
        {
            if (!id.HasValue || entity == null) return this.BadRequest(new { data = new { id = id, enity = entity } });

            this.service.Update(entity);
            await this.service.SaveChangesAsync();

            return this.Ok(new { data = new { id = id, enity = entity } });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue) return this.BadRequest(new { data = new { id = id } });

            await this.service.RemoveAsync(id.Value);
            await this.service.SaveChangesAsync();

            return this.Ok(new { data = new { id = id } });
        }
    }
}
