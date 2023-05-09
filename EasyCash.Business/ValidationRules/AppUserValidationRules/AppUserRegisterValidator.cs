using EasyCash.DTO.Dtos.AppUserDtos;
using FluentValidation;

namespace EasyCash.Business.ValidationRules.AppUserValidationRules;

    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alani bos geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alani bos geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alani bos geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("şifre alani bos geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("şifre tekrarı alani bos geçilemez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girin");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girin");
            RuleFor(x => x.ConfirmPassword).Equal(y =>y.Password).WithMessage("Parolar eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir Email girin");

        }
    }
