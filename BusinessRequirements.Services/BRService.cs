using BusinessRequirements.Data;
using BusinessRequirements.Models.BR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRequirements.Services
{
    public class BRService
    {
        private readonly Guid _userId;
        public BRService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBR(BRCreate model)
        {
            var entity =
                new BR()
                {
                    OwnerId = _userId,
                    HLCId = model.HLCId,
                    ProjectId = model.ProjectId,
                    BRNumber = model.BRNumber,
                    BusinessRequirement = model.BusinessRequirement,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BRs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BRListItem> GetBRs(int? projectId, int? hlcId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .BRs
                        .Where(e => e.OwnerId == _userId && (
                                                            (projectId != null ? e.ProjectId == projectId : true)
                                                         &&
                                                            (hlcId != null ? e.HLCId == hlcId : true)
                                                            )
                              )
                        .Select(
                            e =>
                                new BRListItem
                                {
                                    BRId = e.BRId,
                                    BRNumber = e.BRNumber,
                                    BusinessRequirement = e.BusinessRequirement,
                                    HLCId = e.HLCId,
                                    HLCNumber = e.HLC.HLCNumber,
                                    ProjectId = e.ProjectId,
                                    ProjectName = e.Project.ProjectName,
                                    ModifiedUtc = e.ModifiedUtc,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }
        public BRDetail GetBRById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BRs
                        .Single(e => e.BRId == id && e.OwnerId == _userId);
                return
                    new BRDetail
                    {
                        HLCId = entity.HLCId,
                        HLCNumber = entity.HLC.HLCNumber,
                        BRId = entity.BRId,
                        BRNumber = entity.BRNumber,
                        BusinessRequirement = entity.BusinessRequirement,
                        ProjectId = entity.ProjectId,
                        ProjectName = entity.Project.ProjectName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateBR(BREdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BRs
                        .Single(e => e.BRId == model.BRId && e.OwnerId == _userId);
                entity.BRNumber = model.BRNumber;
                if(entity.HLC.HLCNumber != model.HLCNumber)
                {
                    var hlcEntity = ctx.HLCs.FirstOrDefault(e => e.HLCNumber == model.HLCNumber && e.ProjectId == model.ProjectId);
                    entity.HLC = hlcEntity;
                    entity.HLCId = hlcEntity.HLCId;
          
                }
               
                entity.BusinessRequirement = model.BusinessRequirement;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBR(int BRId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BRs
                        .Single(e => e.BRId == BRId && e.OwnerId == _userId);

                ctx.BRs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
