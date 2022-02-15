using _3PA.Core.Models;
using FluentValidation;

namespace _3PA.API.Services.PublicRecords.Consumer.Commands
{
  public class ReadFileToSqlValidator : AbstractValidator<ReadFileToSqlCommand>
  {
    public ReadFileToSqlValidator()
     {
      When(r => r.State == UsState.Fl, () =>
      {
        When(r => r.Category == Category.Voter, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^\D{3}_\d{8}$")
          .WithMessage("Not a supported FlVoter Voter File");
        });
        When(r => r.Category == Category.History, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^\D{3}_H_\d{8}$")
          .WithMessage("Not a supported FlVoter History File"); 
        });
      });

      When(r => r.State == UsState.Nc, () =>
      {
        When(r => r.Category == Category.Voter, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^ncvoter\d{1,3}$")
          .WithMessage("Not a supported NcVoter Voter File");
        });
        When(r => r.Category == Category.History, () =>
        {
          // Filenames...
          RuleFor(r => Path.GetFileNameWithoutExtension(r.FileName))
          .Matches(@"^ncvhis\d{1,3}$")
          .WithMessage("Not a supported NcVoter History File");
        });
      });

    }


  }
}

   
