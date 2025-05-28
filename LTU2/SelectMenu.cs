using LTU2.UI;

namespace LTU2;

internal class SelectMenu(IUI ui) : Menu(ui)
{
  protected override void HandleDefault()
  {
    Console.WriteLine("Please enter text (min 3 word).");
    var input = ui.In();

    var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (words.Length < 3) return;

    Console.WriteLine($"The word #{3} is {words[3 - 1]}");
  }
}