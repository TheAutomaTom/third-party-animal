﻿namespace _3PA.Core.Models.Nc
{
  public class NcGeoData : IGeoData
  {
    public override char Delimiter => '\t';    
    public override string FileSuffix => ".txt";
    public override int CountyIdStartPosition => -1;
    public override int CountyIdMaxLength => 3;
    public override bool KeyIsInt => true;
    public override Dictionary<string, string> CountyIds
       => new Dictionary<string, string>
      {
        {"1" , "ALAMANCE" },
        {"2" , "ALEXANDER"},
        {"3" , "ALLEGHANY"},
        {"4" , "ANSON"},
        {"5" , "ASHE"},
        {"6" , "AVERY"},
        {"7" , "BEAUFORT"},
        {"8" , "BERTIE"},
        {"9" , "BLADEN"},
        {"10", "BRUNSWICK"},
        {"11", "BUNCOMBE"},
        {"12", "BURKE"},
        {"13", "CABARRUS"},
        {"14", "CALDWELL"},
        {"15", "CAMDEN"},
        {"16", "CARTERET"},
        {"17", "CASWELL"},
        {"18", "CATAWBA"},
        {"19", "CHATHAM"},
        {"20", "CHEROKEE"},
        {"21", "CHOWAN"},
        {"22", "CLAY"},
        {"23", "CLEVELAND"},
        {"24", "COLUMBUS"},
        {"25", "CRAVEN"},
        {"26", "CUMBERLAND"},
        {"27", "CURRITUCK"},
        {"28", "DARE"},
        {"29", "DAVIDSON"},
        {"30", "DAVIE"},
        {"31", "DUPLIN"},
        {"32", "DURHAM"},
        {"33", "EDGECOMBE"},
        {"34", "FORSYTH"},
        {"35", "FRANKLIN"},
        {"36", "GASTON"},
        {"37", "GATES"},
        {"38", "GRAHAM"},
        {"39", "GRANVILLE"},
        {"40", "GREENE"},
        {"41", "GUILFORD"},
        {"42", "HALIFAX"},
        {"43", "HARNETT"},
        {"44", "HAYWOOD"},
        {"45", "HENDERSON"},
        {"46", "HERTFORD"},
        {"47", "HOKE"},
        {"48", "HYDE"},
        {"49", "IREDELL"},
        {"50", "JACKSON"},
        {"51", "JOHNSTON"},
        {"52", "JONES"},
        {"53", "LEE"},
        {"54", "LENOIR"},
        {"55", "LINCOLN"},
        {"56", "MACON"},
        {"57", "MADISON"},
        {"58", "MARTIN"},
        {"59", "MCDOWELL"},
        {"60", "MECKLENBURG"},
        {"61", "MITCHELL"},
        {"62", "MONTGOMERY"},
        {"63", "MOORE"},
        {"64", "NASH"},
        {"65", "NEWHANOVER"},
        {"66", "NORTHAMPTON"},
        {"67", "ONSLOW"},
        {"68", "ORANGE"},
        {"69", "PAMLICO"},
        {"70", "PASQUOTANK"},
        {"71", "PENDER"},
        {"72", "PERQUIMANS"},
        {"73", "PERSON"},
        {"74", "PITT"},
        {"75", "POLK"},
        {"76", "RANDOLPH"},
        {"77", "RICHMOND"},
        {"78", "ROBESON"},
        {"79", "ROCKINGHAM"},
        {"80", "ROWAN"},
        {"81", "RUTHERFORD"},
        {"82", "SAMPSON"},
        {"83", "SCOTLAND"},
        {"84", "STANLY"},
        {"85", "STOKES"},
        {"86", "SURRY"},
        {"87", "SWAIN"},
        {"88", "TRANSYLVANIA"},
        {"89", "TYRRELL"},
        {"90", "UNION"},
        {"91", "VANCE"},
        {"92", "WAKE"},
        {"93", "WARREN"},
        {"94", "WASHINGTON"},
        {"95", "WATAUGA"},
        {"96", "WAYNE"},
        {"97", "WILKES"},
        {"98", "WILSON"},
        {"99", "YADKIN"},
        {"100", "YANCEY"}
      };
    }
  }

