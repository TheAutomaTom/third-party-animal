using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3PA.API.Services.PublicRecords.Voters.Queries.ByName
{
	public class GetVotersByNameValidator : AbstractValidator<GetVotersByNameQuery>
	{
		public GetVotersByNameValidator()
		{
		}
	}
}
