using System.Data;
using LTU2.UI;

namespace LTU2;

internal class RepeatWordMenu : Menu
{
  private int Count { get; set; }

  public RepeatWordMenu(IUI ui, int count = 10) : base(ui)
  {
    Count = count;
    introText = $"== Repeating word #{Count} times ==";
  }

  protected override void HandleDefault()
  {
    string prompt = "Please enter text you want to repeat.";
    bool validate(string input) => !string.IsNullOrWhiteSpace(input);

    var word = PromptUntilValid(prompt, validate);
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