using System.Data;

namespace LTU2;

internal class RepeatMenu : Menu
{
  protected override void HandleTextInput()
  {
    Console.WriteLine("Please enter text you want to repeat.");
    var input = GetInput();

    var repeated = Enumerable.Repeat(input, 10).Select((item, index) => $"{index + 1}.{item}");
    Console.WriteLine(string.Join(", ", repeated));
  }
}