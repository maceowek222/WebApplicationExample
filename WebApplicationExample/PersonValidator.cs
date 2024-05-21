using FluentValidation;

namespace WebApplicationExample
{
    public class PersonValidator : AbstractValidator<Osoba>
    {
        public PersonValidator()
        {
            RuleFor(t => t.Imie)
                .NotEmpty()
                .WithMessage("Pole imię jest wymagane")
                .MaximumLength(50)
                .WithMessage("Pole imię może mieć max 50 znaków");

            RuleFor(t => t.Nazwisko)
               .NotEmpty()
               .WithMessage("Pole nazwisko jest wymagane")
               .MaximumLength(50)
               .WithMessage("Pole nazwisko może mieć max 50 znaków");

            RuleFor(t => t.DataUrodzenia)
               .NotEmpty()
               .WithMessage("Pole data urodzenia jest wymagane");
            RuleFor(t => t.Adres)
                 .NotEmpty()
               .WithMessage("Pole adres jest wymagane")
               .MaximumLength(100)
               .WithMessage("Pole adres może mieć max 100 znaków");


        }

    }
}
