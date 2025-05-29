using Domain.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class CourseDTOValidator : AbstractValidator<CourseDTO>
    {
        public CourseDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required")
                .MaximumLength(50).WithMessage("Category cannot exceed 50 characters");

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("Level is required")
                .MaximumLength(50).WithMessage("Level cannot exceed 50 characters");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0");

            RuleFor(x => x.TeacherId)
                .NotEmpty().WithMessage("Teacher ID is required");
        }
    }
} 