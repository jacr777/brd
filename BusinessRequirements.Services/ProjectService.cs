using BusinessRequirements.Data;
using BusinessRequirements.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;
        public ProjectService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    OwnerId = _userId,
                    Ticket = model.Ticket,
                    ProjectName = model.ProjectName,
                    Area = model.Area,
                    Budget = model.Budget,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProjectListItem
                                {
                                    ProjectId = e.ProjectId, 
                                    Ticket= e.Ticket,
                                    ProjectName = e.ProjectName,
                                    Area = e.Area,
                                    Budget = e.Budget,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == id && e.OwnerId == _userId);
                return
                    new ProjectDetail
                    {
                        ProjectId = entity.ProjectId,
                        Ticket = entity.Ticket,
                        ProjectName = entity.ProjectName,
                        Area = entity.Area,
                        Budget = entity.Budget,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == model.ProjectId && e.OwnerId == _userId);
                entity.Ticket = model.Ticket;
                entity.ProjectName = model.ProjectName;
                entity.Area = model.Area;
                entity.Budget = model.Budget;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProject(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == projectId && e.OwnerId == _userId);

                ctx.Projects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
