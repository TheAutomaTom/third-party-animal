using _3PA.Core.Models;
using FluentValidation;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlValidator : AbstractValidator<ReadFileToSqlCommand>
  {
    public ReadFileToSqlValidator()
     {
      When(r => r.State == SupportedUsStates.Fl, () =>
      {
        When(r => r.Category == Category.Voter, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^\D{3}_\d{8}$")
          .WithMessage("Not a supported Fl Voter File");
        });
        When(r => r.Category == Category.History, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^\D{3}_H_\d{8}$")
          .WithMessage("Not a supported Fl History File"); 
        });
      });

      When(r => r.State == SupportedUsStates.Nc, () =>
      {
        When(r => r.Category == Category.Voter, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^ncvoter\d{1,3}$")
          .WithMessage("Not a supported Nc Voter File");
        });
        When(r => r.Category == Category.History, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^ncvhis\d{1,3}$")
          .WithMessage("Not a supported Nc History File");
        });
      });

    }


  }
}

   
