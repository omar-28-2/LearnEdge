using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ICourseService
    {
        Task<CourseDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task<CourseDTO> CreateAsync(CourseDTO courseDto);
        Task UpdateAsync(Guid id, CourseDTO courseDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<CourseDTO>> GetCoursesByTeacherAsync(Guid teacherId);
        Task<IEnumerable<CourseDTO>> GetActiveCoursesAsync();
        Task<IEnumerable<CourseDTO>> GetCoursesByCategoryAsync(string category);
        Task<IEnumerable<CourseDTO>> GetCoursesByLevelAsync(string level);
        Task<double> GetAverageRatingAsync(Guid courseId);
        Task<int> GetTotalEnrollmentsAsync(Guid courseId);
    }
} 