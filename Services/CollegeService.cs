using CollegeCatalogAPI.Data;
using CollegeCatalog.API.DTOs;
using CollegeCatalog.API.Models;
using CollegeCatalog.API.Services;
using Microsoft.EntityFrameworkCore;

namespace CollegeCatalog.API.Services
{
    public class CollegeService : ICollegeService
    {
        private readonly CollegeDbContext cdb;

        public CollegeService(CollegeDbContext db)
        {
            cdb = db;
        }

        public async Task<List<CollegeDto>> GetAllCollegesAsync()
        {
            return await cdb.Colleges
                .Select(c => new CollegeDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location,
                    University = c.University
                })
                .ToListAsync();
        }

        public async Task<CollegeDto?> GetCollegeByIdAsync(int id)
        {
            var college = await cdb.Colleges
                .FirstOrDefaultAsync(c => c.Id == id);

            if (college == null)
            {
                return null;
            }

            return new CollegeDto
            {
                Id = college.Id,
                Name = college.Name,
                Location = college.Location,
                University = college.University
            };
        }

        public async Task<CollegeDto> CreateCollegeAsync(
            CollegeDto collegeDto)
        {
            var college = new College
            {
                Name = collegeDto.Name,
                Location = collegeDto.Location,
                University = collegeDto.University
            };

            cdb.Colleges.Add(college);

            await cdb.SaveChangesAsync();

            collegeDto.Id = college.Id;

            return collegeDto;
        }

        public async Task<bool> DeleteCollegeAsync(int id)
        {
            var college = await cdb.Colleges
                .FirstOrDefaultAsync(c => c.Id == id);

            if (college == null)
            {
                return false;
            }

            cdb.Colleges.Remove(college);

            await cdb.SaveChangesAsync();

            return true;
        }
    }
}