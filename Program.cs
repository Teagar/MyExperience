using System;

namespace MyExperience {

  class Program {

    // Variables
    static int exp = 0;
    static int oldExp = exp;
    static int lvl = 0;
    static int expValue1 = 25;
    static int expValue2 = expValue1 * 3;
    static int expValue3 = expValue1 * 10;
    static int[] expGains = new[] {
      expValue1,
      expValue1<<1,
      expValue2,
      expValue1<<2,
      expValue2<<1,
      expValue1<<3,
      expValue3,
      expValue2<<2,
      expValue3<<1
    };
    static string select = "";
    static int selectedOption = 0;
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

    static bool isAdmin = false;

    // Start
    static void Start() {

      Console.WriteLine("\t\tWELCOME!\n");

      BuildOptions(wannaDo);

      switch (selectedOption)
      {

        case 1:
          ShowLevel();
          break;
        case 2:
          ShowNextLevelProgress();
          break;
        case 3:
          AddExperience();
          break;
        case 4:
          RemoveExperience();
          break;
        case 5:
          CheckAdmin();
          break;
        case 6:
          Console.Clear();
          break;
        default:
          HandleInvalidOption();
          break;
      }
    }

    static void Main(string[] args)

    {

      Console.Clear();
      Start();
    }
    
    // Functions 

    static void ShowLevel()
    {

      Console.WriteLine($"Your current level is: {lvl}\n");
    }

    static void ShowNextLevelProgress()
    {

      Console.WriteLine("In workin...");
    }

    static void AddExperience()
    {

      int totalGains = 0;
      oldExp = exp;
      ExpControl("add", out totalGains);
      Console.WriteLine($"\nYour old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalGains}");
    }

    static void RemoveExperience()
    {

      int totalRemove = 0;
      oldExp = exp;
      ExpControl("remove", out totalRemove);
      Console.WriteLine($"\nYour old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalRemove}");
    }

    static void CheckAdmin()
    {

      if (isAdmin == false) {
        Console.WriteLine("You don't have admin powa!");
        return;
      }
      Console.WriteLine("You have admin power");
    }

    static void HandleInvalidOption()
    {
      Console.Clear();
      Start();
    }

    static void BuildOptions(
        string[] array,
        string message = "What do you wanna do?",
        string sufix = "",
        string error = "This is a invalid value, plz add a valid value")
    {

      int count = 0;
      do {

        if (count > 0) {

          Console.Clear();
          Console.WriteLine($"{error}\n");
        }

        Console.WriteLine($"{message}\n");

        foreach (string item in array)
        {

          int index = Array.IndexOf(array, item) + 1;
          string option = $"[{index}]\t{item}{sufix}";


          Console.WriteLine(option); 
        }

        Console.Write($"\nChoose your option [1, {array.Length}]: ");

        select = Console.ReadLine();

        Int32.TryParse(select, out selectedOption);
        
        count++;

      } while(selectedOption > array.Length || selectedOption < 1);

    }

    static void BuildOptions(
        int[] array,
        string message = "What do you wanna do?",
        string sufix = "",
        string error = "This is a invalid value, plz add a valid value")
    {

      int count = 0;
      do {

        if (count > 0) {

          Console.Clear();
          Console.WriteLine($"{error}\n");
        }

        Console.WriteLine($"{message}\n");

        foreach (int item in array)
        {

          int index = Array.IndexOf(array, item) + 1;
          string option = $"[{index}]\t{item}{sufix}";


          Console.WriteLine(option); 
        }

        Console.Write($"\nChoose your option [1, {array.Length}]: ");

        select = Console.ReadLine();

        Int32.TryParse(select, out selectedOption);

        count++;

      } while(selectedOption > array.Length || selectedOption < 1);

    }

    static void ExpControl(string mode)
    {
      int amount = 0;
      int total = 0;

      if (mode == "add") {

        Console.Clear();
        BuildOptions(expGains, "How much?", sufix: "xp");
        amount = expGains[selectedOption - 1];
        int totalGains = amount - exp;
        exp += amount;

        total = totalGains;
      } else if (mode == "remove") {
        
        Console.Clear();
        BuildOptions(expGains, "How much?");
        amount = expGains[selectedOption - 1];
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
        amount = expGains[selectedOption - 1];
        int totalGains = amount - exp;
        exp += amount;

        total = totalGains;
      } else if (mode == "remove") {
        
        Console.Clear();
        BuildOptions(expGains, "How much?");
        amount = expGains[selectedOption - 1];
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
