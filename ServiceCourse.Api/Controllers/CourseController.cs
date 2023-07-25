using Microsoft.AspNetCore.Mvc;
using ServiceCourse.Api.Filters;
using ServiceCourse.Api.Services.Interfaces;
using ServiceCourse.Api.Services.Models;
using System.Net.Mime;

namespace ServiceCourse.Api.Controllers
{
    [Route("api/[controller]")]
    [Authentication]
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
            var serviceResult = await _courseService.GetCourseAsync(courseId);

            if (serviceResult.Success && serviceResult.Result.Id != null)
                return Ok(serviceResult.Result);

            return BadRequest(serviceResult.ErrorMessage);
        }

        [HttpGet("/all")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<CourseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAllAsync()
        {
            var serviceResult = await _courseService.GetCoursesAsync();

            if (serviceResult.Success)
                return Ok(serviceResult.Result);
            else
                return BadRequest(serviceResult.ErrorMessage);
        }
    }
}

