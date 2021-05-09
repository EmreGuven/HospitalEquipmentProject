using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EquipmentValidator:AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(c => c.EquipmentName).NotEmpty();
            RuleFor(c => c.UnitInStock >= 1).NotEmpty();
            RuleFor(c => c.UnitPrice >= 0.01);
        }
    }
}
