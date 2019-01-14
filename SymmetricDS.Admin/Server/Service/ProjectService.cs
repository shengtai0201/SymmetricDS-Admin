using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class ProjectService : Repository<ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>,
        IApiService<int, ProjectViewModel, Project, ServerDbContext, AppSettings, ConnectionStrings, IPrincipal>, IProjectService
    {
        private readonly ILogger<ProjectService> logger;

        public ProjectService(ILogger<ProjectService> logger) : base()
        {
            this.logger = logger;
        }

        public async Task<bool> CreateAsync(ProjectViewModel model, IDataSource dataSource)
        {
            var project = new Project { Name = model.Name };
            await this.DbContext.Project.AddAsync(project);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                model.Id = project.Id;
                result = true;
            }
            catch { }

            return result;
        }

        public async Task<bool?> DestroyAsync(int key)
        {
            var project = await this.ReadAsync(key);
            if (project == null)
                return null;

            this.DbContext.Project.Remove(project);

            bool result = false;
            try
            {
                await this.DbContext.SaveChangesAsync();
                result = true;
            }
            catch (Exception e)
            {
                logger.LogCritical(e.Message);
            }

            return result;
        }

        public async Task<Project> ReadAsync(int key)
        {
            return await this.DbContext.Project.SingleOrDefaultAsync(p => p.Id == key);
        }

        public Task<IDataSourceResponse<ProjectViewModel>> ReadAsync(IDataSourceRequest request)
        {
            var responseData = this.DbContext.Project.Select(p => p);

            if (request.ServerFiltering != null) { }

            IDataSourceResponse<ProjectViewModel> response = new DataSourceResponse<ProjectViewModel> { TotalRowCount = responseData.Count() };

            if (request.ServerPaging != null)
            {
                int skip = Math.Max(request.ServerPaging.PageSize * (request.ServerPaging.Page - 1), 0);
                responseData = responseData.OrderBy(p => p.Id).Skip(skip).Take(request.ServerPaging.PageSize);
            }

            var dataCollection = responseData.ToList();
            foreach (var data in dataCollection)
                response.DataCollection.Add(ProjectViewModel.NewInstance(data));

            return Task.FromResult(response);
        }

        public ICollection<ProjectViewModel> Read()
        {
            ICollection<ProjectViewModel> projects = new List<ProjectViewModel>();

            var dataCollection = this.DbContext.Project.Select(p => p).ToList();
            foreach (var data in dataCollection)
                projects.Add(ProjectViewModel.NewInstance(data));

            return projects;
        }

        public async Task<bool?> UpdateAsync(int key, ProjectViewModel model, IDataSource dataSource)
        {
            var project = await this.ReadAsync(key);
            if (project == null)
                return null;

            project.Name = model.Name;

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