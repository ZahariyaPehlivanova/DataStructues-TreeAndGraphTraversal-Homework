namespace _03.RideTheHorse
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const int StartValue = 1;
        private static int[,] matrix;
        private static Queue<Horse> queue;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            queue = new Queue<Horse>();
            var horse = new Horse(startRow, startCol, StartValue);
            queue.Enqueue(horse);

            MakeMove();
            var colToPrint = cols / 2;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (col == colToPrint)
                    {
                        Console.Write(matrix[row, col]);
                    }
                }

                Console.WriteLine();
            }
        }

        private static void MakeMove()
        {
            while (queue.Count > 0)
            {
                var horse = queue.Dequeue();
                matrix[horse.X, horse.Y] = horse.Value;

                Move(horse, -2, -1);
                Move(horse, -2, 1);
                Move(horse, -1, -2);
                Move(horse, -1, 2);
                Move(horse, 1, -2);
                Move(horse, 1, 2);
                Move(horse, 2, -1);
                Move(horse, 2, 1);
            }
        }

        private static void Move(Horse horse, int deltaX, int deltaY)
        {
            var newX = horse.X + deltaX;
            var newY = horse.Y + deltaY;

            bool isInside = newX >= 0 && newX < matrix.GetLength(0) 
                && newY >= 0 && newY < matrix.GetLength(1);

            if (isInside)
            {
                bool isFree = matrix[newX, newY] == 0;
                if (isFree)
                {
                    queue.Enqueue(new Horse(newX, newY, horse.Value + 1));
                }
            }
        }
    }
}
