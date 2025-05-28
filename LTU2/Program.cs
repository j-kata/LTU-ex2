using System.Reflection.Metadata;

namespace LTU2;

internal class Program
{
  private static bool IsRunning { get; set; } = true;
  static void Main(string[] args)
  {
    new MainMenu().Run();
  }
}
