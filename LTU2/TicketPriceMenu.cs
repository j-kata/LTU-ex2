using LTU2.UI;
namespace LTU2;

internal class TicketPriceMenuOptions
{
  public const string IndividualOption = "1";
  public const string GroupOption = "2";
}

internal class TicketPriceMenu : Menu
{
  public TicketPriceMenu(IUI ui) : base(ui)
  {
    choices = new Dictionary<string, string>()
    {
      { DefaultMenuOptions.ReturnOption, "Go back to main menu" },
      { TicketPriceMenuOptions.IndividualOption, "Get individual ticket price" },
      { TicketPriceMenuOptions.GroupOption, "Get group ticket price" }
    };
  }

  protected override void HandleInput(string input)
  {
    switch (input)
    {
      case DefaultMenuOptions.ReturnOption:
        Close();
        break;
      case TicketPriceMenuOptions.IndividualOption:
        GetIndividualTicketPrice();
        break;
      case TicketPriceMenuOptions.GroupOption:
        GetGroupTicketPrice();
        break;
      default:
        InvalidInput();
        break;
    }
  }

  private void GetIndividualTicketPrice()
  {
    Console.WriteLine("Please enter age.");
    var input = ui.In();

    if (!ValidateNum(input, out var age)) return;

    var (_, desc) = GetPrice(age);
    Console.WriteLine(desc);
  }

  private void GetGroupTicketPrice()
  {
    Console.WriteLine("Please enter number of people.");
    var input = ui.In();

    if (!ValidateNum(input, out var count)) return;

    int totalPrice = 0;

    Console.WriteLine("Please enter each age on separate line.");
    for (var i = 0; i < count; i++)
    {
      var ageInput = ui.In();
      if (!ValidateNum(ageInput, out var age)) return;

      totalPrice += GetPrice(age).num;
    }
    Console.WriteLine($"Number of people: {count}");
    Console.WriteLine($"Total price {totalPrice}");
  }

  private static (int num, string desc) GetPrice(int age)
  {
    if (age < 0)
    {
      return (0, "Invalid age");
    }
    else if (age < 5)
    {
      return (0, "Free of charge");
    }
    else if (age < 20)
    {
      return (80, "Child price: 80kr");
    }
    else if (age < 64)
    {
      return (120, "Standard price: 120kr");
    }
    else if (age < 100)
    {
      return (90, "Senior price: 90kr");
    }
    else
    {
      return (0, "Free of charge");
    }
  }

  private static bool ValidateNum(string input, out int num)
  {
    if (!int.TryParse(input, out num) || num < 0)
    {
      InvalidInput();
      return false;
    }
    return true;
  }
}
