namespace LTU2.UI;

internal class ConsoleUI : IUI
{
  public string In()
  {
    return Console.ReadLine()?.Trim() ?? string.Empty;
  }

  public void Out(string line)
  {
    Console.WriteLine(line);
  }
}
