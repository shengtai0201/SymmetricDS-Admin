using Microsoft.EntityFrameworkCore;
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
    public class NodeGroupService : Repository<ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>,
        IApiService<int, NodeGroupViewModel, NodeGroup, ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>, INodeGroupService
    {
        public NodeGroupService() : base()
        {
        }

        public async Task<bool> CreateAsync(NodeGroupViewModel model, IDataSource dataSource)
        {
            var nodeGroup = new NodeGroup
            {
                ProjectId = model.Project.Id.Value,
                NodeGroupId = model.NodeGroupId,
                Description = model.Description
            };
            await this.DbContext.NodeGroup.AddAsync(nodeGroup);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                model.Id = nodeGroup.Id;
                result = true;
            }
            catch { }

            return result;
        }

        public async Task<bool?> DestroyAsync(int key)
        {
            var nodeGroup = await this.ReadAsync(key);
            if (nodeGroup == null)
                return null;

            this.DbContext.NodeGroup.Remove(nodeGroup);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                result = true;
            }
            catch { }

            return result;
        }

        public ICollection<NodeGroupViewModel> Read(IFilterInfoCollection serverFiltering)
        {
            ICollection<NodeGroupViewModel> nodeGroups = new List<NodeGroupViewModel>();

            if (serverFiltering != null)
            {
                var filter = serverFiltering.FilterCollection.SingleOrDefault(f => f.Field == "Id");
                int projectId = Convert.ToInt32(filter.Value);

                var dataCollection = this.DbContext.NodeGroup.Include("Project").Where(ng => ng.ProjectId == projectId).Select(ng => ng).ToList();
                foreach (var data in dataCollection)
                    nodeGroups.Add(NodeGroupViewModel.NewInstance(data));
            }

            return nodeGroups;
        }

        public async Task<NodeGroup> ReadAsync(int key)
        {
            return await this.DbContext.NodeGroup.SingleOrDefaultAsync(ng => ng.Id == key);
        }

        public Task<IDataSourceResponse<NodeGroupViewModel>> ReadAsync(IDataSourceRequest request)
        {
            var responseData = this.DbContext.NodeGroup.Include("Project").Select(ng => ng);

            if (request.ServerFiltering != null)
            {
                var filter = request.ServerFiltering.FilterCollection.SingleOrDefault(f => f.Field == "ProjectId");
                int projectId = Convert.ToInt32(filter.Value);
                responseData = responseData.Where(ng => ng.ProjectId == projectId);
            }

            IDataSourceResponse<NodeGroupViewModel> response = new DataSourceResponse<NodeGroupViewModel> { TotalRowCount = responseData.Count() };

            if (request.ServerPaging != null)
            {
                int skip = Math.Max(request.ServerPaging.PageSize * (request.ServerPaging.Page - 1), 0);
                responseData = responseData.OrderBy(p => p.Id).Skip(skip).Take(request.ServerPaging.PageSize);
            }

            var dataCollection = responseData.ToList();
            foreach (var data in dataCollection)
                response.DataCollection.Add(NodeGroupViewModel.NewInstance(data));

            return Task.FromResult(response);
        }

        public async Task<bool?> UpdateAsync(int key, NodeGroupViewModel model, IDataSource dataSource)
        {
            var nodeGroup = await this.ReadAsync(key);
            if (nodeGroup == null)
                return null;

            nodeGroup.NodeGroupId = model.NodeGroupId;
            nodeGroup.Description = model.Description;

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