using LTU2.UI;

namespace LTU2;

internal class SelectWordMenu : Menu
{
  private int WordIndex { get; set; }

  public SelectWordMenu(IUI ui, int wordIndex = 3) : base(ui)
  {
    WordIndex = wordIndex;
    introText = $"== Selecting word #{WordIndex} ==";
  }

  protected override void HandleDefault()
  {
    string prompt = $"Please enter text (min {WordIndex} word).";
    bool validate(string input) => SplitLine(input).Length >= WordIndex;

    var validLine = PromptUntilValid(prompt, validate);
    var word = SelectWord(validLine, WordIndex);

    var result = (word == null) ? "Not enough words" : $"The word #{WordIndex} is {word}";
    ui.Out(result);
  }

  private static string[] SplitLine(string line)
  {
    var cleanedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(w => w.Trim(',', '.', '!', '?'));

    return [.. cleanedLine];
  }


  private static string? SelectWord(string line, int count)
  {
    var words = SplitLine(line);
    if (words.Length < count) return null; // in case there is still a bug

    return words[count - 1];
  }
}