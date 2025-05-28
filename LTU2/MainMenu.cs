namespace LTU2;

internal class MainMenu : Menu
{
  private const string TicketPriceChoice = "1";
  private const string RepeatWordChoice = "2";
  private const string ThirdWordChoice = "3";
  public MainMenu()
  {
    choices = new Dictionary<string, string>()
    {
      { ReturnChoice, "Exit" },
      { TicketPriceChoice, "Get Ticket Price" },
      { RepeatWordChoice, "Repeat 10 times" },
      { ThirdWordChoice, "Select third word" },
    };
  }
  protected override string GetIntroText()
  {
    return "You've reached the main menu.\nNavigate by entering numbers to test different features.";
  }

  protected override void HandleInput(string input)
  {
    switch (input)
    {
      case ReturnChoice:
        Close();
        break;
      case TicketPriceChoice:
        new TicketPriceMenu().Run();
        break;
      case RepeatWordChoice:
        new RepeatMenu().Run();
        break;
      case ThirdWordChoice:
        new SelectMenu().Run();
        break;
      default:
        InvalidInput();
        break;
    }
  }
}
