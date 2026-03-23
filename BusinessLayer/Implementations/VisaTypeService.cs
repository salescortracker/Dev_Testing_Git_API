using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public class VisaTypeService : IVisaTypeService
    {
        private readonly HRMSContext _context;

        public VisaTypeService(HRMSContext context)
        {
            _context = context;
        }

        public async Task<List<VisaTypeDto>> GetVisaTypeList(int userId)
        {
            try
            {
                var data = await (
                    from v in _context.VisaTypes
                    join c in _context.Companies on v.CompanyId equals c.CompanyId
                    join r in _context.Regions on v.RegionId equals r.RegionId
                    where v.IsDeleted != true
                    select new VisaTypeDto
                    {
                        VisaTypeId = v.VisaTypeId,
                        CompanyId = v.CompanyId,
                        RegionId = v.RegionId,
                        VisaType1 = v.VisaType1,
                        Description = v.Description,
                        IsActive = v.IsActive,
                        IsDeleted = v.IsDeleted,
                        CreatedAt = v.CreatedAt,
                        CompanyName = c.CompanyName,
                        RegionName = r.RegionName
                    }).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<string> CreateVisaType(VisaTypeDto dto)
        {
            var exists = _context.VisaTypes.Any(x =>
                x.VisaType1 == dto.VisaType1 &&
                x.CompanyId == dto.CompanyId &&
                x.RegionId == dto.RegionId &&
                (x.IsDeleted == false || x.IsDeleted == null));

            if (exists)
                return "Duplicate Visa Type";

            var entity = new VisaType
            {
                CompanyId = dto.CompanyId,
                RegionId = dto.RegionId,
                VisaType1 = dto.VisaType1,
                Description = dto.Description,
                IsActive = dto.IsActive,
                IsDeleted = false,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now
            };

            _context.VisaTypes.Add(entity);
            await _context.SaveChangesAsync();

            return "Created Successfully";
        }

        public async Task<string> UpdateVisaType(VisaTypeDto dto)
        {
            var entity = _context.VisaTypes
                .FirstOrDefault(x => x.VisaTypeId == dto.VisaTypeId);

            if (entity == null)
                return "Not Found";

            entity.CompanyId = dto.CompanyId;
            entity.RegionId = dto.RegionId;
            entity.VisaType1 = dto.VisaType1;
            entity.Description = dto.Description;
            entity.IsActive = dto.IsActive;
            entity.ModifiedBy = dto.ModifiedBy;
            entity.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return "Updated Successfully";
        }

        public async Task<string> DeleteVisaType(int id)
        {
            var entity = _context.VisaTypes
                .FirstOrDefault(x => x.VisaTypeId == id);

            if (entity == null)
                return "Not Found";

            entity.IsDeleted = true;
            entity.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return "Deleted Successfully";
        }
    }
}
