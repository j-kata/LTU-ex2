using LTU2.UI;

namespace LTU2;

internal class MainMenuOptions
{
  public const string TicketPriceChoice = "1";
  public const string RepeatWordChoice = "2";
  public const string ThirdWordChoice = "3";
}

internal class MainMenu : Menu
{
  public MainMenu(IUI ui) : base(ui)
  {
    introText = "You've reached the main menu.\nNavigate by entering numbers to test different features.";

    choices = new Dictionary<string, string>()
    {
      { DefaultMenuOptions.ReturnOption, "Exit" },
      { MainMenuOptions.TicketPriceChoice, "Get Ticket Price" },
      { MainMenuOptions.RepeatWordChoice, "Repeat 10 times" },
      { MainMenuOptions.ThirdWordChoice, "Select third word" },
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
        new RepeatWordMenu(ui).Run();
        break;
      case MainMenuOptions.ThirdWordChoice:
        new SelectWordMenu(ui).Run();
        break;
      default:
        InvalidInput();
        break;
    }
  }
}
