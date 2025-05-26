namespace LTU2;

internal class Program
{
    private static bool IsRunning { get; set; } = true;
    static void Main(string[] args)
    {
        while (IsRunning)
        {
            PrintMainMenu();
            var input = GetUserInput();
            ChooseAction(input);
        }
    }

    static void PrintMainMenu()
    {
        Console.WriteLine("You've reached the main menu. Navigate by entering numbers to test different features.");
        Console.WriteLine("1. Get Ticket Price");

    }

    static string GetUserInput()
    {
        var input = Console.ReadLine();
        return input == null ? "" : input.Trim();
    }


    static void ChooseAction(string num)
    {
        switch (num)
        {
            case "0":
                IsRunning = false;
                break;
            case "1":
                GetTicketPrice();
                break;
            default:
                Console.WriteLine("Invalid input. Try again");
                break;
        }
    }

    static void GetTicketPrice()
    {
        Console.Clear();
        Console.WriteLine("To find out the price of inidvidual ticket, please type your age.");
        var input = GetUserInput();
        if (!int.TryParse(input, out var age))
        {
            Console.WriteLine("Ivalid input. You will be back to the main menu");
            return;
        }
        if (age < 0)
        {
            Console.WriteLine("Ivalid input. You will be back to the main menu");
            return;
        }
        else if (age < 20)
        {
            Console.WriteLine("Child price: 80kr");
        }
        else if (age < 64)
        {
            Console.WriteLine("Standard price: 120kr");

        }
        else
        {
            Console.WriteLine("Senior price: 90kr");
        }
    }


}
