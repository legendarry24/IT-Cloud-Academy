using System;
using System.Threading;
using System.Threading.Tasks;

namespace Garden
{
    class Program
    {
        static readonly byte[,] gardenArea = new byte[5, 15];
        const byte firstGardener = 1;
        const byte secondGardener = 2;

        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => Work(0, firstGardener),
                () => Work2(gardenArea.GetLength(0), gardenArea.GetLength(1), secondGardener)
            );

            Print();

            Console.ReadKey();
        }

        static void Work(int start, byte value)
        {
            for (int i = start; i < gardenArea.GetLength(0); i++)
            {
                for (int j = start; j < gardenArea.GetLength(1); j++)
                {
                    //if another gardener has already done this garden plot then skip
                    if (gardenArea[i, j] == secondGardener)
                        continue;
                    gardenArea[i, j] = value;
                    Thread.Sleep(100);
                }
            }
        }

        static void Work2(int startRow, int startColumn, byte value)
        {
            for (int i = startColumn - 1; i >= 0; i--)
            {
                for (int j = startRow - 1; j >= 0; j--)
                {
                    //if another gardener has already done this garden plot then skip
                    if (gardenArea[j, i] == firstGardener)
                        continue;
                    gardenArea[j, i] = value;
                    Thread.Sleep(50);
                }
            }
        }

        static void Print()
        {
            for (int i = 0; i < gardenArea.GetLength(0); i++)
            {
                for (int j = 0; j < gardenArea.GetLength(1); j++)
                {
                    Console.Write(gardenArea[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
