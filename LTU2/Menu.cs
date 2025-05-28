using LTU2.UI;

namespace LTU2;

internal class DefaultMenuOptions
{
  public const string ReturnOption = "0";
  public const string DefaultOption = "1";
}

internal class Menu(IUI ui)
{
  protected IUI ui = ui;
  private bool IsRunning { get; set; } = true;

  // default menu title
  protected string introText = "== Menu ==";

  // default menu
  protected Dictionary<string, string> choices = new()
  {
    { DefaultMenuOptions.ReturnOption, "Go back to main menu" },
    { DefaultMenuOptions.DefaultOption, "Enter Text" },
  };

  // main loop
  public void Run()
  {
    while (IsRunning)
    {
      // show menu
      Show();

      // get input
      var input = ui.In();

      // handle input
      HandleInput(input);
    }
  }

  // construct menu outline from class data
  protected virtual void Show()
  {
    ui.Out();
    ui.Out(introText);

    foreach (var choice in choices)
      ui.Out($"{choice.Key}. {choice.Value}");

    ui.Out();
  }

  // default input handle
  protected virtual void HandleInput(string input)
  {
    switch (input)
    {
      case DefaultMenuOptions.ReturnOption:
        Close();
        break;
      case DefaultMenuOptions.DefaultOption:
        HandleDefault();
        break;
      default:
        InvalidInput();
        break;
    }
  }

  // to exit main loop
  protected void Close()
  {
    IsRunning = false;
  }

  // handle default menu's function
  protected virtual void HandleDefault() { }


  protected static void InvalidInput()
  {
    Console.WriteLine("Invalid input. Try again.");
  }
}
