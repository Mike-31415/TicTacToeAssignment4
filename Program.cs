// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using TicTacToeAssignment4;

// 2D array
string[,] gameboard =
{
    { "A1", "A2", "A3" },
    { "B1", "B2", "B3" },
    { "C1", "C2", "C3" }
};

string player_turn = "O";
bool gameover = false;

TicTacToeSupporterClass TicTacTools = new TicTacToeSupporterClass();

Console.WriteLine("Welcome to Tic-Tac-Toe!");

// Do While gameplay loop
do
{
    // Print current board
    TicTacTools.PrintBoard(gameboard);

    Console.WriteLine($"Player {player_turn}, please choose a square (A1–C3):");
    string player_choice = Console.ReadLine();

    // Validate input
    if (!Regex.IsMatch(player_choice, @"^[ABC][123]$"))
    {
        Console.WriteLine("Invalid input. Please enter A1, B2, etc.");
        continue;
    }
    // Convert input to Row and Col
    int row = player_choice[0] - 'A';  // A=0, B=1, C=2
    int col = player_choice[1] - '1';  // 1=0, 2=1, 3=2

    // Check if square is available
    if (gameboard[row, col] == "X" || gameboard[row, col] == "O")
    {
        Console.WriteLine("That square is already taken. Try again.");
        continue;
    }

    // Place move
    gameboard[row, col] = player_turn;

    // Check for winner
    string winner = TicTacTools.CheckWinner(gameboard);
    if (!string.IsNullOrEmpty(winner))
    {
        TicTacTools.PrintBoard(gameboard);
        Console.WriteLine($"🎉 Player {winner} wins!");
        gameover = true;
        break;
    }
    else
    {
        // Check if the gameboard is full
        if (TicTacTools.IsBoardFull(gameboard))
        {
            Console.WriteLine("It is a tie!");
            gameover = true;
        }
    }

    // Switch turns
    player_turn = (player_turn == "O") ? "X" : "O";

} while (!gameover);

Console.WriteLine("Thanks for playing!");