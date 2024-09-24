// See https://aka.ms/new-console-template for more information
LearningActivity31();
LearningActivity32();
LearningActivity33();
LearningActivity34();
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
}
void LearningActivity32()
{
    Console.WriteLine("This is the function for Learning Activity 3.2!");
    String[] classmates = new string[14];
    int[] classAges = new int[14];
    String[] wonders = new string[7];
    //TODO: populate arrays
}
void LearningActivity33()
{
    Console.WriteLine("This is the function for Learning Activity 3.3!");

}

void LearningActivity34()
{
    int number;
    bool success = int.TryParse(Console.ReadLine(), out number); //example code
    Console.WriteLine("This is the function for Learning Activity 3.4!");
}

void LearningActivity35()
{
    int[] highScores = { 1272700, 1271100, 1243000, 1218000, 1214300, 1210800, 1210400, 1206800, 1178400 };
    Console.WriteLine("This is the function for Learning Activity 3.5!");
}

