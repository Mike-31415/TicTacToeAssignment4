// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

//initializing variables
string[] gameboard = {"A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3"};
string player_turn = "O";
bool gameover = false;
Dictionary<string, int> inputs = new Dictionary<string, int>
{
    { "A1",0 },
    { "A2",1 },
    { "A3",2 },
    { "B1",3 },
    { "B2",4 },
    { "B3",5 },
    { "C1",6 },
    { "C2",7 },
    { "C3",8 },
};


Console.WriteLine("Welcome to Tic-Tac-Toe!");

// main game loop
do
{
    
    // print board
    
    Console.WriteLine("Player " + player_turn + ", please choose a square to claim (e.g. \"A3\"");
    string player_choice =  Console.ReadLine(); //A1-C3
    
    int index;
    
    //check if input is valid
    if (Regex.IsMatch(player_choice, @"^[ABC][123]$"))
    {
        index = inputs[player_choice]; // A3 --> 2, for example
        
        // check if spot is taken
        if (gameboard[index] == "O" || gameboard[index] == "X")
        {
            //check turns
            if (player_turn == "O")
            {
                gameboard[index] = player_turn;
                player_turn = "X";
            }
            else
            {
                gameboard[index] = player_turn;
                player_turn = "O";
            }
        }
        else
        {
            Console.WriteLine("Please choose a spot that is not taken");
        }
    }
    else
    {
        Console.WriteLine("Please choose a valid input (A1-C3)");
    }
    
    
    // call supporting class to check for winner
    if (true)
    {
        Console.WriteLine("Player " + player_turn + " has won the game!");
        gameover = true;
    }
        
    
} while (!gameover);