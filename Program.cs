using System;

namespace MyExperience {

  class Program {

    // Variables
    static int exp = 0;
    static int oldExp = exp;
    static int lvl = 0;
    static int[] expGains = new[] {25, 50, 75, 100, 150, 200, 250, 300, 500};
    static string select = "";
    static int numberSelect = 0;
    static string[] wannaDo = new[]
    {
      "Show Level",
      "How much for the next level",
      "Add exp",
      "Remove exp",
      "Admin Power",
      "Close",
    };
    static string[] adminsList = new string[] {
      "Teagar",
    };
    static string invalidMessage = "This is a invalid value, plz add a valid value";
    static bool isAdmin = false;

    // Start
    static void Start() {

      Console.WriteLine("\t\tWELCOME!\n");

      BuildOptions(wannaDo);

      switch (numberSelect)
      {

        case 1:
          Console.WriteLine($"Your current level is: {lvl}\n");
          break;
        case 2:
          Console.WriteLine("In workin...");
          break;
        case 3:
          int totalGains = 0;
          oldExp = exp;
          ExpControl("add", out totalGains);
          Console.WriteLine($"\nYour old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalGains}");
          break;
        case 4:
          int totalRemove = 0;
          oldExp = exp;
          ExpControl("remove", out totalRemove);
          Console.WriteLine($"\nYour old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalRemove}");
          break;
        case 5:
          if (isAdmin == false) {
            Console.WriteLine("You don't have admin powa!");
            return;
          }
          Console.WriteLine("You have admin power");
          break;
        case 6:
          Console.Clear();
          break;
        default:
          Console.Clear();
          Console.WriteLine($"\n{invalidMessage}\n");
          Start();
          break;
      }
      // GoBack();
    }

    static void Main(string[] args)

    {

      Console.Clear();
      Start();
    }
    
    // Functions 

    static void BuildOptions(string[] array, string message = "What do you wanna do?")
    {

      Console.WriteLine($"{message}\n");

      foreach (string item in array)
      {

        int index = Array.IndexOf(array, item) + 1;
        string option = $"[{index}]\t{item}";


        Console.WriteLine(option); 
      }

      Console.Write($"\nChoose your option [1, {array.Length}]: ");

      select = Console.ReadLine();

      Int32.TryParse(select, out numberSelect);
    }

    static void BuildOptions(int[] array, string message = "What do you wanna do?", string sufix = "")
    {

      Console.WriteLine($"{message}\n");

      foreach (int item in array)
      {

        int index = Array.IndexOf(array, item) + 1;
        string option = $"[{index}]\t{item}{sufix}";


        Console.WriteLine(option); 
      }

      Console.Write($"\nChoose your option [1, {array.Length}]: ");

      select = Console.ReadLine();

      Int32.TryParse(select, out numberSelect);
    }

    static void ExpControl(string mode)
    {
      int amount = 0;
      int total = 0;

      if (mode == "add") {

        Console.Clear();
        BuildOptions(expGains, "How much?", sufix: "xp");
        while (numberSelect > expGains.Length || numberSelect < 1) {

          Console.Clear();
          Console.WriteLine($"\n{invalidMessage}\n");
          BuildOptions(expGains, "How much?", sufix: "xp");
        }
        amount = expGains[numberSelect - 1];
        int totalGains = amount - exp;
        exp += amount;

        total = totalGains;
      } else if (mode == "remove") {
        
        Console.Clear();
        BuildOptions(expGains, "How much?");
        while (numberSelect > expGains.Length || numberSelect < 1) {

          Console.Clear();
          Console.WriteLine($"\n{invalidMessage}\n");
          BuildOptions(expGains, "How much?", sufix: "xp");
        }
        amount = expGains[numberSelect - 1];
        int totalRemove = exp - amount;
        exp -= amount;

        total = totalRemove;
      }
    }

    static void ExpControl(string mode, out int total)
    {
      int amount = 0;
      total = 0;

      if (mode == "add") {

        Console.Clear();
        BuildOptions(expGains, "How much?", sufix: "xp");
        while (numberSelect > expGains.Length || numberSelect < 1) {

          Console.Clear();
          Console.WriteLine($"\n{invalidMessage}\n");
          BuildOptions(expGains, "How much?", sufix: "xp");
        }
        amount = expGains[numberSelect - 1];
        int totalGains = amount - exp;
        exp += amount;

        total = totalGains;
      } else if (mode == "remove") {
        
        Console.Clear();
        BuildOptions(expGains, "How much?");
        while (numberSelect > expGains.Length || numberSelect < 1) {

          Console.Clear();
          Console.WriteLine($"\n{invalidMessage}\n");
          BuildOptions(expGains, "How much?", sufix: "xp");
        }
        amount = expGains[numberSelect - 1];
        int totalRemove = exp - amount;
        exp -= amount;

        total = totalRemove;
      }
    }

    static int GainExp(int amount)
    {

      int totalGains = amount - exp;
      exp += amount;

      return totalGains;
    }

    static int RemoveExp(int amount)
    {

      int totalRemove = exp - amount;
      exp -= amount;

      return totalRemove;
    }
  }
}
