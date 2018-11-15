using Microsoft.EntityFrameworkCore;
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
    public class ChannelService : NpgsqlRepository<ServerDbContext, ConnectionStrings>, IApiService<int, ChannelViewModel, Channel>, IChannelService
    {
        public ChannelService(IOptions<AppSettings> options, ServerDbContext dbContext) : base(options.Value, dbContext) { }

        public async Task<bool> CreateAsync(ChannelViewModel model, IDataSource dataSource)
        {
            var channel = new Channel
            {
                ChannelId = model.ChannelId,
                Description = model.Description
            };
            await this.DbContext.Channel.AddAsync(channel);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                model.Id = channel.Id;
                result = true;
            }
            catch { }

            return result;
        }

        public async Task<bool?> DestroyAsync(int key)
        {
            var channel = await this.ReadAsync(key);
            if (channel == null)
                return null;

            this.DbContext.Channel.Remove(channel);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                result = true;
            }
            catch { }

            return result;
        }

        public ICollection<ChannelViewModel> Read()
        {
            ICollection<ChannelViewModel> channels = new List<ChannelViewModel>();

            var dataCollection = this.DbContext.Channel.Select(c => c).ToList();
            foreach (var data in dataCollection)
                channels.Add(ChannelViewModel.NewInstance(data).Build(data));

            return channels;
        }

        public async Task<Channel> ReadAsync(int key)
        {
            return await this.DbContext.Channel.SingleOrDefaultAsync(p => p.Id == key);
        }

        public Task<IDataSourceResponse<ChannelViewModel>> ReadAsync(DataSourceRequest request)
        {
            var responseData = this.DbContext.Channel.Select(c => c);

            if (request.ServerFiltering != null) { }

            IDataSourceResponse<ChannelViewModel> response = new DataSourceResponse<ChannelViewModel> { TotalRowCount = responseData.Count() };

            if (request.ServerPaging != null)
            {
                int skip = Math.Max(request.ServerPaging.PageSize * (request.ServerPaging.Page - 1), 0);
                responseData = responseData.OrderBy(p => p.Id).Skip(skip).Take(request.ServerPaging.PageSize);
            }

            var dataCollection = responseData.ToList();
            foreach (var data in dataCollection)
                response.DataCollection.Add(ChannelViewModel.NewInstance(data).Build(data));

            return Task.FromResult(response);
        }

        public async Task<bool?> UpdateAsync(int key, ChannelViewModel model, IDataSource dataSource)
        {
            var channel = await this.ReadAsync(key);
            if (channel == null)
                return null;

            channel.ChannelId = model.ChannelId;
            channel.Description = model.Description;

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
