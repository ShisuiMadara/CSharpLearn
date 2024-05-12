public class Hangman {

    private int lives = 5;
    
    private void DisplayGuess(string guess) {
        Console.WriteLine("==============================");
        Console.WriteLine("Your progress: ");
        Console.WriteLine(guess);
        Console.WriteLine("Remaining Lives: " + Convert.ToString(lives));
        Console.WriteLine("==============================");
    }
    private void Guess(string word, string guess)  {
        
        while(true) {
            char letter = Convert.ToChar(Console.ReadLine() ?? throw new Exception("Null value found. Kindly enter a leter."));

            char[] guessArray = guess.ToCharArray();
            if (word.Contains(letter)){
                if(guess.Contains(letter)) {
                    lives --;
                    Console.WriteLine("Letter already predicted. You lost a silly life.");
                    Console.WriteLine("Remaining lives: " + Convert.ToString(lives));
                }else {
                    for(int i = 0; i<word.Length; ++i) {
                        if(word[i] == letter) {
                            guessArray[i] = letter;
                        }
                    }
                    guess = new string(guessArray);
                    DisplayGuess(guess);
                }
            }else {
                Console.WriteLine("Wrong guess. You lost a life.");
                lives--;
                Console.WriteLine("Remaining lives: " + Convert.ToString(lives));
            }

            if(lives == 0) {
                Console.WriteLine("You loose. The word was " + word);
                break;
            }else {
                continue;
            }
        }
    
    }

    private string FindWord() {

        String[] wordList = {
        "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog", "and",
        "finds", "itself", "in", "a", "lush", "green", "meadow", "where", "birds", "sing",
        "and", "butterflies", "dance", "amidst", "the", "fragrant", "flowers", "underneath",
        "the", "clear", "blue", "sky", "It", "was", "a", "beautiful", "day", "filled",
        "with", "joy", "and", "serenity", "as", "the", "world", "seemed", "to",
        "pause", "for", "a", "moment", "of", "peace", "and", "harmony", "Nature",
        "whispered", "its", "secrets", "to", "those", "who", "listened", "and", "revealed",
        "the", "magic", "that", "dwelled", "within", "each", "and", "every", "living",
        "thing", "The", "sun", "set", "in", "a", "blaze", "of", "colors",
        "painting", "the", "horizon", "with", "warmth", "and", "promise", "of", "a",
        "new", "beginning", "as", "the", "night", "unfolded", "its", "mysteries",
        "and", "the", "stars", "twinkled", "with", "eternal", "glory", "endlessly", "watching",
        "over", "the", "world", "below"
    };

        Random rnd = new();
        int randomIndex = rnd.Next(0, 150);

        return wordList[randomIndex];

    }

    public void Play () {
        string word = FindWord();
        string guess = ""; 
        for(int i =0; i<word.Length; ++i){
            guess += "_";
        }
        DisplayGuess(guess);

        Guess(word, guess);
    }
}