using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shengtai.Data;
using Shengtai.Web;
using Shengtai.Web.Telerik;
using Shengtai.Web.Telerik.Mvc;
using SymmetricDS.Admin.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.Server.Service
{
    public class TriggerService : Repository<ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>,
        IApiService<int, TriggerViewModel, Trigger, ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>, ITriggerService
    {
        public TriggerService(IOptions<AppSettings> options, ServerDbContext dbContext, IClient client) : base(options.Value, dbContext, client)
        {
        }

        public async Task<bool> CreateAsync(TriggerViewModel model, IDataSource dataSource)
        {
            var trigger = new Trigger
            {
                ChannelId = model.Channel.Id.Value,
                TriggerId = model.TriggerId,
                SourceTableName = model.SourceTableName
            };
            await this.DbContext.Trigger.AddAsync(trigger);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                model.Id = trigger.Id;
                result = true;
            }
            catch { }

            return result;
        }

        public async Task<bool?> DestroyAsync(int key)
        {
            var trigger = await this.ReadAsync(key);
            if (trigger == null)
                return null;

            this.DbContext.Trigger.Remove(trigger);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                result = true;
            }
            catch { }

            return result;
        }

        public ICollection<TriggerViewModel> Read(IFilterInfoCollection serverFiltering)
        {
            ICollection<TriggerViewModel> triggers = new List<TriggerViewModel>();

            if (serverFiltering != null)
            {
                var filter = serverFiltering.FilterCollection.SingleOrDefault(f => f.Field == "Id");
                int channelId = Convert.ToInt32(filter.Value);

                var dataCollection = this.DbContext.Trigger.Include("Channel").Where(t => t.ChannelId == channelId).Select(t => t).ToList();
                foreach (var data in dataCollection)
                    triggers.Add(TriggerViewModel.NewInstance(data));
            }

            return triggers;
        }

        public async Task<Trigger> ReadAsync(int key)
        {
            return await this.DbContext.Trigger.SingleOrDefaultAsync(p => p.Id == key);
        }

        public Task<IDataSourceResponse<TriggerViewModel>> ReadAsync(IDataSourceRequest request)
        {
            var responseData = this.DbContext.Trigger.Include("Channel").Select(t => t);

            if (request.ServerFiltering != null)
            {
                var filter = request.ServerFiltering.FilterCollection.SingleOrDefault(f => f.Field == "ChannelId");
                int channelId = Convert.ToInt32(filter.Value);
                responseData = responseData.Where(t => t.ChannelId == channelId);
            }

            IDataSourceResponse<TriggerViewModel> response = new DataSourceResponse<TriggerViewModel> { TotalRowCount = responseData.Count() };

            if (request.ServerPaging != null)
            {
                int skip = Math.Max(request.ServerPaging.PageSize * (request.ServerPaging.Page - 1), 0);
                responseData = responseData.OrderBy(p => p.Id).Skip(skip).Take(request.ServerPaging.PageSize);
            }

            var dataCollection = responseData.ToList();
            foreach (var data in dataCollection)
                response.DataCollection.Add(TriggerViewModel.NewInstance(data));

            return Task.FromResult(response);
        }

        public async Task<bool?> UpdateAsync(int key, TriggerViewModel model, IDataSource dataSource)
        {
            var trigger = await this.ReadAsync(key);
            if (trigger == null)
                return null;

            trigger.TriggerId = model.TriggerId;
            trigger.SourceTableName = model.SourceTableName;

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                result = true;
            }
            catch { }

            return result;
        }
    }
}