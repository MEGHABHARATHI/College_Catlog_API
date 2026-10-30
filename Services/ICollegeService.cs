using CollegeCatalog.API.DTOs;

namespace CollegeCatalog.API.Services
{
    public interface ICollegeService
    {
        Task<List<CollegeDto>> GetAllCollegesAsync();

        Task<CollegeDto?> GetCollegeByIdAsync(int id);

        Task<CollegeDto> CreateCollegeAsync(CollegeDto collegeDto);

        Task<bool> DeleteCollegeAsync(int id);
    }
}