using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_odev
{
    class TicTacToe
    {
        private int[,] board;
        private int currentPlayer;

        public TicTacToe()
        {
            board = new int[3, 3];
            currentPlayer = 1; // Initially the first player
            InitializeBoard();
        }

        // Setting the board to its initial state
        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0; // 0: Empty cell
                }
            }
        }

        // Printing the board to the screen
        private void PrintBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 1)
                        Console.Write("X | "); // 1: First player (X)
                    else if (board[i, j] == 2)
                        Console.Write("O | "); // 2: Second player (O)
                    else
                        Console.Write("  | "); // 0: Empty cell
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        // Starting the game
        public void StartGame()
        {
            int moves = 0;

            Console.WriteLine("Welcome to Tic-Tac-Toe Game!");
            Console.WriteLine("Enter a number between 1-9 sequentially to make your move.");

            while (true)
            {
                PrintBoard();
                int position;
                bool validInput = false;

                do
                {
                    Console.WriteLine($"Player {currentPlayer}, choose a position: ");
                    validInput = int.TryParse(Console.ReadLine(), out position);
                    if (!validInput || position < 1 || position > 9)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1-9.");
                        validInput = false;
                    }
                } while (!validInput || !MakeMove(position));

                moves++;

                if (CheckWin() || moves == 9)
                {
                    PrintBoard();
                    if (CheckWin())
                        Console.WriteLine($"Player {currentPlayer} wins!");
                    else
                        Console.WriteLine("The game ended in a tie!");
                    break;
                }

                currentPlayer = currentPlayer == 1 ? 2 : 1; // Switching players
            }
        }

        // Making a move
        private bool MakeMove(int position)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            if (board[row, col] == 0)
            {
                board[row, col] = currentPlayer;
                return true;
            }
            else
            {
                Console.WriteLine("This position is already taken. Please choose another position.");
                return false;
            }
        }

        // Checking for a winner
        private bool CheckWin()
        {
            // Checking win conditions (rows, columns, diagonals)
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;

                if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }

            if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;

            if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.StartGame();
            Console.ReadKey();
        }
    }
}
