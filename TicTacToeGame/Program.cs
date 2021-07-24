using System;
using System.Text;

namespace TicTacToeGame
{
    class Program
    {
        private static TicTacToeGame g = new TicTacToeGame();

        static void Main(string[] args)
        {
            SetColor(ConsoleColor.Blue);
            Console.WriteLine("Source field");
            ResetColor();
            Console.WriteLine(GetPrintableState());

            while (g.GetWinner() == Winner.GameIsUnfinished)
            {
                try
                {
                    if (g.MovesCounter % 2 == 0)
                    {
                        SetColor(ConsoleColor.Yellow);
                        Console.WriteLine("Walking crosses");
                    }
                    else
                    {
                        SetColor(ConsoleColor.Cyan);
                        Console.WriteLine("Walking zeroes");
                    }
                    Console.Write("Input index: ");

                    ResetColor();

                    int index = -1;
                    while (index == -1)
                        index = int.Parse(Console.ReadLine());

                    g.MakeMove(index);

                    Console.WriteLine();
                    Console.WriteLine(GetPrintableState());
                }
                catch (Exception ex)
                {
                    SetColor(ConsoleColor.Red);
                    Console.WriteLine(ex.Message);
                    ResetColor();
                }

            }

            SetColor(ConsoleColor.Green);
            Console.WriteLine($"Winner: {g.GetWinner()}");
            ResetColor();

            Console.ReadLine();

        }


        private static string GetPrintableState()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= 7; i += 3)
            {
                sb.AppendLine("     |     |     ")
                  .AppendLine(
                    $"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  "
                  )
                  .AppendLine("_____|_____|_____");
            }
            return sb.ToString();
        }

        private static string GetPrintableChar(int index)
        {
            State state = g.GetState(index);
            if (state == State.Unset)
                return index.ToString();
            return state == State.Cross ? "X" : "O";
        }

        private static void SetColor(ConsoleColor color)
            => Console.ForegroundColor = color;

        private static void ResetColor()
            => Console.ResetColor();

    }
}
