namespace LTU2;

internal class SelectMenu : Menu
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
        SelectWord();
        break;
      default:
        InvalidInput();
        break;
    }
  }

  private static void SelectWord(int num = 3)
  {
    Console.WriteLine("Please enter text (min 3 word).");
    var input = GetUserInput();

    var words = input.Split(" ");
    if (words.Length < num) return;

    Console.WriteLine($"The word #{num} is {words[num - 1]}");
  }
}