using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3PA.Core.Models.Nc
{
  [Table("OrphanHistories")]
  public class NcHistoryOrphan : NcHistory
  {
    public NcHistoryOrphan() { }
    public NcHistoryOrphan(string row) : base(row) { }
    public NcHistoryOrphan(NcHistory history)
    {
      base.CountyId = history.CountyId;
      base.CountyDescription = history.CountyDescription;
      base.VoterRegistrationNumber = history.VoterRegistrationNumber;
      base.ElectionLable = history.ElectionLable;
      base.ElectionDescription = history.ElectionDescription;
      base.VotingMethod = history.VotingMethod;
      base.VotedPartyCd = history.VotedPartyCd;
      base.VotedPartyDescription = history.VotedPartyDescription;
      base.PctLabel = history.PctLabel;
      base.PctDescription = history.PctDescription;
      base.Ncid = history.Ncid;
      base.VotedCountyId = history.VotedCountyId;
      base.VotedCounty_Description = history.VotedCounty_Description;
      base.VotedLabel = history.VotedLabel;
      base.VotedDescription = history.VotedDescription;
      base.Id = $"{VoterRegistrationNumber}{PctLabel}{ElectionLable}{VotingMethod}";

    }
  }
}
