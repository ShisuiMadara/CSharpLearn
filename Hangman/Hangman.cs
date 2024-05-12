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

  private async Task<string> FindWord()
{
    HttpClient client = new();
    string uri = "https://random-word-api.herokuapp.com/word";
    try
    {
        using HttpResponseMessage response = await client.GetAsync(uri);
        response.EnsureSuccessStatusCode(); 
        string resp = await response.Content.ReadAsStringAsync();
        return resp;
    }
    catch (HttpRequestException e)
    {
        throw new Exception("API failed to fetch: " + e.Message);
    }

}


    public async void Play () {
        string word = await FindWord();
        string guess = ""; 
        for(int i =0; i<word.Length; ++i){
            guess += "_";
        }
        DisplayGuess(guess);

        Guess(word, guess);
    }
}