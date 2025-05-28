using LTU2.UI;
using LTU2.Menu;

namespace LTU2;

internal class Program
{
  static void Main(string[] args)
  {
    IUI ui = new ConsoleUI();
    new MainMenu(ui).Run();
  }
}
