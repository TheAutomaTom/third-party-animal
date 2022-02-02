namespace _3PA.Core.Models.Fl
{
  public class FlGeoData : IGeoData
  {
    public override char Delimiter => '\t';
    public override string FileSuffix => ".txt";
    public override int CountyIdStartPosition => 1;
    public override int CountyIdMaxLength => 3;
    public override bool KeyIsInt => false; 
    public override Dictionary<string, string> CountyIds 
      => new Dictionary<string, string>
      {
        {"ALA","Alachua"},
        {"HAM","Hamilton"},
        {"OKE","Okeechobee"},
        {"BAK","Baker"},
        {"HAR","Hardee"},
        {"ORA","Orange"},
        {"BAY","Bay"},
        {"HEN","Hendry"},
        {"OSC","Osceola"},
        {"BRA","Bradford"},
        {"HER","Hernando"},
        {"PAL","Palm Beach"},
        {"BRE","Brevard"},
        {"HIG","Highlands"},
        {"PAS","Pasco"},
        {"BRO","Broward"},
        {"HIL","Hillsborough"},
        {"PIN","Pinellas"},
        {"CAL","Calhoun"},
        {"HOL","Holmes"},
        {"POL","Polk"},
        {"CHA","Charlotte"},
        {"IND","Indian River"},
        {"PUT","Putnam"},
        {"CIT","Citrus"},
        {"JAC","Jackson"},
        {"SAN","Santa Rosa"},
        {"CLA","Clay"},
        {"JEF","Jefferson"},
        {"SAR","Sarasota"},
        {"CLL","Collier"},
        {"LAF","Lafayette"},
        {"SEM","Seminole"},
        {"CLM","Columbia"},
        {"LAK","Lake"},
        {"STJ","St.Johns"},
        {"DAD","Miami - Dade"},
        {"LEE","Lee"},
        {"STL","St.Lucie"},
        {"DES","Desoto"},
        {"LEO","Leon"},
        {"SUM","Sumter"},
        {"DIX","Dixie"},
        {"LEV","Levy"},
        {"SUW","Suwannee"},
        {"DUV","Duval"},
        {"LIB","Liberty"},
        {"TAY","Taylor"},
        {"ESC","Escambia"},
        {"MAD","Madison"},
        {"UNI","Union"},
        {"FLA","Flagler"},
        {"MAN","Manatee"},
        {"VOL","Volusia"},
        {"FRA","Franklin"},
        {"MRN","Marion"},
        {"WAK","Wakulla"},
        {"GAD","Gadsden"},
        {"MRT","Martin"},
        {"WAL","Walton"},
        {"GIL","Gilchrist"},
        {"MON","Monroe"},
        {"WAS","Washington"},
        {"GLA","Glades"},
        {"NAS","Nassau"},
        {"GUL","Gulf"},
        {"OKA","Okaloosa"}
      };


  }
}

