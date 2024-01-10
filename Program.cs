﻿using System;

namespace MyExperience {

  class Program {

    // Variables
    static int exp = 0;
    static int lvl = 0;
    static int[] expGains = new[] {25, 50, 75, 100, 150, 200, 250, 300, 500};
    static string select;
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
          Console.Write("How much xp do U want add?\n > ");
          select = Console.ReadLine();
          Int32.TryParse(select, out numberSelect);
          int oldExp = exp;
          int totalGains = GainExp(numberSelect);
          Console.WriteLine($"Your old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalGains}");
          break;
        case 4:
          Console.Write("How much exp do you want remove?\n > ");
          select = Console.ReadLine();
          Int32.TryParse(select, out numberSelect);
          oldExp = exp;
          int totalRemove = RemoveExp(numberSelect);
          Console.WriteLine($"Your old exp is: {oldExp} and now is: {exp}\nYour total gain is: {totalRemove}");
          break;
        default:
          Console.WriteLine("This is a invalid value, plz add a valid value");
          Console.Clear();
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
