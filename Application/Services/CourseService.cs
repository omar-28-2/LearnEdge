using Application.Interfaces.Services;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourseDTO> GetByIdAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO> CreateAsync(CourseDTO courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task UpdateAsync(Guid id, CourseDTO courseDto)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException($"Course with ID {id} not found");

            _mapper.Map(courseDto, course);
            _unitOfWork.Courses.Update(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException($"Course with ID {id} not found");

            _unitOfWork.Courses.Remove(course);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByTeacherAsync(Guid teacherId)
        {
            var courses = await _unitOfWork.Courses.GetCoursesByTeacherAsync(teacherId);
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<IEnumerable<CourseDTO>> GetActiveCoursesAsync()
        {
            var courses = await _unitOfWork.Courses.GetActiveCoursesAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByCategoryAsync(string category)
        {
            var courses = await _unitOfWork.Courses.GetCoursesByCategoryAsync(category);
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByLevelAsync(string level)
        {
            var courses = await _unitOfWork.Courses.GetCoursesByLevelAsync(level);
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<double> GetAverageRatingAsync(Guid courseId)
        {
            return await _unitOfWork.Courses.GetAverageRatingAsync(courseId);
        }

        public async Task<int> GetTotalEnrollmentsAsync(Guid courseId)
        {
            return await _unitOfWork.Courses.GetTotalEnrollmentsAsync(courseId);
        }
    }
} 