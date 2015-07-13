namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Mines
    {
        public static void Main()
        {
            const int MaximumScore = 35;
            const int MaximumNumberOfPlayersOnScoreboard = 6;

            char[,] minefield = InitializePlayfield();
            char[,] bombs = PlantBombs();

            List<Player> topPlayers = new List<Player>(MaximumNumberOfPlayersOnScoreboard);

            int row = 0;
            int column = 0;
            bool hasStartedANewGame = true;
            bool hasDetonated = false;
            bool hasWon = false;
            string command = string.Empty;
            int playerScore = 0;
        
            do
            {
                if (hasStartedANewGame)
                {
                    Console.WriteLine("Let's play Minesweeper.");
                    Render(minefield);
                    hasStartedANewGame = false;
                }
        
                Console.Write("Please input row and column to reveal (format: R C)");
                command = Console.ReadLine().Trim();
        
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= minefield.GetLength(0) && column <= minefield.GetLength(1))
                    {
                        command = "turn";
                    }
                }
        
                switch (command)
                {
                    case "top":
                        GetTopScores(topPlayers);
                        break;
        
                    case "restart":
                        minefield = InitializePlayfield();
                        bombs = PlantBombs();
                        Render(minefield);
                        hasDetonated = false;
                        hasStartedANewGame = false;
                        break;
        
                    case "exit":
                        Console.WriteLine("Thanks for playing!");
                        break;
        
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                MakeMove(minefield, bombs, row, column);
                                playerScore++;
                            }
        
                            if (MaximumScore == playerScore)
                            {
                                hasWon = true;
                            }
                            else
                            {
                                Render(minefield);
                            }
                        }
                        else
                        {
                            hasDetonated = true;
                        }
        
                        break;
        
                    default:
                        Console.WriteLine("\nInvalid command!\n"); 
                        break;
                }
        
                if (hasDetonated)
                {
                    Render(bombs);
                    Console.Write("\nGame over. You scored {0} points. Please give your nickname", playerScore);
                    string nickname = Console.ReadLine();
                    Player playerResult = new Player(nickname, playerScore);
                    if (topPlayers.Count < MaximumNumberOfPlayersOnScoreboard)
                    {
                        topPlayers.Add(playerResult);
                    }
                    else
                    {
                        for (int player = 0; player < topPlayers.Count; player++)
                        {
                            if (topPlayers[player].Points < playerResult.Points)
                            {
                                topPlayers.Insert(player, playerResult);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }
        
                    topPlayers.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    topPlayers.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    GetTopScores(topPlayers);
        
                    minefield = InitializePlayfield();
                    bombs = PlantBombs();
                    playerScore = 0;
                    hasDetonated = false;
                    hasStartedANewGame = true;
                }
        
                if (hasWon)
                {
                    Console.WriteLine("\nCongratulations, you win!");
                    Render(bombs);
                    Console.WriteLine("Please give your nickname:");
                    string imeee = Console.ReadLine();
                    Player to4kii = new Player(imeee, playerScore);
                    topPlayers.Add(to4kii);
                    GetTopScores(topPlayers);
                    minefield = InitializePlayfield();
                    bombs = PlantBombs();
                    playerScore = 0;
                    hasWon = false;
                    hasStartedANewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Thanks for playing!");
            Console.Read();
        }
        
        private static void GetTopScores(List<Player> players)
        {
            Console.WriteLine("\nTop points:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, players[i].Name, players[i].Points);
                }
        
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No scores to show\n");
            }
        }
        
        private static void MakeMove(char[,] playfield, char[,] bombfield, int row, int col)
        {
            char kolkoBombi = CountSurroundingBombs(bombfield, row, col);
            bombfield[row, col] = kolkoBombi;
            playfield[row, col] = kolkoBombi;
        }
        
        private static void Render(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }
        
        private static char[,] InitializePlayfield()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }
        
        private static char[,] PlantBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] playfield = new char[rows, cols];
        
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    playfield[row, col] = '-';
                }
            }
        
            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }
        
            foreach (int randomNumber in randomNumbers)
            {
                int col = randomNumber / cols;
                int row = randomNumber % cols;
                if (row == 0 && randomNumber != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
        
                playfield[col, row - 1] = '*';
            }
        
            return playfield;
        }
        
        private static char CountSurroundingBombs(char[,] bombfield, int row, int col)
        {
            int numberOfBombs = 0;
            int bombfieldRows = bombfield.GetLength(0);
            int bombfieldCols = bombfield.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombfield[row - 1, col] == '*')
                { 
                    numberOfBombs++; 
                }
            }

            if (row + 1 < bombfieldRows)
            {
                if (bombfield[row + 1, col] == '*')
                { 
                    numberOfBombs++; 
                }
            }

            if (col - 1 >= 0)
            {
                if (bombfield[row, col - 1] == '*')
                { 
                    numberOfBombs++;
                }
            }

            if (col + 1 < bombfieldCols)
            {
                if (bombfield[row, col + 1] == '*')
                { 
                    numberOfBombs++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombfield[row - 1, col - 1] == '*')
                { 
                    numberOfBombs++; 
                }
            }

            if ((row - 1 >= 0) && (col + 1 < bombfieldCols))
            {
                if (bombfield[row - 1, col + 1] == '*')
                { 
                    numberOfBombs++; 
                }
            }

            if ((row + 1 < bombfieldRows) && (col - 1 >= 0))
            {
                if (bombfield[row + 1, col - 1] == '*')
                { 
                    numberOfBombs++; 
                }
            }

            if ((row + 1 < bombfieldRows) && (col + 1 < bombfieldCols))
            {
                if (bombfield[row + 1, col + 1] == '*')
                { 
                    numberOfBombs++; 
                }
            }

            return char.Parse(numberOfBombs.ToString());
        }
    }
}
