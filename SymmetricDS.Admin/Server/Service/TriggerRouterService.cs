using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shengtai;
using Shengtai.Options;
using Shengtai.Web.Telerik;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.Server.Service
{
    public class TriggerRouterService : NpgsqlRepository<ServerDbContext, ConnectionStrings>, IApiService<string, TriggerRouterViewModel, TriggerRouter>
    {
        private readonly ILogger<TriggerRouterService> logger;
        public TriggerRouterService(IOptions<AppSettings> options, ServerDbContext dbContext, ILogger<TriggerRouterService> logger) : base(options.Value, dbContext)
        {
            this.logger = logger;
        }

        public async Task<bool> CreateAsync(TriggerRouterViewModel model, IDataSource dataSource)
        {
            var triggerRouter = new TriggerRouter
            {
                TriggerId = model.Trigger.Id.Value,
                RouterId = model.Router.Id.Value
            };
            await this.DbContext.TriggerRouter.AddAsync(triggerRouter);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                model.Id = model.Id;
                result = true;
            }
            catch { }

            return result;
        }

        public async Task<bool?> DestroyAsync(string key)
        {
            var triggerRouter = await this.ReadAsync(key);
            if (triggerRouter == null)
                return null;

            this.DbContext.TriggerRouter.Remove(triggerRouter);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                result = true;
            }
            catch { }

            return result;
        }

        public async Task<TriggerRouter> ReadAsync(string key)
        {
            var values = key.Split('_');
            var triggerId = Convert.ToInt32(values[0]);
            var routerId = Convert.ToInt32(values[1]);

            return await this.DbContext.TriggerRouter.SingleOrDefaultAsync(tr => tr.TriggerId == triggerId && tr.RouterId == routerId);
        }

        public Task<IDataSourceResponse<TriggerRouterViewModel>> ReadAsync(DataSourceRequest request)
        {
            var responseData = this.DbContext.TriggerRouter
                .Include("Router").Include("Router.Project").Include("Router.SourceNodeGroup").Include("Router.SourceNodeGroup.Project").Include("Router.TargetNodeGroup").Include("Router.TargetNodeGroup.Project")
                .Include("Trigger").Include("Trigger.Channel")
                .Select(tr => tr);

            if (request.ServerFiltering != null)
            {
                var filter = request.ServerFiltering.FilterCollection.SingleOrDefault(f => f.Field == "RouterId");
                int routerId = Convert.ToInt32(filter.Value);
                responseData = responseData.Where(tr => tr.RouterId == routerId);
            }

            IDataSourceResponse<TriggerRouterViewModel> response = new DataSourceResponse<TriggerRouterViewModel> { TotalRowCount = responseData.Count() };

            if (request.ServerPaging != null)
            {
                int skip = Math.Max(request.ServerPaging.PageSize * (request.ServerPaging.Page - 1), 0);
                responseData = responseData.OrderBy(tr => tr.TriggerId).ThenBy(tr => tr.RouterId).Skip(skip).Take(request.ServerPaging.PageSize);
            }

            var dataCollection = responseData.ToList();
            foreach (var data in dataCollection)
                response.DataCollection.Add(TriggerRouterViewModel.NewInstance(data));

            return Task.FromResult(response);
        }

        public Task<bool?> UpdateAsync(string key, TriggerRouterViewModel model, IDataSource dataSource)
        {
            throw new NotImplementedException();
        }
    }
}
