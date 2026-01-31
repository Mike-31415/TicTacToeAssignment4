namespace TicTacToeAssignment4;
using System;
public class TicTacToeSupporterClass
{
// Prints the Tic-Tac-Toe board using fancy ASCII
    public void PrintBoard(string[,] board)
    {
        Console.WriteLine();
        Console.WriteLine(" ┌───┬───┬───┐");

        for (int row = 0; row < 3; row++)
        {
            Console.Write(" │"); // start of row

            for (int col = 0; col < 3; col++)
            {
                string value = string.IsNullOrEmpty(board[row, col]) ? " " : board[row, col];

                // Determine padding to make every cell exactly 3 chars wide
                string cell = value.Length == 1 ? $" {value} " : $" {value}";

                Console.Write($"{cell}│");
            }

            Console.WriteLine();

            if (row < 2)
                Console.WriteLine(" ├───┼───┼───┤");
        }

        Console.WriteLine(" └───┴───┴───┘");
        Console.WriteLine();
    }


// Checks if there is a winner
// Returns "X", "O", or an empty string if no winner yet
    public string CheckWinner(string[,] board)
    {
// Check rows
        for (int row = 0; row < 3; row++)
        {
            if (!string.IsNullOrEmpty(board[row, 0]) &&
                board[row, 0] == board[row, 1] &&
                board[row, 1] == board[row, 2])
            {
                return board[row, 0];
            }
        }
// Check columns
        for (int col = 0; col < 3; col++)
        {
            if (!string.IsNullOrEmpty(board[0, col]) &&
                board[0, col] == board[1, col] &&
                board[1, col] == board[2, col])
            {
                return board[0, col];
            }
        }
// Check diagonals
        if (!string.IsNullOrEmpty(board[0, 0]) &&
            board[0, 0] == board[1, 1] &&
            board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }
        if (!string.IsNullOrEmpty(board[0, 2]) &&
            board[0, 2] == board[1, 1] &&
            board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }
// No winner
        return "";
    }
    
    public bool IsBoardFull(string[,] board)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] != "X" && board[row, col] != "O")
                    return false; // found an empty cell
            }
        }
        return true;
    }
}
