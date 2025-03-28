public class Scripture
{
    // This contains the reference of the scripture using the Reference class.
    private Reference _reference;

    // This is the list that contains the scripture.
    private List<Word> _text;


    // This is the Constructor for Scripture class.
    public Scripture(Reference reference, List<string> text)
    {
        _reference = reference;
        _text = new List<Word>();
        foreach (var word in text)
        {
            _text.Add(new Word(word));
        }
    }

    // This displays the scripture and the reference
    public void Display()
    {
        Console.Clear();
        _reference.Display();
        foreach (var word in _text)
        {
            word.Display();
        }
       
    }

    public void NoWords()
    {
        foreach (var word in _text)
        {   
            word.Hide();
        }
    }

    // This is how you hide the word and turn it to "__".
    public void HideWord(int numberOfWordsToHide)
    {
        Random rando = new Random();
        int hiddenWordsCount = 0;

        // This is will count the number of words that are not hidden.
        int wordsleft = _text.Count(word => !word.IsHidden);

        // This makes sure we don't hide more words that what is left.
        numberOfWordsToHide = Math.Min(numberOfWordsToHide, wordsleft);

        // While loop going through the numbers of words that need to be hidden.
        while (hiddenWordsCount < numberOfWordsToHide)
        {
            // Finds a random index in the list
            int index = rando.Next(_text.Count);

            // If statement seeing if the word has already been hidden or not.
            if (!_text[index].IsHidden)
            {
                // Hides the word and changes it to "___"
                _text[index].Hide();

                // Adds to the number of words that are hidden.
                hiddenWordsCount++;
            }
        }
    }

    // Create it in reverse hidden, start out blank and then if they can't get it, they press enter to see some words.
    // The reverse of the HideWord.
    public void UnHide(int numberOfWordsToHide)
    {
        Random rando = new Random();
        int wordsReavealed = 0;

        int hiddenWordsCount = _text.Count(word => word.IsHidden);

        numberOfWordsToHide = Math.Min(numberOfWordsToHide, hiddenWordsCount);

        while (wordsReavealed < numberOfWordsToHide)
        {
            int index = rando.Next(_text.Count);

            if (_text[index].IsHidden)
            {
                _text[index].UnHide();
                wordsReavealed++;
            }
        }
    }
}