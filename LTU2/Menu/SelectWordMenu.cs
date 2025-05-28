using LTU2.UI;

namespace LTU2.Menu;

internal class SelectWordMenu : Menu
{
  private int WordIndex { get; set; }

  public SelectWordMenu(IUI ui, int wordIndex) : base(ui)
  {
    WordIndex = wordIndex;
    introText = $"== Selecting word #{WordIndex} ==";
  }

  private static string[]? ValidateWordCount(string input, int count)
  {
    var words = SplitLine(input);
    return (words.Length >= count) ? words : null;
  }

  protected override void HandleDefault()
  {
    string prompt = $"Please enter text (min {WordIndex} word).";

    // pass validate function
    var words = PromptUntilValid(prompt, ValidateWordCount, WordIndex);
    var word = words[WordIndex - 1];

    ui.Out($"The word #{WordIndex} is {word}");
  }

  private static string[] SplitLine(string line)
  {
    var cleanedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(w => w.Trim(',', '.', '!', '?'));

    return [.. cleanedLine];
  }
}