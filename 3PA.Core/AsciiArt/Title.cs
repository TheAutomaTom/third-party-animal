namespace _3PA.Core.AsciiArt
{
  using System;
  public static class Title
  {    
    public static void Print(string subtext = "Our Voter Data API v220107")
    {

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
      Console.ForegroundColor = ConsoleColor.Red;
                                 Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄-~▄▄─ ▄█_ ▄▀~─");

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("█─▄─▄─█─█─█▄─██▄─▄▄▀█▄─▄▄▀█");
      Console.ForegroundColor = ConsoleColor.White;
                              Console.WriteLine("██▄─▄▄─██▀▄─▄█▄─▄▄▀█─▄─▄─█─▄─▄─█▄─█─▄████▀▄─▄█▄─▀█▄─▄█▄─██▄─▀█▀─▄██▀▄─▄█▄─▄███▄─~");

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("███─███─▄─██─███─▄─▄██─██─█");
      Console.ForegroundColor = ConsoleColor.Red;
                              Console.WriteLine("███─▄▄▄██─▀─███─▄─▄███─█████─████▄─▄█████─▀─███─█▄▀─███─███─█▄█─███─▀─███─██▀█▄▄▄─");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("██▄▄▄██▄█▄█▄▄▄█▄▄█▄▄█▄▄▄▄█████▄████▄▄█▄▄█▄▄█▄▄██▄▄▄███▄▄▄███▄▄█████▄▄█▄▄█▄▄▄██▄▄█▄▄▄█▄▄▄█▄▄▄█▄▄█▄▄█▄▄▄▄▄█▄▄─`");
      Console.BackgroundColor = ConsoleColor.Red;
      Console.ForegroundColor = ConsoleColor.Black;
      var subtextLine = ("                                                                          ▄  ▄ █▀._▀ █▀  ▄.▄▀▄▀▄▀▄─~ ▄█▄██");
      Console.WriteLine($"  {subtext}{subtextLine.Remove(0, subtext.Length  )}");
      Console.ResetColor();
      Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀   ▀   ▀ ▀ ▀     ▀~─ ▀─._  .▀~-   ");
    }
  }
}
