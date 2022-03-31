using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3PA.Data.Sql.Core.Interfaces;
using _3PA.Core.Models;
using _3PA.Data.Sql.Fl;
using _3PA.Data.Sql.Nc;
using System.ComponentModel.DataAnnotations;

namespace _3PA.API.Services.PublicRecords.Voters.Queries.ByName
{
	public class GetVotersByNameHandler : IRequestHandler<GetVotersByNameQuery, GetVotersByNameResponse>
	{
		IPublicRecordsRepository repo { get; set; }

		public async Task<GetVotersByNameResponse> Handle(GetVotersByNameQuery request, CancellationToken cancellationToken)
    {
      switch (request.UsState)
      {
        case UsState.Fl:
          repo = new FlRepository();
          break;
        case UsState.Nc:
          repo = new NcRepository();
          break;
        default:
          throw new ValidationException($"Could not determine process for {request.UsState}/{request.CountyId}/{request.Surname}.");
      }

			using (repo)
      {
        var voters = repo.GetVoters(request.CountyId, request.Surname);
        return new GetVotersByNameResponse(voters);
      }


    }
	}
}
