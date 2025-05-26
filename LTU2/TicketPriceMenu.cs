namespace LTU2;

internal class TicketPriceMenu : Menu
{
  protected override void PrintMenu()
  {
    Console.WriteLine("");
    Console.WriteLine("0. Go back to main menu");
    Console.WriteLine("1. Get individual ticket price");
    Console.WriteLine("2. Get group ticket price");
    Console.WriteLine("");
  }

  protected override void HandleAction(string input)
  {
    switch (input)
    {
      case "1":
        GetIndividualTicketPrice();
        break;
      case "2":
        GetGroupTicketPrice();
        break;
      case "0":
        ExitProgram();
        break;
      default:
        InvalidInput();
        break;
    }
  }

  private void GetIndividualTicketPrice()
  {
    Console.WriteLine("Please enter age.");
    var input = GetUserInput();

    if (!ValidateNum(input, out var age)) return;

    var (_, desc) = GetPrice(age);
    Console.WriteLine(desc);
  }

  private void GetGroupTicketPrice()
  {
    Console.WriteLine("Please enter number of people.");
    var input = GetUserInput();

    if (!ValidateNum(input, out var count)) return;

    int totalPrice = 0;

    Console.WriteLine("Please enter each age on separate line.");
    for (var i = 0; i < count; i++)
    {
      var ageInput = GetUserInput();
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
    else if (age < 20)
    {
      return (80, "Child price: 80kr");
    }
    else if (age < 64)
    {
      return (120, "Standard price: 120kr");
    }
    else
    {
      return (90, "Senior price: 90kr");
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
