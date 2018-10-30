using System;

namespace _03._Miner
{
    class Miner
    {
        static char[][] matrix;
        static int coals = 0;
        static int[] PlayerPosition;
        static bool isGameOver = false;

        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            matrix = new char[numberOfRows][];
            PlayerPosition = new int[2];

            for (int row = 0; row < numberOfRows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                matrix[row] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row][col] = currentRow[col][0];
                    if (matrix[row][col] == 'c')
                    {
                        coals++;
                    }
                    else if (matrix[row][col] == 's')
                    {
                        PlayerPosition[0] = row;
                        PlayerPosition[1] = col;
                    }
                }
            }

            for (int command = 0; command < commands.Length; command++)
            {
                MovePlayer(commands[command]);
                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({PlayerPosition[0]}, {PlayerPosition[1]})");
                    break;
                }
                if (isGameOver)
                {
                    Console.WriteLine($"Game over! ({PlayerPosition[0]}, {PlayerPosition[1]})");
                    break;
                }
                if (command == commands.Length - 1) // last command
                {
                    Console.WriteLine($"{coals} coals left. ({PlayerPosition[0]}, {PlayerPosition[1]})");
                    break;
                }
            }

            //Print();
        }

        private static void MovePlayer(string command)
        {
            // left, right, up and down
            if (command == "left")
            {
                if (IsPlayerInside(0,-1))
                {
                    if (matrix[PlayerPosition[0]][PlayerPosition[1] - 1] == 'c')
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[1] -= 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';                        
                        coals--;
                    }
                    else if (matrix[PlayerPosition[0]][PlayerPosition[1] - 1] == 'e')
                    {
                        PlayerPosition[1] -= 1;
                        isGameOver = true;
                    }
                    else
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[1] -= 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';
                    }
                }
            }
            // left, right, up and down
            if (command == "right")
            {
                if (IsPlayerInside(0, 1))
                {
                    if (matrix[PlayerPosition[0]][PlayerPosition[1] + 1] == 'c')
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[1] += 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';
                        coals--;
                    }
                    else if (matrix[PlayerPosition[0]][PlayerPosition[1] + 1] == 'e')
                    {
                        PlayerPosition[1] += 1;
                        isGameOver = true;
                    }
                    else
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[1] += 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';
                    }
                }
            }
            // left, right, up and down
            if (command == "up")
            {
                if (IsPlayerInside(-1, 0))
                {
                    if (matrix[PlayerPosition[0] - 1][PlayerPosition[1]] == 'c')
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[0] -= 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';
                        coals--;
                    }
                    else if (matrix[PlayerPosition[0] - 1][PlayerPosition[1]] == 'e')
                    {
                        PlayerPosition[0] -= 1;
                        isGameOver = true;
                    }
                    else
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[0] -= 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';
                    }
                }
            }
            // left, right, up and down
            if (command == "down")
            {
                if (IsPlayerInside(1, 0))
                {
                    if (matrix[PlayerPosition[0] + 1][PlayerPosition[1]] == 'c')
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[0] += 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';
                        coals--;
                    }
                    else if (matrix[PlayerPosition[0] + 1][PlayerPosition[1]] == 'e')
                    {
                        PlayerPosition[0] += 1;
                        isGameOver = true;
                    }
                    else
                    {
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = '*';
                        PlayerPosition[0] += 1;
                        matrix[PlayerPosition[0]][PlayerPosition[1]] = 's';
                    }
                }
            }
        }

        private static bool IsPlayerInside(int row, int col)
        {
            if (PlayerPosition[0] + row < 0 || PlayerPosition[0] + row > matrix[PlayerPosition[0]].Length - 1)
            {
                return false;
            }
            if (PlayerPosition[1] + col < 0 || PlayerPosition[1] + col > matrix.Length - 1)
            {
                return false;
            }

            return true;
        }

        private static void Print()
        {
            //Console.WriteLine(); // put in comments before judge
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
