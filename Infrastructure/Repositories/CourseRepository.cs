using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LearnEdgeDbContext _context;

        public CourseRepository(LearnEdgeDbContext context)
        {
            _context = context;
        }

        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }

        public void Remove(Course course)
        {
            _context.Courses.Remove(course);
        }

        public async Task<IEnumerable<Course>> GetCoursesByTeacherAsync(Guid teacherId)
        {
            return await _context.Courses.Where(c => c.TeacherId == teacherId).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetActiveCoursesAsync()
        {
            return await _context.Courses.Where(c => c.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
        {
            return await _context.Courses.Where(c => c.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByLevelAsync(string level)
        {
            return await _context.Courses.Where(c => c.Level == level).ToListAsync();
        }

        public async Task<double> GetAverageRatingAsync(Guid courseId)
        {
            return await _context.Ratings
                .Where(r => r.CourseId == courseId)
                .AverageAsync(r => r.Score);
        }

        public async Task<int> GetTotalEnrollmentsAsync(Guid courseId)
        {
            return await _context.Courses
                .Where(c => c.Id == courseId)
                .Select(c => c.Enrollments.Count)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> FindAsync(Expression<Func<Course, bool>> predicate)
        {
            return await _context.Courses.Where(predicate).ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Course> courses)
        {
            await _context.Courses.AddRangeAsync(courses);
        }

        public void RemoveRange(IEnumerable<Course> courses)
        {
            _context.Courses.RemoveRange(courses);
        }

        public async Task<bool> ExistsAsync(Expression<Func<Course, bool>> predicate)
        {
            return await _context.Courses.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<Course, bool>> predicate)
        {
            return await _context.Courses.CountAsync(predicate);
        }
    }
} 