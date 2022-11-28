using Npgsql;
using Dapper;

public class CourseService
{
     private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Home;User Id=postgres;Password=sqlj123;";
     public List<Courses> GetCourses()
     {
        using (var db = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Courses";
            var result = db.Query<Courses>(sql).ToList();
            return result;
        }
     }
     public int InsertCourse(Courses course)
    {
        using (var db = new NpgsqlConnection(_connectionString))
        {
            string sql = $"INSERT Into Courses (Name, mentor, address, phone) Values ('{course.Name}', '{course.Mentor}', '{course.address}','{course.phone}')";
            var result = db.Execute(sql);
            return result;
        }
    }

    public int UpdateCourse(Courses course)
    {
        using (var db = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update Courses Set" +
            $"name = '{course.Name}', " +
            $"mentor = '{course.Mentor}', " +
            $"address = '{course.address}', " +
            $"phone = '{course.phone}', " +
            $"Where id = {course.Id}";

            var result = db.Execute(sql);

            return result;

        }
    }

    public int DeleteCourse(int id)
    {
        using (var db = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Delete from Courses Where id = {id}";
            var result = db.Execute(sql);
            return result;
        }
    }

  public int GetCount()
        {
            using (var db = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                $"select Count(*) from Courses;";
                var result = db.ExecuteScalar<int>(sql);
                return result;
            } 
        }
            
}