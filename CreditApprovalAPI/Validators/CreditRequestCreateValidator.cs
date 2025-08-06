using CreditApprovalAPI.DTOs;
using CreditApprovalAPI.Enums;
using FluentValidation;

namespace CreditApprovalAPI.Validators
{
    public class CreditRequestCreateValidator : AbstractValidator<CreditRequestCreateDto>
    {
        public CreditRequestCreateValidator()
        {
            RuleFor(x => x.MonthlyIncome)
                .GreaterThan(0)
                .WithMessage("Monthly income must be greater than zero.");

            RuleFor(x => x.CreditAmount)
                .GreaterThan(0)
                .WithMessage("Credit amount must be greater than zero.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.CreditType)
                .IsInEnum()
                .WithMessage("Invalid credit type specified.");

            RuleFor(x => x)
                .Must(x =>
                {
                    return x.CreditType switch
                    {
                        CreditType.Mortgage => x.CreditAmount <= 500000,
                        CreditType.Auto => x.CreditAmount <= 50000,
                        CreditType.Personal => x.CreditAmount <= 10000,
                        _=> false
                    };

                });

        }
    }
}
