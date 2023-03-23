// Square(n) Sum: https://www.codewars.com/kata/515e271a311df0350d00000f/
// Complete the square sum function so that it squares each number passed into it and then sums the results together.
// For example, for [1, 2, 2] it should return 9 because 1^2 + 2^2 + 2^2 = 9.
namespace SquareSum
{
  using System.Linq;

  public static class Kata
  {
    public static int SquareSum(int[] numbers)
      => numbers.Sum(x => x * x);
  }
}

// Are You Playing Banjo?: https://www.codewars.com/kata/53af2b8861023f1d88000832/
// Create a function which answers the question "Are you playing banjo?".
// If your name starts with the letter "R" or lower case "r", you are playing banjo!
// The function takes a name as its only argument, and returns one of the following strings:
// name + " plays banjo"
// name + " does not play banjo"
// Names given are always valid strings.
namespace AreYouPlayingBanjo
{
  public class Kata
  {
    public static string AreYouPlayingBanjo(string name)
      => $"{name} {(char.ToLower(name[0]) == 'r' ? "plays" : "does not play")} banjo";
  }
}

// Return Negative: https://www.codewars.com/kata/55685cd7ad70877c23000102/
// In this simple assignment you are given a number and have to make it negative. But maybe the number is already negative?
// Examples
// Kata.MakeNegative(1);  // return -1
// Kata.MakeNegative(-5); // return -5
// Kata.MakeNegative(0);  // return 0
// Notes
// The number can be negative already, in which case no change is required.
// Zero (0) is not checked for any specific sign. Negative zeros make no mathematical sense.
namespace MakeNegative
{
  using System;

  public static class Kata
  {
    public static int MakeNegative(int number)
      => -Math.Abs(number);
  }
}

// Beginner Series #1 School Paperwork: https://www.codewars.com/kata/55f9b48403f6b87a7c0000bd/
// Your classmates asked you to copy some paperwork for them. You know that there are 'n' classmates and the paperwork has 'm' pages.
// Your task is to calculate how many blank pages do you need. If n < 0 or m < 0 return 0.
// Example:
// n= 5, m=5: 25
// n=-5, m=5:  0
namespace Paperwork
{
  using System;
  public static class Paper
  {
    public static int Paperwork(int n, int m)
      => n < 0 || m < 0 ? 0 : n * m;
  }
}

// Is he gonna survive?: https://www.codewars.com/kata/59ca8246d751df55cc00014c/
// A hero is on his way to the castle to complete his mission. However, he's been told that the castle is surrounded with a couple of powerful dragons! each dragon takes 2 bullets to be defeated, our hero has no idea how many bullets he should carry.. Assuming he's gonna grab a specific given number of bullets and move forward to fight another specific given number of dragons, will he survive?
// Return True if yes, False otherwise :)
namespace Hero
{
  class Kata
  {
    public static bool Hero(int bullets, int dragons)
      => bullets >= dragons << 1;
  }
}

// Counting sheep...: https://www.codewars.com/kata/54edbc7200b811e956000556/
// Consider an array/list of sheep where some sheep may be missing from their place. We need a function that counts the number of sheep present in the array (true means present).
// For example,
// [true,  true,  true,  false,
//   true,  true,  true,  true ,
//   true,  false, true,  false,
//   true,  false, false, true ,
//   true,  true,  true,  true ,
//   false, false, true,  true]
// The correct answer would be 17.
// Hint: Don't forget to check for bad values like null/undefined
namespace CountSheeps
{
  using System.Linq;

  public static class Kata
  {
    public static int CountSheeps(bool[] sheeps)
      => sheeps.Count(s => s);
  }
}

// Rock Paper Scissors!: https://www.codewars.com/kata/5672a98bdbdd995fad00000f/
// Let's play! You have to return which player won! In case of a draw return Draw!.
// Examples(Input1, Input2 --> Output):
// "scissors", "paper" --> "Player 1 won!"
// "scissors", "rock" --> "Player 2 won!"
// "paper", "paper" --> "Draw!"
namespace Rps
{
  using System.Collections.Generic;
  public class Kata
  {
    public static Dictionary<string, string> WonDict => new() {
      {"scissors", "paper"},
      {"rock", "scissors"},
      {"paper", "rock"},
    };

    public string Rps(string p1, string p2)
      => p1 == p2 ? "Draw!" :
        string.Format("Player {0} won!", WonDict[p1] == p2 ? "1" : "2");
  }
}

// Opposite number: https://www.codewars.com/kata/56dec885c54a926dcd001095/
// Very simple, given an integer or a floating-point number, find its opposite.
// Examples:
// 1: -1
// 14: -14
// -34: 34
namespace Opposite
{
  public class Kata
  {
    public static int Opposite(int number)
      => -number;
  }
}

// Century From Year: https://www.codewars.com/kata/5a3fe3dde1ce0e8ed6000097/
// Introduction
// The first century spans from the year 1 up to and including the year 100, the second century - from the year 101 up to and including the year 200, etc.
// Task
// Given a year, return the century it is in.
// Examples
// 1705 --> 18
// 1900 --> 19
// 1601 --> 17
// 2000 --> 20
// Note: this kata uses strict construction as shown in the description and the examples, you can read more about it here
namespace CenturyFromYear
{
  using System;
  public static class Kata
  {
    public static int СenturyFromYear(int year)
      => year <= 100 ? 1 : year / 100 + Convert.ToInt32(year % 100 != 0);
  }
}

// Sentence Smash: https://www.codewars.com/kata/53dc23c68a0c93699800041d/
// Write a function that takes an array of words and smashes them together into a sentence and returns the sentence. You can ignore any need to sanitize words or add punctuation, but you should add spaces between each word. Be careful, there shouldn't be a space at the beginning or the end of the sentence!
// Example
// ['hello', 'world', 'this', 'is', 'great']  =>  'hello world this is great'
namespace SentenceSmash
{
  using System.Linq;
  using System.Text;

  public class Kata
  {
    public static string Smash(string[] words)
      => words.Aggregate(
        new StringBuilder(),
        (acc, word) =>
          acc.Append($"{(acc.Length > 0 ? " " : "")}{word}")
      ).ToString();
  }
}
