namespace LTU2;

internal class Menu
{
  private bool IsRunning { get; set; } = true;
  protected const string ReturnChoice = "0";
  protected const string EnterTextChoice = "1";

  protected Dictionary<string, string> choices = new Dictionary<string, string>()
  {
    { ReturnChoice, "Go back to main menu" },
    { EnterTextChoice, "Enter Text" },
  };

  // main loop
  public void Run()
  {
    Console.Write(GetIntroText());
    while (IsRunning)
    {
      // show menu
      Show();

      // get input
      var input = GetInput();

      // handle input
      HandleInput(input);
    }
  }

  protected virtual string GetIntroText()
  {
    return "== Menu ==";
  }

  // construct menu outline from class data
  protected virtual void Show()
  {
    Console.WriteLine();
    foreach (var choice in choices)
    {
      Console.WriteLine($"{choice.Key}. {choice.Value}");
    }
    Console.WriteLine();
  }
  protected virtual void HandleInput(string input)
  {
    switch (input)
    {
      case ReturnChoice:
        Close();
        break;
      case EnterTextChoice:
        HandleTextInput();
        break;
      default:
        InvalidInput();
        break;
    }
  }

  // exit main loop
  protected void Close()
  {
    IsRunning = false;
  }

  protected virtual void HandleTextInput() { }

  protected static string GetInput()
  {
    var input = Console.ReadLine();
    return input == null ? "" : input.Trim();
  }

  protected static void InvalidInput()
  {
    Console.WriteLine("Invalid input. Try again.");
  }
}
