// See https://aka.ms/new-console-template for more information
using System.Text;

//LearningActivity31();
//LearningActivity32();
//LearningActivity33();
//LearningActivity34();
LearningActivity35();

void LearningActivity31()
{
    string ConvertTempInString(char type, float value)
    {
        if(type == 'c')
        {
            return value + "F converts to " + ((value - 32) * 5 / 9) + "C";
        } else if(type == 'f'){
            return value + "C converts to " + ((value * 9 / 5) + 32) + "F";
        } else
        {
            return value + " doesn't convert to anything cus you gave it an invalid input!";
        }
    }

    Console.WriteLine("This is the function for Learning Activity 3.1!");
    Console.WriteLine("To convert Fahrenheit to Celsius, press 'c' ");
    Console.WriteLine("To convert Celsius to Fahrenheit, press 'f' ");
    

    // I chose to handle Invalid Input in here for practice.
    char charInput;
    if (!char.TryParse(Console.ReadLine(), out charInput))
    {
        Console.WriteLine("That's not 'c' OR 'f'! Moving on to next function.");
        return; //escapes the LearningActivity31 function
    }

    Console.WriteLine("What value do you wish to convert?");
    float value;
    if (!float.TryParse(Console.ReadLine(), out value)){
        Console.WriteLine("That's not a number! Moving onto the next function.");
        return; //escapes the LearningActivity31 function
    }

    Console.WriteLine(ConvertTempInString(charInput, value));
    Console.WriteLine("Press enter to move on to the next Learning Activity.");
    Console.ReadLine();
}
void LearningActivity32()
{
    Console.Clear();
    Console.WriteLine("This is the function for Learning Activity 3.2!");
    String[] classmates = new string[14];
    int[] classAges = new int[14];
    String[] wonders = new string[7];
    //TODO: populate arrays
    Console.WriteLine("Press enter to move on to the next Learning Activity.");
    Console.ReadLine();
}
void LearningActivity33()
{
    Console.Clear(); //To remove headaches.
    Console.WriteLine("This is the function for Learning Activity 3.3!");

    int[,] ticTacToeBoard = new int[3, 3];
    initalizeBoard(ticTacToeBoard);

    int inputX;
    int inputY;
    bool xTurn = true; //Whether or not X goes this turn. If false, it must mean O goes this turn.
    bool gameOver = false;
    int currentWinnerInt = 0; // 0 indicates none have been found. 

    while (!gameOver)
    {
        //get input
        if (xTurn)
        {
            Console.WriteLine("It's X's turn!");
        }
        else
        {
            Console.WriteLine("It's O's turn!");
        }
        Console.WriteLine("Which row would you like to write on? (0, 1, 2)?");
        if (!int.TryParse(Console.ReadLine(), out inputX))
        {
            Console.WriteLine("Invalid Input! Goodbye!");
            return;
        }

        Console.WriteLine("Which column would you like to write on? (0, 1, 2)?");
        if (!int.TryParse(Console.ReadLine(), out inputY))
        {
            Console.WriteLine("Invalid Input! Goodbye!");
            return;
        }
        //present board
        Console.Clear();
        updateBoard(ticTacToeBoard, inputX, inputY, xTurn);
        displayBoard(ticTacToeBoard);
        xTurn = !xTurn; // change turn

        //check if anyone has won
        if(currentWinner(ticTacToeBoard) != 0)
        {
            currentWinnerInt = currentWinner(ticTacToeBoard);
            gameOver = true;
        } else if(isDraw(ticTacToeBoard)){
            gameOver = true;
        }
    }

    Console.WriteLine("Game Over!");
    //Print out who won
    if(currentWinnerInt == 1)
    {
        Console.WriteLine("X is the winner!");
    } else if (currentWinnerInt == 2)
    {
        Console.WriteLine("O is the winner!");
    } else
    {
        Console.WriteLine("It was a Draw!");
    }

    Console.WriteLine("Press enter to move on to the next Learning Activity.");
    Console.ReadLine();

    void initalizeBoard(int[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = 0;
            }
        }
    }

    void updateBoard(int[,] board, int _inputX, int _inputY, bool _xTurn)
    {
        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (x == _inputX && y == _inputY)
                {
                    if (board[x,y] != 0)
                    {
                        break;//if someone already made a move there, you can't override it, so we do not update the spot.
                    }

                    if (_xTurn)
                    {
                        board[x, y] = 1;
                    } else
                    {
                        board[x, y] = 2;
                    }
                    break; //Once found, board no longer needs to be updated
                }
            }
        }

    }

    void displayBoard(int[,] board)
    {
        StringBuilder stringBuilder = new StringBuilder();

        //NOTE- the loops are nested bredth-first, so that the board will be displayed accurately.
        for(int y = 0; y < board.GetLength(1); y++)
        {
            for(int x = 0; x < board.GetLength(0); x++)
            {
                if (x == 0)
                {
                    stringBuilder.AppendLine("");//creates new line
                }

                switch (board[x, y])
                {
                    case 0:
                        stringBuilder.Append("/");
                        break;
                    case 1:
                        stringBuilder.Append("X");
                        break;
                    case 2:
                        stringBuilder.Append("O");
                        break;
                }
                stringBuilder.Append(" "); //for formatting purposes
                
            }
        }
        Console.WriteLine("CURRENT BOARD:");
        Console.WriteLine(stringBuilder.ToString());
    }

    int currentWinner(int[,] board)
    {
        //end conditions
        //vertical win
        for(int i = 0; i < board.GetLength(0); i++)
        {
            if (board[i,0] == board[i,1] && board[i,1] == board[i,2])
            {
                //vertical win
                return board[i,0];
            }
        }

        //horizontal win
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
            {
                //horizontal win
                return board[0, i];
            }
        }
        //diagonal win(2)
        if (board[0, 0] == board[1, 1] && board[1,1] == board[2, 2])
        {
            return board[0, 0];
        }
        //the other diagonal win
        if (board[0, 2] == board[1,1] && board[1,1] == board[2, 0])
        {
            return board[0, 2];
        }

        //otherwise, just return 0
        return 0;
    }

    bool isDraw(int[,] board)
    {
        //since this is always checked after winner has been checked, we can assume that the currentWinnerInt is zero
        //check if there are any empty spots left
        for (int x = 0;  x < board.GetLength(0); x++)
        {
            for(int y = 0; y < board.GetLength(1); y++)
            {
                if (board[x,y] == 0)
                {
                    return false;
                }
            }
        }
        //since the whole board is full without winner, it is a draw.
        return true; 
    }
}

void LearningActivity34()
{
    //int number;
    //bool success = int.TryParse(Console.ReadLine(), out number); //example code
    Console.Clear();
    Console.WriteLine("This is the function for Learning Activity 3.4!");

    int number;
    bool stillValid = true;
    while (stillValid)
    {
        Console.WriteLine("Enter your age!");

        if (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid Input! Goodbye.");
            stillValid = false; //NOTE- setting stillValid as false is effectively the same as break, but it does prevent that one last comparison at the top of the loop.
            break;
        } else
        {
            if (number < 10 || number > 50)
            {
                Console.WriteLine("Your age is out of range!");
                stillValid = false;
                break;
            }
        }
    }

    Console.WriteLine("Press enter to move on to the next Learning Activity.");
    Console.ReadLine();

}

void LearningActivity35()
{
    Console.Clear();
    int[] highScores = { 1272700, 1271100, 1243000, 1218000, 1214300, 1210800, 1210400, 1206800, 1178400 };
    int sum = 0;
    for(int i = 0; i < highScores.Length; i++)
    {
        sum += highScores[i];
    }
    double average = (double)sum / highScores.Length; // the average!

    double derivSum = 0;
    for (int i = 0; i < highScores.Length; i++)
    {
        derivSum += Math.Pow(highScores[i], 2); //sum up the squared highscore values 
    }
    double derivAverage = derivSum / highScores.Length;// get the deriv average
    double standardDeviation = Math.Sqrt(derivAverage - Math.Pow(average, 2)); // square the deviation between the deriv average and the (squared) average

    //Averages should very much be in doubles and not integers. Considering how important those few significant digits can be when it comes to calculating things like Standard Deviation,
    //it's cruicial that data isn't lost when doing these calculations. 

    //intent DOES matter however. If you wanted to show these on an arcade machine, you would likely want to truncate and display it as an integer.
    //For actual Data purposes however, you'd lose a great deal of accuracy by sticking with integers.
    Console.WriteLine("Average:");
    Console.WriteLine(average);
    Console.WriteLine("Standard Deviation:");
    Console.WriteLine(standardDeviation);
    Console.WriteLine("This is the function for Learning Activity 3.5!");
}

