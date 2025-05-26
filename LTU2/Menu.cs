namespace LTU2;

internal abstract class Menu
{
  private bool IsRunning { get; set; } = true;
  public void Show()
  {
    while (IsRunning)
    {
      PrintMenu();
      var input = GetUserInput();
      HandleAction(input);
    }
  }
  protected abstract void PrintMenu();
  protected abstract void HandleAction(string input);

  protected static string GetUserInput()
  {
    var input = Console.ReadLine();
    return input == null ? "" : input.Trim();
  }

  protected void ExitProgram()
  {
    IsRunning = false; 
  }

  protected static void InvalidInput()
  {
    Console.WriteLine("Invalid input. Try again.");
  }
}
