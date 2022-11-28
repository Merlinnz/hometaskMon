using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class CoursesController 
{
    private CourseService _courseService;
    public CoursesController()
    {
        _courseService = new CourseService();
    }
    
    [HttpGet]
    public List<Courses> GetCourses()
    {
        return _courseService.GetCourses();
    }

    [HttpPost("Insert")]
    public int InsertCourse(Courses course)
        {
            return _courseService.InsertCourse(course);
        }

    [HttpPut("Update")]   
        public int UpdateCourse(Courses course)
        {
            return _courseService.UpdateCourse(course);
        } 
    [HttpDelete("Delete")]    
        public int DeleteCourse(int id)
        {
            return _courseService.DeleteCourse(id);
        }

    [HttpGet("Count")]
        public int GetCount()
        {
            return _courseService.GetCount();
        }
}