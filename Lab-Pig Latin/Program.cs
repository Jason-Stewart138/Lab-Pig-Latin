using System.Security.Cryptography.X509Certificates;
using System.Text;

Console.WriteLine("Welcome to the Pig Latin Translator!");
Console.WriteLine();

Main();


void Main()
{
    bool isGetUserValue = true;
    string translation = "";

    while (isGetUserValue)
    {

        Console.WriteLine("Please enter a word or sentence to translate:");
        string userInputRaw = Console.ReadLine();

        if (userInputRaw == null || userInputRaw == "")
        {
            Console.WriteLine("You must enter a word or sentence to continue");
            Main();
        }
        else try
            {
                translation = TranslateUserInput(userInputRaw);
            }
            catch
            {
                translation = userInputRaw;
            }
        Console.WriteLine();
        Console.WriteLine(translation);
        Console.WriteLine();
        isGetUserValue = TryAgain("translate again");
    }
}


string TranslateUserInput(string userInput)
{
    const string vowels = "AEIOUaeiou";
    StringBuilder translatedString = new StringBuilder();

    foreach (string singleWord in userInput.Split(' '))
    {
        bool isFirstLetterVowel = vowels.Contains(singleWord.Substring(0, 1));

        if (isFirstLetterVowel)
        {
            translatedString.Append(singleWord.ToLower() + "way ");
        }
        else
        {
            int indexLocation = GetIndexOfFirstVowel(singleWord, vowels);
            string remainingWord = singleWord.Substring(indexLocation);
            string anyConsoants = singleWord.Substring(0, indexLocation);

            translatedString.Append(remainingWord.ToLower() + anyConsoants.ToLower() + "ay ");
        }
    }
    return translatedString.ToString();
}

int GetIndexOfFirstVowel(string singleWord, string vowels)
{
    for (int i = 0; i < singleWord.Length; i++)
    {
        if (vowels.Contains(singleWord[i]))
        {
            return i;
        }
    }
    return -1;
}

bool TryAgain(string typeOfRepeat)
{
    bool goAgain = false;
    bool isValidInput = true;

    while (isValidInput)
    {
        Console.WriteLine($"Would you like to {typeOfRepeat}(y/n)?");
        string input = Console.ReadLine().ToLower().Trim();
        if (input.Contains("y") || input.Contains("n"))
        {
            goAgain = input == "y" || input == "yes";
            isValidInput = true;
            Console.Clear();
            return goAgain;
        }
        else
        {
            Console.WriteLine("Sorry that was not a valid input, please try again.");
            isValidInput = true;
        }
    }
    return true;
}
