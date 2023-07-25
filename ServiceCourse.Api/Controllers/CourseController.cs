using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCourse.Api.Services.Interfaces;
using ServiceCourse.Api.Services.Models;
using System.Net.Mime;

namespace ServiceCourse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{courseId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CourseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAsync(int courseId)
        {
            try
            {
                var serviceResult = await _courseService.GetCourseAsync(courseId);

                if (serviceResult == null)
                {
                    return NotFound();
                }

                return Ok(serviceResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CourseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var serviceResult = await _courseService.GetCoursesAsync();

                if (serviceResult == null)
                {
                    return NotFound();
                }

                return Ok(serviceResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
