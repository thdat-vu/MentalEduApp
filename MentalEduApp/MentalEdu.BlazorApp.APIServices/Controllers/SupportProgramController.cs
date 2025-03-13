using Microsoft.AspNetCore.Mvc;
using MentalEdu.Repositories.Models;
using MentalEdu.Services.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentalEdu.BlazorApp.APIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportProgramController : ControllerBase
    {
        private readonly ISupportProgramService _supportProgramService;
        private readonly IProgramCategoryService _programCategoryService;

        public SupportProgramController(ISupportProgramService supportProgramService, IProgramCategoryService programCategoryService)
        {
            _supportProgramService = supportProgramService;
            _programCategoryService = programCategoryService;
        }

        // GET: api/SupportProgram
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportProgram>>> GetSupportPrograms()
        {
            try
            {
                var programs = await _supportProgramService.GetActiveProgramsAsync();
                return Ok(programs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/SupportProgram/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportProgram>> GetSupportProgram(Guid id)
        {
            try
            {
                var program = await _supportProgramService.GetProgramByIdAsync(id);

                if (program == null)
                {
                    return NotFound($"Support program with ID {id} not found");
                }

                return Ok(program);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/SupportProgram/category/5
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<SupportProgram>>> GetSupportProgramsByCategory(Guid categoryId)
        {
            try
            {
                var programs = await _supportProgramService.GetProgramsByCategoryIdAsync(categoryId);
                return Ok(programs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/SupportProgram
        [HttpPost]
        public async Task<ActionResult<SupportProgram>> CreateSupportProgram(SupportProgram program)
        {
            try
            {
                if (program == null)
                {
                    return BadRequest("Support program data is null");
                }

                var createdProgram = await _supportProgramService.CreateProgramAsync(program);
                return CreatedAtAction(nameof(GetSupportProgram), new { id = createdProgram.Id }, createdProgram);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/SupportProgram/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupportProgram(Guid id, SupportProgram program)
        {
            try
            {
                if (id != program.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var existingProgram = await _supportProgramService.GetProgramByIdAsync(id);
                if (existingProgram == null)
                {
                    return NotFound($"Support program with ID {id} not found");
                }

                await _supportProgramService.UpdateProgramAsync(program);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/SupportProgram/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportProgram(Guid id)
        {
            try
            {
                var program = await _supportProgramService.GetProgramByIdAsync(id);
                if (program == null)
                {
                    return NotFound($"Support program with ID {id} not found");
                }

                await _supportProgramService.DeleteProgramAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/SupportProgram/categories
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<ProgramCategory>>> GetProgramCategories()
        {
            try
            {
                var categories = await _programCategoryService.GetActiveCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}