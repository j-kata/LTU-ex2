using LTU2.UI;

namespace LTU2.Menu;

internal class MainMenuOptions
{
  public const string TicketPriceChoice = "1";
  public const string RepeatWordChoice = "2";
  public const string SelectWordChoice = "3";
}

internal class MainMenu : Menu
{
  private const int RepeatTimes = 10;
  private const int SelectWordIndex = 3;

  public MainMenu(IUI ui) : base(ui)
  {
    introText = "You've reached the main menu.\nNavigate by entering numbers to test different features.";

    choices = new Dictionary<string, string>()
    {
      { DefaultMenuOptions.ReturnOption, "Exit" },
      { MainMenuOptions.TicketPriceChoice, "Get Ticket Price" },
      { MainMenuOptions.RepeatWordChoice, $"Repeat {RepeatTimes} times" },
      { MainMenuOptions.SelectWordChoice, $"Select word #{SelectWordIndex}" },
    };
  }

  protected override void HandleInput(string input)
  {
    switch (input)
    {
      case DefaultMenuOptions.ReturnOption:
        Close();
        break;
      case MainMenuOptions.TicketPriceChoice:
        new TicketPriceMenu(ui).Run();
        break;
      case MainMenuOptions.RepeatWordChoice:
        new RepeatWordMenu(ui, RepeatTimes).Run();
        break;
      case MainMenuOptions.SelectWordChoice:
        new SelectWordMenu(ui, SelectWordIndex).Run();
        break;
      default:
        InvalidInput();
        break;
    }
  }
}
