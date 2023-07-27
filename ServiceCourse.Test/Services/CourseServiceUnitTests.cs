using Moq;
using ServiceCourse.Api.Data;
using ServiceCourse.Api.Data.Entitites;
using ServiceCourse.Api.Data.Interfaces;
using ServiceCourse.Api.Services;
using ServiceCourse.Api.Services.Interfaces;

namespace ServiceCourse.Test.Services
{
    public class CourseServiceUnitTests
    {
        private readonly ICourseService _courseService;
        private readonly Mock<ICourseRepository> _courseRepositoryMock = new();
        private readonly Mock<IUnitOfWork> _uowMock = new();

        public CourseServiceUnitTests()
        {
            _courseService = new CourseService(_courseRepositoryMock.Object,
                                                               _uowMock.Object);
        }

        [Fact]
        public async Task GetCourse_When_CourseId_Is_Null()
        {
            //Setup
            _courseRepositoryMock
                .Setup(e => e.GetCourseAsync(0))
                .ReturnsAsync((Course)null);

            //Arrange
            var courseId = 0;

            //Act
            var result = await _courseService.GetCourseAsync(courseId);

            //Assert

            Assert.False(result.Success);
            Assert.Contains("O curso não existe", result.ErrorMessage);
        }

        [Fact]
        public async Task GetCourse_When_CourseId_Is_Valid()
        {
            //Setup
            Course course = new Course()
            {
                Courseid = 1,
                Name = "Curso"
            };

            _courseRepositoryMock
                .Setup(e => e.GetCourseAsync(1))
                .ReturnsAsync(course);

            //Arrange
            var courseId = 1;

            //Act
            var result = await _courseService.GetCourseAsync(courseId);

            //Assert

            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetCourses_Should_Return_Empty()
        {
            //Setup
            _courseRepositoryMock
                .Setup(e => e.GetCoursesAsync())
                .ReturnsAsync((List<Course>)null);

            //Act
            var result = await _courseService.GetCoursesAsync();

            //Assert

            Assert.False(result.Success);
            Assert.Contains("Nenhum curso encontrado", result.ErrorMessage);
        }

        [Fact]
        public async Task GetCourses_Should_Return_List()
        {
            //Setup
            List<Course> courses = new List<Course>()
            {
                new Course()
                {
                Courseid = 1,
                Name = "Curso"
                },
                new Course()
                {
                    Courseid = 2,
                    Name = "Curso 2"
                }
            };

            //Arrange

            _courseRepositoryMock
                .Setup(e => e.GetCoursesAsync())
                .ReturnsAsync(courses);

            //Act
            var result = await _courseService.GetCoursesAsync();

            //Assert

            Assert.True(result.Success);
            Assert.True(result.Result.Count > 0);
        }


        [Fact]
        public async Task GetCourses_By_TeacherId_Should_Return_List()
        {
            //Setup
            List<Course> courses = new List<Course>()
            {
                new Course()
                {
                Courseid = 1,
                Name = "Curso",
                Teacherid = 1
                },
                new Course()
                {
                    Courseid = 2,
                    Name = "Curso 2",
                    Teacherid = 1
                }
            };

            //Arrange
            var teacherId = 1;

            _courseRepositoryMock
                .Setup(e => e.GetCoursesByTeacherIdAsync(teacherId))
                .ReturnsAsync(courses);

            //Act
            var result = await _courseService.GetCoursesByTeacherIdAsync(teacherId);

            //Assert

            Assert.True(result.Success);
            Assert.True(result.Result.Count > 0);
        }

        [Fact]
        public async Task GetCourses_By_TeacherId_When_Id_Is_Not_Valid_Should_Return_List_Empty()
        {
            //Setup
            _courseRepositoryMock
                .Setup(e => e.GetCoursesByTeacherIdAsync(0))
                .ReturnsAsync((List<Course>)null);

            //Arrange
            var teacherId = 0;

            //Act
            var result = await _courseService.GetCoursesByTeacherIdAsync(teacherId);

            //Assert

            Assert.False(result.Success);
            Assert.Contains("Nenhum curso encontrado", result.ErrorMessage);
        }
    }
}


