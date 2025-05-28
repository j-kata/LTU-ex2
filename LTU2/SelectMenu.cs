namespace LTU2;

internal class SelectMenu : Menu
{
  protected override void HandleTextInput()
  {
    Console.WriteLine("Please enter text (min 3 word).");
    var input = GetInput();

    var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (words.Length < 3) return;

    Console.WriteLine($"The word #{3} is {words[3 - 1]}");
  }
}