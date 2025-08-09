using System.ComponentModel.Design;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int FIRST_ELEMENT = 0; // The first element value will start at 0
            const int NUMBER_OF_TRIES = 5; // The number of tries
            const String BLANK = "_";


            // Creating list with names
            List<string> collectionOfNames = new List<string>();
            collectionOfNames.Add("alex");
            collectionOfNames.Add("michael");
            collectionOfNames.Add("florian");

            // Picking a random name

            int numberOfNames = collectionOfNames.Count;

            Random num = new Random();
            int randomListElement = num.Next(FIRST_ELEMENT, numberOfNames); // Picking a random element based on the number of elements

            string chosenName = collectionOfNames[randomListElement].ToLower(); // Converting the element to the name



            char[] arrayChosenName = new char[chosenName.Length];
            Console.WriteLine(chosenName);

            int numberOfLetters = chosenName.Count(char.IsLetter); // Getting the number of letters in the random word
            Console.WriteLine(numberOfLetters);



            char blankSpaces = char.Parse(BLANK); // Loop for making the blank spaces

            for (int i = 0; i < numberOfLetters; i++)
            {

                arrayChosenName[i] = blankSpaces;


            }
            Console.WriteLine(arrayChosenName);



            int numberOfMistakes = 1; // Will be used to track the mistakes. Starting at 1 to ensure no extra tries.

            List<char> enteredLetters = new List<char>();

            Console.WriteLine($"Welcome to Hangman :) \nYou lose if you make {NUMBER_OF_TRIES} mistakes :P \nThis is the word you need to guess\n");

            foreach (char ch in arrayChosenName)
            {
                Console.Write(ch);
            }


            Console.WriteLine("\nPlease enter a letter");
            char userLetter;


            while (numberOfMistakes <= NUMBER_OF_TRIES)
            {

                userLetter = char.Parse(Console.ReadLine().ToLower());

                foreach (char c in enteredLetters)
                {
                    Console.WriteLine(c);
                }

                if (enteredLetters.Contains(userLetter))
                {
                    Console.WriteLine("You have used this letter previously");

                    continue;
                }

                for (int i = 0; i < chosenName.Length; i++)
                {

                    Console.Clear();

                    if (userLetter == chosenName[i])
                    {

                        arrayChosenName[i] = userLetter;
                        Console.WriteLine("You got a letter right");

                    }
                }
                if (!chosenName.Contains(userLetter))
                {
                    Console.WriteLine("You guessed wrong");
                    numberOfMistakes++;

                }

                if (numberOfMistakes > NUMBER_OF_TRIES)
                {

                    Console.WriteLine("You have made too many incorrect guesses. You lose");
                    break;

                }
                    enteredLetters.Add(userLetter);

                    foreach (char ch in arrayChosenName)
                    {
                        Console.Write(ch);
                    }

                    Console.WriteLine("\nEnter another letter");


                    string guessedName = new string(arrayChosenName);

                    if (chosenName == guessedName)
                    {

                        Console.WriteLine("Congratulations, you have guessed the word");

                    }
                

            }
        }
    }
}

    
    

