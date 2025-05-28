using LTU2.UI;
namespace LTU2.Menu;

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

    introText = $"== Ticket prices ==";
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

  // second argument is needed because other validation function use it
  // TODO: find a better solution
  private static int? ValidatePositiveNum(string input, int _ = 0)
  {
    return int.TryParse(input, out int num) && num > 0 ? num : null;
  }

  private static int[]? ValidateArrayPositiveNum(string input, int length)
  {
    string[] arr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (arr.Length != length) return null;

    int[] nums = new int[length];
    for (int i = 0; i < length; i++)
    {
      var num = ValidatePositiveNum(arr[i]);
      if (num == null) return null;

      nums[i] = num.Value;
    }

    return nums;
  }


  private void GetIndividualTicketPrice()
  {
    string prompt = "Please enter age.";
    var age = PromptUntilValid(prompt, ValidatePositiveNum);

    var (num, desc) = GetPrice(age.Value);
    ui.Out($"Your ticket:\n{desc}: {num}kr");
  }

  private void GetGroupTicketPrice()
  {
    string promptCount = "Please enter number of people.";
    var groupCount = PromptUntilValid(promptCount, ValidatePositiveNum);

    string promptAges = $"Please enter {groupCount} age(s) separated with whitespace.";
    var ages = PromptUntilValid(promptAges, ValidateArrayPositiveNum, groupCount.Value);

    int totalPrice = ages.Sum(a => GetPrice(a).num);

    ui.Out($"Number of people: {groupCount}");
    ui.Out($"Total price {totalPrice}");
  }

  private static (int num, string desc) GetPrice(int age)
  {
    if (age < 0) return (0, "Invalid age");
    if (age < 5) return (0, "Free of charge");
    if (age < 20) return (80, "Child price");
    if (age < 64) return (120, "Standard price");
    if (age < 100) return (90, "Senior price");
    return (0, "Free of charge");
  }
}
