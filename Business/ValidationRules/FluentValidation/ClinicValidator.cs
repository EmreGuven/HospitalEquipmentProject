using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ClinicValidator:AbstractValidator<Clinic>
    {
        
        public ClinicValidator()
        {
            RuleFor(e => e.ClinicName).NotEmpty();
        }
    }
}
