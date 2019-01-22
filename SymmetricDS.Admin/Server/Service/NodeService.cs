using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shengtai.Data;
using Shengtai.Web;
using Shengtai.Web.Telerik;
using SymmetricDS.Admin.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SymmetricDS.Admin.Server.Service
{
    public class NodeService : Repository<ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>,
        IApiService<int, NodeViewModel, Node, ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>, INodeService
    {
        private readonly ILogger<NodeService> logger;

        public NodeService(ILogger<NodeService> logger) : base()
        {
            this.logger = logger;
        }

        public async Task<bool> CreateAsync(NodeViewModel model, IDataSource dataSource)
        {
            var node = new Node
            {
                NodeGroupId = model.NodeGroup.Id.Value,
                DatabaseHost = model.DatabaseHost,
                DatabaseName = model.DatabaseName,
                DatabaseUser = model.DatabaseUser,
                DatabasePassword = model.DatabasePassword,
                SyncUrlPort = model.SyncUrlPort,
                ExternalId = model.ExternalId,
                JobPurgePeriodTimeMs = model.JobPurgePeriodTimeMs,
                JobRoutingPeriodTimeMs = model.JobRoutingPeriodTimeMs,
                JobPushPeriodTimeMs = model.JobPushPeriodTimeMs,
                JobPullPeriodTimeMs = model.JobPullPeriodTimeMs,
                InitialLoadCreateFirst = model.InitialLoadCreateFirst,
                NodePassword = model.NodePassword,
                Version = model.Version
            };
            if (Enum.TryParse(model.DatabaseType.Value, out Databases database))
                node.DatabaseType = database;

            await this.DbContext.Node.AddAsync(node);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                model.Id = node.Id;
                result = true;
            }
            catch (Exception e)
            {
                this.logger.LogCritical(e.Message);
            }

            return result;
        }

        public async Task<bool?> DestroyAsync(int key)
        {
            var node = await this.ReadAsync(key);
            if (node == null)
                return null;

            this.DbContext.Node.Remove(node);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                result = true;
            }
            catch { }

            return result;
        }

        public ICollection<NodeViewModel> Read(IFilterInfoCollection serverFiltering)
        {
            ICollection<NodeViewModel> nodes = new List<NodeViewModel>();

            if (serverFiltering != null)
            {
                var filter = serverFiltering.FilterCollection.SingleOrDefault(f => f.Field == "Id");
                int nodeGroupId = Convert.ToInt32(filter.Value);

                var dataCollection = this.DbContext.Node.Include("NodeGroup").Where(n => n.NodeGroupId == nodeGroupId).Select(n => n).ToList();
                foreach (var data in dataCollection)
                    nodes.Add(NodeViewModel.NewInstance(data));
            }

            return nodes;
        }

        public async Task<Node> ReadAsync(int key)
        {
            return await this.DbContext.Node.SingleOrDefaultAsync(n => n.Id == key);
        }

        public Task<IDataSourceResponse<NodeViewModel>> ReadAsync(IDataSourceRequest request)
        {
            var responseData = this.DbContext.Node.Include("NodeGroup").Select(n => n);

            if (request.ServerFiltering != null)
            {
                var filter = request.ServerFiltering.FilterCollection.SingleOrDefault(f => f.Field == "NodeGroupId");
                int nodeGroupId = Convert.ToInt32(filter.Value);
                responseData = responseData.Where(n => n.NodeGroupId == nodeGroupId);
            }

            IDataSourceResponse<NodeViewModel> response = new DataSourceResponse<NodeViewModel> { TotalRowCount = responseData.Count() };

            if (request.ServerPaging != null)
            {
                int skip = Math.Max(request.ServerPaging.PageSize * (request.ServerPaging.Page - 1), 0);
                responseData = responseData.OrderBy(p => p.Id).Skip(skip).Take(request.ServerPaging.PageSize);
            }

            var dataCollection = responseData.ToList();
            foreach (var data in dataCollection)
                response.DataCollection.Add(NodeViewModel.NewInstance(data));

            return Task.FromResult(response);
        }

        public async Task<bool?> UpdateAsync(int key, NodeViewModel model, IDataSource dataSource)
        {
            var node = await this.ReadAsync(key);
            if (node == null)
                return null;

            if (Enum.TryParse(model.DatabaseType.Value, out Databases database))
                node.DatabaseType = database;

            node.DatabaseHost = model.DatabaseHost;
            node.DatabaseName = model.DatabaseName;
            node.DatabasePassword = model.DatabasePassword;
            node.SyncUrlPort = model.SyncUrlPort;
            node.ExternalId = model.ExternalId;
            node.JobPurgePeriodTimeMs = model.JobPurgePeriodTimeMs;
            node.JobRoutingPeriodTimeMs = model.JobRoutingPeriodTimeMs;
            node.JobPushPeriodTimeMs = model.JobPushPeriodTimeMs;
            node.JobPullPeriodTimeMs = model.JobPullPeriodTimeMs;
            node.InitialLoadCreateFirst = model.InitialLoadCreateFirst;
            node.NodePassword = model.NodePassword;
            node.Version = model.Version;

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