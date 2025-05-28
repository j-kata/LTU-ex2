namespace LTU2.UI;

internal class ConsoleUI : IUI
{
  public string Input()
  {
    return Console.ReadLine() ?? string.Empty;
  }

  public void Output(string line)
  {
    Console.WriteLine(line);
  }
}
