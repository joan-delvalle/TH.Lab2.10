using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.Lab2._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> scores = new List<int>();

                Console.WriteLine("=== Leaderboard Updater ===");
                Console.WriteLine("Enter 10 player scores:");

                while (scores.Count < 10)
                {
                    Console.Write($"Score #{scores.Count + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int score) && score >= 0)
                    {
                        scores.Add(score);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Enter a non-negative integer.");
                    }
                }

                scores = scores.OrderByDescending(s => s).ToList();

                Console.WriteLine("\n--- Initial Leaderboard ---");
                DisplayLeaderboard(scores);

                Console.Write("\nEnter the new player's score: ");
                int newScore;
                while (!int.TryParse(Console.ReadLine(), out newScore) || newScore < 0)
                {
                    Console.Write("Invalid input. Enter a non-negative integer: ");
                }

                int insertIndex = scores.FindIndex(s => newScore > s);
                if (insertIndex == -1) scores.Add(newScore);
                else scores.Insert(insertIndex, newScore);   

                Console.WriteLine("\n--- Updated Leaderboard ---");
                DisplayLeaderboard(scores);
            }

            static void DisplayLeaderboard(List<int> scores)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine($"Rank {i + 1}: {scores[i]}");
                }
            }
        
    }

}

