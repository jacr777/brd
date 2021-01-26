using BusinessRequirements.Data;
using BusinessRequirements.Models.HLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Services
{
    public class HLCService
    {
        private readonly Guid _userId;
        public HLCService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateHLC(HLCCreate model)
        {
            var entity =
                new HLC()
                {
                    OwnerId = _userId,
                    ProjectId = model.ProjectId,
                    HLCNumber = model.HLCNumber,
                    HLCDescription = model.HLCDescription,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.HLCs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<HLCListItem> GetHLCs(int? projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .HLCs
                        .Where(e => e.OwnerId == _userId && (projectId != null ? e.ProjectId == projectId: true))
                        .Select(
                            e =>
                                new HLCListItem
                                {
                                    HLCId = e.HLCId,
                                    HLCNumber = e.HLCNumber,
                                    HLCDescription = e.HLCDescription,
                                    ProjectId = e.ProjectId,
                                    Project = e.Project.ProjectName,
                                    ModifiedUtc = e.ModifiedUtc,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public HLCDetail GetHLCById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HLCs
                        .Single(e => e.HLCId == id && e.OwnerId == _userId);
                return
                    new HLCDetail
                    {
                        ProjectId = entity.ProjectId,
                        Project = entity.Project.ProjectName,
                        HLCId = entity.HLCId,
                        HLCNumber = entity.HLCNumber,
                        HLCDescription = entity.HLCDescription,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateHLC(HLCEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HLCs
                        .Single(e => e.HLCId == model.HLCId && e.OwnerId == _userId);
                entity.HLCNumber = model.HLCNumber;
                entity.ProjectId = model.ProjectId;
                entity.HLCDescription = model.HLCDescription;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteHLC(int HLCId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HLCs
                        .Single(e => e.HLCId == HLCId && e.OwnerId == _userId);

                ctx.HLCs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
