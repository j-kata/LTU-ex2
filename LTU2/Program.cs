namespace LTU2;

internal class Program
{
    private static bool IsRunning { get; set; } = true;
    static void Main(string[] args)
    {
        while (IsRunning)
        {
            PrintMainMenu();
            var input = Console.ReadLine()?.Trim();
            if (input != null) ChooseAction(input);
        }
    }

    static void PrintMainMenu()
    {
        Console.WriteLine("You’ve reached the main menu. Navigate by entering numbers to test different features.");

    }


    static void ChooseAction(string num)
    {
        switch (num)
        {
            case "0":
                IsRunning = false;
                break;
            default:
                Console.WriteLine("Invalid input. Try again");
                break;
        }
    }
}
