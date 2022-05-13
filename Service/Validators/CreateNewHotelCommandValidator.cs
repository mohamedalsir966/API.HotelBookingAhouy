using FluentValidation;
using Service.HotelFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class CreateNewHotelCommandValidator : AbstractValidator<CreateNewHotelCommand>
    {
        public CreateNewHotelCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
