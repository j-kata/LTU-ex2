using System.Data;
using LTU2.UI;

namespace LTU2;

internal class RepeatMenu(IUI ui) : Menu(ui)
{
  protected override void HandleDefault()
  {
    Console.WriteLine("Please enter text you want to repeat.");
    var input = ui.In();

    var repeated = Enumerable.Repeat(input, 10).Select((item, index) => $"{index + 1}.{item}");
    Console.WriteLine(string.Join(", ", repeated));
  }
}