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
    static string? select = "";
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
      "Cerqueira",
    };

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
          AdminMenu();
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

    static void AdminAddExperience()
    {

      int totalGains = 0;
      oldExp = exp;
      ExpControl("adminAdd", out totalGains);
      Console.WriteLine($"\nYour old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalGains}");
    }

    static void AdminRemoveExperience()
    {

      int totalRemove = 0;
      oldExp = exp;
      ExpControl("adminRemove", out totalRemove);
      Console.WriteLine($"\nYour old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalRemove}");
    }

    static bool IsAdmin(string user)
    {

      if (adminsList.Contains(user)) {
        return true;
      }
      return false;
    }

    static void AdminMenu()
    {

      Console.Clear();
      Console.Write("Who are you?\n\t> ");
      string? userName = Console.ReadLine();
      Console.Clear();
      if(userName != null && !IsAdmin(userName)) {
        Console.WriteLine($"{userName} isn't a admin");
        return;
      }
      string[] adminOptions = new string[] {
        "View admin list",
        "View all members xp",
        "Add admin exp in any member",
        "Remove admin exp in any member",
        "Add new admin",
        "Remove a admin",
        "Close",
      };
      BuildOptions(adminOptions, message: $"My lord, {userName}, what do you wanna do?");
      switch(selectedOption)
      {

        case 1:
          ShowAdmins();
          break;
        case 2:
          Console.Clear();
          Console.WriteLine("In workin...");
          break;
        case 3:
          AdminAddExperience();
          break;
        case 4:
          AdminRemoveExperience();
          break;
        case 5:
          AdminAdd();
          break;
        case 6:
          AdminRemove();
          break;
        case 7:
          Console.Clear();
          break;
        default:
          HandleInvalidOption();
          break;
      }

    }

    static void ShowAdmins()
    {

      Console.Clear();
      Console.WriteLine("Admins list:\n");
      foreach (string admin in adminsList)
      {

        Console.WriteLine($"[{Array.IndexOf(adminsList, admin) + 1}]\t {admin}");
      }
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

        int checkArrayLength = (array.Length == 0 ? 0 : 1);

        Console.Write($"\nChoose your option [{checkArrayLength}, {array.Length}]: ");

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
      } else if (mode == "adminAdd") {

        Console.Clear();
        Console.Write("How much?\n\t > ");
        Int32.TryParse(Console.ReadLine(), out amount);
        int totalGains = amount - exp;
        exp += amount;
      } else if (mode == "adminRemove") {

        Console.Clear();
        Console.Write("How much?\n\t > ");
        Int32.TryParse(Console.ReadLine(), out amount);
        int totalRemove = exp - amount;
        exp -= amount;
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
      } else if (mode == "adminAdd") {

        Console.Clear();
        Console.Write("How much?\n\t > ");
        Int32.TryParse(Console.ReadLine(), out amount);
        int totalGains = amount - exp;
        exp += amount;

        total = totalGains;
      } else if (mode == "adminRemove") {

        Console.Clear();
        Console.Write("How much?\n\t > ");
        Int32.TryParse(Console.ReadLine(), out amount);
        int totalRemove = exp - amount;
        exp -= amount;

        total = totalRemove;
      }
    }

    static void AdminControl(string mode)
    {
      if (mode == "add") {

        string? admin = Console.ReadLine();

        if (admin != null) {

        Array.Resize(ref adminsList,  adminsList.Length + 1);
        adminsList[adminsList.Length - 1] = admin;
        }
      } else if (mode == "remove") {

        string? admin = Console.ReadLine();
        int indexToRemove = Array.IndexOf(adminsList, admin);

        if (indexToRemove != -1 && admin != null) {
          for (int i = indexToRemove; i < adminsList.Length - 1; i++) {
            adminsList[i] = adminsList[i + 1];
          }
          Array.Resize(ref adminsList, adminsList.Length - 1);
        }
      }
    }

    static void AdminControl(string mode, out string item)
    {
      item = "";

      if (mode == "add") {

        string? admin = Console.ReadLine();

        if (admin != null) {

        Array.Resize(ref adminsList,  adminsList.Length + 1);
        adminsList[adminsList.Length - 1] = admin;

        item = admin;
        }
      } else if (mode == "remove") {

        string? admin = Console.ReadLine();
        int indexToRemove = Array.IndexOf(adminsList, admin);

        if (indexToRemove != -1 && admin != null) {
          for (int i = indexToRemove; i < adminsList.Length - 1; i++) {
            adminsList[i] = adminsList[i + 1];
          }
          Array.Resize(ref adminsList, adminsList.Length - 1);

          item = admin;
        }
      }
    }
    
    static void AdminAdd()
    {

      Console.Clear();
      string itemAdd = "";
      Console.Write($"Which person will be a admin\n\t > ");
      AdminControl("add", out itemAdd);
      Console.WriteLine($"\"{itemAdd}\" has add in the admin list");
    }

    static void AdminRemove()
    {

      Console.Clear();
      string itemRemoved = "";
      Console.Write($"Which admin you will remove?\n\t > ");
      AdminControl("remove", out itemRemoved);
      Console.WriteLine($"\"{itemRemoved}\" has add in the admin list");
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
