//------------------HANGMAN------------------>>

string wordsFullFilePath = "words.txt";
string wordData = File.ReadAllText(wordsFullFilePath);
string[] sortedWords = wordData.Split(",");


Random rnd = new Random();
int seed = rnd.Next(0, sortedWords.Length);
string[] words = new string[10] { "occupation", "vaccuum", "elementary", "horizon", "influence", "transportation", "documentary", "athletic", "individual", "liberty" };
string word = sortedWords[seed];
char[] letters = new char[word.Length];
int guessesRemaining = 8;
char[] letters2 = word.ToCharArray();
bool playFlag = true;
string playAgain = "y";
char playAgainInput = 'y';
int sessionWins = 0;
int sessionLosses = 0;
int allTimeWins = 0;
int allTimeLosses = 0;
int winStreakCurrent = 0;
int loseStreakCurrent = 0;
int winStreakAllTime = 1;
int loseStreakAllTime = 1;
bool winStreak = false;
bool loseStreak = false;
char guess = ' ';
string letterList = "";

string fullFilePath = "data.txt";
string fileData = File.ReadAllText(fullFilePath);
string[] sortedData = fileData.Split(",");

winStreak = bool.Parse(sortedData[0]);
loseStreak = bool.Parse(sortedData[1]);
allTimeWins = int.Parse(sortedData[2]);
allTimeLosses = int.Parse(sortedData[3]);
winStreakAllTime = int.Parse(sortedData[4]);
loseStreakAllTime = int.Parse(sortedData[5]);


while (playAgainInput == 'y')
{ 
    for (int i = 0; i < word.Length; i++)
    {
        letters[i] = '*';
    }

    while (guessesRemaining > 0)
    {
        Console.WriteLine("\n");
        Console.WriteLine("--  W E L C O M E  T O  H A N G M A N v2  --\n");
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
                Console.WriteLine("\t/        |");
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
        

        letterList = letterList + " " + guess;

        Console.Write("\t");
        Console.WriteLine("\n"+ letterList);

        Console.WriteLine("\n");
        Console.Write("\t");
        Console.WriteLine(letters);

        Console.Write("\n\tGuess a Letter: ");

        string thisGuess = Console.ReadLine();
        bool checkInput = char.TryParse(thisGuess, out guess);

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
            if (winStreak)
            {
                winStreakCurrent++;
                if (winStreakCurrent > winStreakAllTime)
                {
                    winStreakAllTime++;
                }
            }

            else
            {
                winStreakCurrent = 1;
                if (winStreakCurrent > winStreakAllTime)
                {
                    winStreakAllTime++;
                }
            }

            sessionWins++;
            allTimeWins++;

            winStreak = true;
            loseStreak = false;

            Console.Clear();

            Console.WriteLine("\n");
            Console.WriteLine("--  W E L C O M E  T O  H A N G M A N v2 --\n");
            Console.WriteLine("--    You have {0} guesses remaining!    --\n", guessesRemaining);

            Console.WriteLine("\t          \tThis session: {0}-{1}",sessionWins, sessionLosses);
            Console.WriteLine("\t          \tAll-Time: {0}-{1}", allTimeWins, allTimeLosses);
            Console.WriteLine("\t          \tCurrent Streak : {0} W", winStreakCurrent);
            Console.WriteLine("\t          \tAll-Time Win Streak : {0} W", winStreakAllTime);
            Console.WriteLine("\t          \tAll-Time Loss Streak : {0} L", loseStreakAllTime);
            Console.WriteLine("\t----------\n\n\n");

            Console.Write("\t");
            Console.WriteLine(letters);

            string newString = $"{winStreak}," +
                                $"{loseStreak}," +
                                $"{allTimeWins}," +
                                $"{allTimeLosses}," +
                                $"{winStreakAllTime}," +
                                $"{loseStreakAllTime}";

            File.WriteAllText(fullFilePath, newString);

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

            seed = rnd.Next(0, sortedWords.Length);
            word = sortedWords[seed];
            guessesRemaining = 8;
            playFlag = true;
            letters = new char[word.Length];
            letters2 = word.ToCharArray();
            letterList = "";
            guess = ' ';



            Console.Clear();

            break;
        }

        else if (guessesRemaining == 0)
        {
            

            if (loseStreak)
            {
                loseStreakCurrent++;
                if (loseStreakCurrent > loseStreakAllTime)
                {
                    loseStreakAllTime++;
                }
            }

            else 
            {
                loseStreakCurrent = 1;
                if (loseStreakCurrent > loseStreakAllTime)
                {
                    loseStreakAllTime++;
                }
            }

            sessionLosses++;
            allTimeLosses++;
            winStreak = false;
            loseStreak = true;
            
            Console.Clear();

            Console.WriteLine("\n");
            Console.WriteLine("--  W E L C O M E  T O  H A N G M A N v2 --\n");
            Console.WriteLine("--    You have {0} guesses remaining!    --\n", guessesRemaining);

            Console.WriteLine("\t _________\tThis session: {0}-{1}", sessionWins, sessionLosses);
            Console.WriteLine("\t |       |\tAll-Time: {0}-{1}", allTimeWins, allTimeLosses);
            Console.WriteLine("\t O       |\tCurrent Streak : {0} L", loseStreakCurrent);
            Console.WriteLine("\t/|\\      |\tAll-Time Win Streak : {0} W", winStreakAllTime);
            Console.WriteLine("\t/ \\      |\tAll-Time Loss Streak : {0} L", loseStreakAllTime);
            Console.WriteLine("\t----------\n\n\n");

            Console.Write("\t");
            Console.WriteLine(letters2);

            string newString = $"{winStreak}," +
                                $"{loseStreak}," +
                                $"{allTimeWins}," +
                                $"{allTimeLosses}," +
                                $"{winStreakAllTime}," +
                                $"{loseStreakAllTime}";

            File.WriteAllText(fullFilePath, newString);

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

            seed = rnd.Next(0, sortedWords.Length);            
            word = sortedWords[seed];
            guessesRemaining = 8;
            playFlag = true;
            letters = new char[word.Length];
            letters2 = word.ToCharArray();
            letterList = "";
            guess = ' ';


            Console.Clear();

            break;
        }

        else Console.Clear();
    }
}

