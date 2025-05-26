using System.Data;
using System.Text;

namespace LTU2;

internal class RepeatMenu : Menu
{
  protected override void PrintMenu()
  {
    Console.WriteLine("");
    Console.WriteLine("0. Go back to main menu");
    Console.WriteLine("1. Enter text");
    Console.WriteLine("");
  }

  protected override void HandleAction(string input)
  {
    switch (input)
    {
      case "0":
        ExitProgram();
        break;
      case "1":
        RepeatText();
        break;
      default:
        InvalidInput();
        break;
    }
  }

  private static void RepeatText(int count = 10)
  {
    Console.WriteLine("Please enter text you want to repeat.");
    var input = GetUserInput();

    var repeated = Enumerable.Repeat(input, count).Select((item, index) => $"{index + 1}.{item}");
    Console.WriteLine(string.Join(", ", repeated));
  }
}