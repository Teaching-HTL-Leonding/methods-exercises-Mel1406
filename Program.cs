string selection;
do
{
    Console.Clear();
    Console.WriteLine("What do you want to execute?");
    Console.WriteLine("============================");
    Console.WriteLine();
    Console.WriteLine("0. Calculate Circle Area");
    Console.WriteLine("1. Random in Range");
    Console.WriteLine("2. To FizzBuzz");
    Console.WriteLine("3. Fibonacci by Index");
    Console.WriteLine("4. Ask for Number in Range");
    Console.WriteLine("5. Is palindrome?");
    Console.WriteLine("6. Is palindrome? (advanced)");
    Console.WriteLine("7. Chart Bar");
    Console.WriteLine("8. Count Smiling Faces");
    Console.WriteLine("q to Quit");
    selection = Console.ReadLine()!;

    if (selection != "q")
    {
        Console.Clear();
        switch (selection)
        {
            case "0": RunCalculateCircleArea(); break;
            case "1": GetMinMax(); break;
            case "2": System.Console.WriteLine(GetNumber()); break;
            case "3": System.Console.WriteLine(GetFibonacciIndex()); break;
            case "4": AskForNumberInRange(); break;
            case "5": GetPalindromeInput(); break;
            case "6": GetPalindromeInputAdvanced(); break;
            case "7": System.Console.WriteLine(GetChartBarNumber()); break;
            case "8": System.Console.WriteLine(getInputSmileys()); break;

            default: break;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
while (selection != "q");

#region Calculate Circle Area
void RunCalculateCircleArea()
{
    Console.Write("Enter radius:");
    var radius = double.Parse(Console.ReadLine()!);
    var area = CalculateCircleArea(radius);
    Console.WriteLine($"Area of circle with radius {radius} is {area}");
}

double CalculateCircleArea(double radius)
{
    return radius * radius * Math.PI;
}
#endregion

#region get random number
void GetMinMax()
{
    System.Console.WriteLine("Do you want to test run[y/n]? ");
    string testRun = Console.ReadLine()!;
    if (testRun == "y")
    {
        getRandomNumber(0, 3, 1000000, testRun);
    }
    else
    {
        System.Console.WriteLine("Whats your minimum? ");
        int min = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Whats your maximum? ");
        int max = int.Parse(Console.ReadLine()!);
        getRandomNumber(min, max + 1, 1, testRun);
    }
}
void PrintResult(int countOne, int countTwo, int countZero) => System.Console.WriteLine($"One: {countOne}, Two: {countTwo}, Zero: {countZero}");
void getRandomNumber(int min, int max, int repeat, string testRun)
{
    int countZero = 0;
    int countOne = 0;
    int countTwo = 0;
    for (int i = 0; i < repeat; i++)
    {
        int number = Random.Shared.Next(min, max);
        switch (number)
        {
            case 0: countZero++; break;
            case 1: countOne++; break;
            case 2: countTwo++; break;
        }
    }
    if (testRun == "y") { PrintResult(countZero, countOne, countTwo); }
}
#endregion
#region Fizz Buzz
string GetNumber()
{
    System.Console.WriteLine("What number do you want to check? ");
    return ToFizzBuzz(int.Parse(Console.ReadLine()!));
}
string ToFizzBuzz(int number)
{
    if (number % 3 == 0 && number % 5 == 0) { return "FizzBuzz"; }
    else if (number % 3 == 0) { return "Fizz"; }
    else if (number % 5 == 0) { return "Buzz"; }
    return "Nothing";
};
#endregion

#region Fibonacci Sequence
double GetFibonacciIndex()
{
    System.Console.WriteLine("What index should the Sequence return? ");
    return FibonacciByIndex(int.Parse(Console.ReadLine()!));
}
double FibonacciByIndex(int index)
{
    double smallerNumber = 0;
    double largerNumber = 1;
    for (int i = 0; i < index; i++)
    {
        double newBiggerNumber = smallerNumber + largerNumber;
        smallerNumber = largerNumber;
        largerNumber = newBiggerNumber;
    }
    return smallerNumber;
}
#endregion

#region ask for input in range
void AskForNumberInRange()
{
    System.Console.WriteLine("Whats the minimum value? ");
    int min = int.Parse(Console.ReadLine()!);
    System.Console.WriteLine("Whats the maximum value? ");
    int max = int.Parse(Console.ReadLine()!);
    NumberValid(min, max);
}
void NumberValid(int min, int max)
{
    int number;
    do
    {
        System.Console.Write($"Please enter your number[min: {min}, max: {max}]: ");
        number = int.Parse(Console.ReadLine()!);
        if (number < min) { System.Console.WriteLine($"Wrong number the input is too low. Try again."); }
        else if (number > max) { System.Console.WriteLine($"Wrong number the input is too high. Try again."); }
    } while (number < min || number > max);
    System.Console.WriteLine("Thank you, your input is valid.");
}
#endregion
#region check if palindrome
void GetPalindromeInput()
{
    System.Console.WriteLine("What word du you want to check? ");
    IsPalindrome(Console.ReadLine()!);
}
void IsPalindrome(string word)
{
    string newWord = "";
    for (int i = word.Length - 1; i >= 0; i--)
    {
        newWord += word[i];
    }

    if (word == newWord)
    {
        System.Console.WriteLine($"{word} is a palindrome.");
    }
    else { System.Console.WriteLine($"{word} isn't a palindrome."); }
}

#endregion
#region check if palindrome advanced
void GetPalindromeInputAdvanced()
{
    System.Console.WriteLine("What word du you want to check? ");
    IsPalindromeAdvanced(Console.ReadLine()!);
}
void IsPalindromeAdvanced(string word)
{
    string copyWord = word.Replace(" ", "").Replace("-", "").Replace(",", "").ToLower();
    string newWord = "";
    for (int i = copyWord.Length - 1; i >= 0; i--) { newWord += copyWord[i]; }
    if (copyWord == newWord)
    {
        System.Console.WriteLine($"{word} is a palindrome.");
    }
    else { System.Console.WriteLine($"{word} isn't a palindrome."); }
}
#endregion
#region chart bar
string GetChartBarNumber()
{
    double number;
    do
    {
        System.Console.WriteLine("Whats your number[min: 0, max: 1]? ");
        number = double.Parse(System.Console.ReadLine()!);
    } while (number < 0 || number > 1);
    return ChartBar(number);
}
string ChartBar(double number)
{
    int lengthBar = 10;
    string bar = "";
    double fitsXTimes = Math.Floor(number / 0.1d);
    for (int i = 0; i < fitsXTimes; i++) { bar += "o"; }
    for (int i = 0; i < lengthBar - fitsXTimes; i++) { bar += "."; }
    return bar;
}
#endregion
#region check for smiling faces
int getInputSmileys()
{
    System.Console.WriteLine("Please enter your input?");
    return CountSmilingFaces(Console.ReadLine()!);
}
int CountSmilingFaces(string input)
{
    int count = 0;
    const string lookFor = ":-)";
    for (int i = 0; i < input.Length - 2; i++)
    {
        bool found = false;
        for (int j = 0; j < lookFor.Length; j++)
        {
            if (input[i + j] == lookFor[j])
            {
                found = true;
            }
            else { found = false; break; }
        }
        if (found) { count++; }
    }
    return count;
}
#endregion