using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByTeacherAsync(Guid teacherId);
        Task<IEnumerable<Course>> GetActiveCoursesAsync();
        Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category);
        Task<IEnumerable<Course>> GetCoursesByLevelAsync(string level);
        Task<double> GetAverageRatingAsync(Guid courseId);
        Task<int> GetTotalEnrollmentsAsync(Guid courseId);
    }
} 