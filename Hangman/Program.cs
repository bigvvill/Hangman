//------------------HANGMAN------------------>>

Random rnd = new Random();
int seed = rnd.Next(0, 9);
string[] words = new string[10] { "occupation", "vaccuum", "elementary", "horizon", "influence", "transportation", "documentary", "athletic", "individual", "liberty" };
string word = words[seed];
char[] letters = new char[word.Length];
int guessesRemaining = 8;
char[] letters2 = word.ToCharArray();
bool playFlag = true;
string playAgain = "y";
char playAgainInput = 'y';

while (playAgainInput == 'y')
{ 
    for (int i = 0; i < word.Length; i++)
    {
        letters[i] = '*';
    }

    while (guessesRemaining > 0)
    {
        Console.WriteLine("\n");
        Console.WriteLine("--  W E L C O M E  T O  H A N G M A N  --\n");
        Console.WriteLine("--    You have {0} guesses remaining!    --\n", guessesRemaining);

        bool correctFlag = false;

        switch (guessesRemaining)
        {
            case 8:
                Console.WriteLine("\t          ");
                Console.WriteLine("\t          ");
                Console.WriteLine("\t          ");
                Console.WriteLine("\t          ");
                Console.WriteLine("\t          ");
                Console.WriteLine("\t----------\n\n\n");
                break;
            case 7:
                Console.WriteLine("\t _________");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t----------\n\n\n");
                break;
            case 6:
                Console.WriteLine("\t _________");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t O       |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t----------\n\n\n");
                break;
            case 5:
                Console.WriteLine("\t _________");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t O       |");
                Console.WriteLine("\t |       |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t----------\n\n\n");
                break;
            case 4:
                Console.WriteLine("\t _________");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t O       |");
                Console.WriteLine("\t/|       |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t----------\n\n\n");
                break;
            case 3:
                Console.WriteLine("\t _________");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t O       |");
                Console.WriteLine("\t/|\\      |");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t----------\n\n\n");
                break;
            case 2:
                Console.WriteLine("\t _________");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t O       |");
                Console.WriteLine("\t/|\\      |");
                Console.WriteLine("\t/       |");
                Console.WriteLine("\t----------\n\n\n");
                break;
            case 1:
                Console.WriteLine("\t _________");
                Console.WriteLine("\t         |");
                Console.WriteLine("\t O       |");
                Console.WriteLine("\t/|\\      |");
                Console.WriteLine("\t/ \\      |");
                Console.WriteLine("\t----------\n\n\n");
                break;
            default:
                break;
        }
        Console.Write("\t");
        
        Console.WriteLine(letters);

        Console.Write("\n\tGuess a Letter: ");

        string thisGuess = Console.ReadLine();
        bool checkInput = char.TryParse(thisGuess, out char guess);

        while (checkInput == false || guess < 'a' || guess > 'z')
        {
            Console.Write("Please just enter a single letter guess: ");
            thisGuess = Console.ReadLine();
            checkInput = char.TryParse(thisGuess, out guess);
        }

        for (int j = 0; j < word.Length; j++)
        {
            if (guess == word[j])
            {
                letters[j] = guess;
                correctFlag = true;
            }
        }

        if (correctFlag == false)
            guessesRemaining--;

        bool areEqual = letters2.SequenceEqual(letters);

        if (areEqual)
        {
            Console.Clear();

            Console.WriteLine("\n");
            Console.WriteLine("--  W E L C O M E  T O  H A N G M A N  --\n");
            Console.WriteLine("--    You have {0} guesses remaining!    --\n", guessesRemaining);

            Console.WriteLine("\t          ");
            Console.WriteLine("\t          ");
            Console.WriteLine("\t          ");
            Console.WriteLine("\t          ");
            Console.WriteLine("\t          ");
            Console.WriteLine("\t----------\n\n\n");

            Console.Write("\t");
            Console.WriteLine(letters);

            Console.WriteLine("\n\tYOU WIN! WAY TO GO!");            

            Console.Write("\n\tPlay Again? ('y'/'n'): ");
            playAgain = Console.ReadLine();
            playFlag = char.TryParse(playAgain, out playAgainInput);

            while (playFlag == false)
            {
                Console.Write("Play Again? Please enter 'y' or 'n': ");
                playAgain = Console.ReadLine();
                playFlag = char.TryParse(playAgain, out playAgainInput);
            }

            if (playAgainInput == 'n')
            {
                break;
            }

            seed = rnd.Next(0, 9);
            word = words[seed];
            guessesRemaining = 8;
            playFlag = true;
            letters = new char[word.Length];
            letters2 = word.ToCharArray();


            Console.Clear();

            break;
        }

        else if (guessesRemaining == 0)
        {
            Console.Clear();

            Console.WriteLine("\n");
            Console.WriteLine("--  W E L C O M E  T O  H A N G M A N  --\n");
            Console.WriteLine("--    You have {0} guesses remaining!    --\n", guessesRemaining);

            Console.WriteLine("\t _________");
            Console.WriteLine("\t |       |");
            Console.WriteLine("\t O       |");
            Console.WriteLine("\t/|\\      |");
            Console.WriteLine("\t/ \\      |");
            Console.WriteLine("\t----------\n\n\n");

            Console.Write("\t");
            Console.WriteLine(letters2);

            Console.WriteLine("\n\tHANGMAN! You Lose!   TRY AGAIN!");            

            Console.Write("\n\tPlay Again? ('y'/'n'): ");
            playAgain = Console.ReadLine();
            playFlag = char.TryParse(playAgain, out playAgainInput);

            while (playFlag == false)
            {
                Console.Write("Play Again? Please enter 'y' or 'n': ");
                playAgain = Console.ReadLine();
                playFlag = char.TryParse(playAgain, out playAgainInput);
            }

            if (playAgainInput == 'n')
            {
                break;
            }

            seed = rnd.Next(0, 9);
            word = words[seed];
            guessesRemaining = 8;
            playFlag = true;
            letters = new char[word.Length];
            letters2 = word.ToCharArray();


            Console.Clear();

            break;
        }

        else Console.Clear();
    }
}