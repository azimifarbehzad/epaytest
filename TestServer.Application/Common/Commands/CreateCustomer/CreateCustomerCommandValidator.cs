using System;
using FluentValidation;

namespace TestServer.Application.Common.Commands.CreateCustomer
{
	public class CreateCustomerValidator:AbstractValidator<CreateCustomerCommand>
	{
		public CreateCustomerValidator()
		{
            RuleFor(v => v.FirstName)
            .NotEmpty();

            RuleFor(v => v.LastName)
           .NotEmpty();

            RuleFor(v => v.Age)
           .GreaterThan(18);
        }
	}
}

