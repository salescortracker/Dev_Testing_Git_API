using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class SubscriptionPlanService: ISubscriptionPlanService
    {
        private readonly HRMSContext _context;

        public SubscriptionPlanService(HRMSContext context)
        {
            _context = context;
        }

        public async Task<List<SubscriptionPlanDto>> GetPlansAsync()
        {
            return await _context.SubscriptionPlans1
                .Select(p => new SubscriptionPlanDto
                {
                    PlanId = p.PlanId,
                    PlanName = p.PlanName,
                    Description = p.Description,
                    Price = p.Price,
                    DurationDays = p.DurationDays,
                    MaxUsers = p.MaxUsers,
                    MaxEmployees = p.MaxEmployees,
                    StorageLimitGB = p.StorageLimitGb,
                    Status = p.Status
                }).ToListAsync();
        }

        public async Task<SubscriptionPlanDto> GetPlanByIdAsync(int id)
        {
            var p = await _context.SubscriptionPlans1
                .FirstOrDefaultAsync(x => x.PlanId == id);

            if (p == null) return null;

            return new SubscriptionPlanDto
            {
                PlanId = p.PlanId,
                PlanName = p.PlanName,
                Description = p.Description,
                Price = p.Price,
                DurationDays = p.DurationDays,
                MaxUsers = p.MaxUsers,
                MaxEmployees = p.MaxEmployees,
                StorageLimitGB = p.StorageLimitGb,
                Status = p.Status
            };
        }

        public async Task<SubscriptionPlanDto> CreatePlanAsync(SubscriptionPlanDto dto)
        {
            var entity = new SubscriptionPlan1
            {
                PlanName = dto.PlanName,
                Description = dto.Description,
                Price = dto.Price,
                DurationDays = dto.DurationDays,
                MaxUsers = dto.MaxUsers,
                MaxEmployees = dto.MaxEmployees,
                StorageLimitGb = dto.StorageLimitGB,
                Status = true,
                CreatedDate = DateTime.Now
            };

            _context.SubscriptionPlans1.Add(entity);

            await _context.SaveChangesAsync();

            dto.PlanId = entity.PlanId;

            return dto;
        }

        public async Task<SubscriptionPlanDto> UpdatePlanAsync(int id, SubscriptionPlanDto dto)
        {
            var entity = await _context.SubscriptionPlans1.FindAsync(id);

            if (entity == null) return null;

            entity.PlanName = dto.PlanName;
            entity.Description = dto.Description;
            entity.Price = dto.Price;
            entity.DurationDays = dto.DurationDays;
            entity.MaxUsers = dto.MaxUsers;
            entity.MaxEmployees = dto.MaxEmployees;
            entity.StorageLimitGb = dto.StorageLimitGB;
            entity.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeletePlanAsync(int id)
        {
            var entity = await _context.SubscriptionPlans.FindAsync(id);

            if (entity == null) return false;

            _context.SubscriptionPlans.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
