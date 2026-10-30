using CollegeCatalog.API.DTOs;
using CollegeCatalog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService collegeService;

        public CollegeController(ICollegeService _collegeService)
        {
            collegeService = _collegeService;
        }

        [HttpGet("GetAllColleges")]
        public async Task<IActionResult> GetAllColleges()

        {
            string? custHeader = Request.Headers["x-my-header"].FirstOrDefault();
            Response.Headers["X-my-Custom-Header"] = "Getting All College Info";



            var colleges = await collegeService.GetAllCollegesAsync();

            return Ok(colleges);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollegeById(int id)
        {
            string? custHeader = Request.Headers["x-my-header"].FirstOrDefault();
            Response.Headers["X-my-Custom-Header"] = "Getting College By Id";
            var college = await collegeService.GetCollegeByIdAsync(id);

            if (college == null)
            {
                return NotFound($"College with ID {id} not found.");
            }

            return Ok(college);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollege(
            CollegeDto college)
        {
            string? custHeader = Request.Headers["x-my-header"].FirstOrDefault();
            Response.Headers["X-my-Custom-Header"] = "College Created Succesfully";


            var createdCollege =
                await collegeService.CreateCollegeAsync(college);

            return CreatedAtAction(
                nameof(GetCollegeById),
                new { id = createdCollege.Id },
                createdCollege
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollege(int id)
        {
            string? custHeader = Request.Headers["x-my-header"].FirstOrDefault();
            Response.Headers["X-my-Custom-Header"] = "College Deleted Succesfully";

            var deleted =
                await collegeService.DeleteCollegeAsync(id);

            if (!deleted)
            {
                return NotFound(
                    $"College with ID {id} not found."
                );
            }

            return Ok("College deleted successfully.");
        }
    }
}