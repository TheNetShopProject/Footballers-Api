using System.Linq;
using System.Runtime.CompilerServices;
using Application.ModelsDTO;
using FluentValidation;
using Infrastructure.Data;

namespace Infrastructure.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        private readonly FotballersDbContext _dbContext;

        public CreateUserValidator(FotballersDbContext dbContext)
        {
            _dbContext = dbContext;


            RuleFor(x => x.Email).
                NotEmpty().
                EmailAddress().
                WithMessage("Must be a valid email address !");
            RuleFor(x => x.Password).
                MinimumLength(6);
            RuleFor(x => x.Password).
                Equal(c => c.ConfirmPassword)
                .WithMessage("Password and Confirmed passwoart are not the same !");
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = _dbContext.Users.Any(x => x.Email == value);
                    if (emailInUse)
                        context
                            .AddFailure("Email", "That email is already taken");
                });
        }
    }
}