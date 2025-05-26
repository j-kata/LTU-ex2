namespace LTU2;

internal class MainMenu : Menu
{
  protected override void PrintMenu()
  {
    Console.Clear();
    Console.WriteLine("You've reached the main menu.\nNavigate by entering numbers to test different features.");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Get Ticket Price");
    Console.WriteLine("2. Repeat 10 times");
    Console.WriteLine("");
  }
  protected override void HandleAction(string input)
  {
    switch (input)
    {
      case "0":
        ExitProgram();
        break;
      case "1":
        new TicketPriceMenu().Show();
        break;
      case "2":
        new RepeatMenu().Show();
        break;
      default:
        InvalidInput();
        break;
    }
  }
}
