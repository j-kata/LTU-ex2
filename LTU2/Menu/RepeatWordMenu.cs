using System.Data;
using LTU2.UI;

namespace LTU2.Menu;

internal class RepeatWordMenu : Menu
{
  private int Count { get; set; }

  public RepeatWordMenu(IUI ui, int count) : base(ui)
  {
    Count = count;
    introText = $"== Repeating word #{Count} times ==";
  }

  // second argument is needed because other validation function use it
  // TODO: find a better solution
  private static string? ValidateString(string input, int _ = 0)
  {
    return !string.IsNullOrWhiteSpace(input) ? input : null;
  }

  protected override void HandleDefault()
  {
    string prompt = "Please enter text you want to repeat.";

    var word = PromptUntilValid(prompt, ValidateString);
    var repeatedWord = RepeateWord(word, Count);

    ui.Out($"Here is you text repeated {Count} times:\n{repeatedWord}");
  }

  private static string RepeateWord(string input, int count)
  {
    var repeatedWords = Enumerable.Repeat(input, count)
                                  .Select((item, index) => $"{index + 1}.{item}");
    return string.Join(", ", repeatedWords);
  }
}