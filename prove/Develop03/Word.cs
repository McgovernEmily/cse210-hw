
public class Word
{
    private string _text;
    private bool _numHide;

    // This is the constructor for Word.
    public Word(string text)
    {
        _text = text;

        // This makes the _numHide as not hidden.
        _numHide = false;
    }

    // This returns true if the word is hidden, otherwise it is false.
    public bool IsHidden => _numHide;

    // This hides the word by setting _numHide to true.
    public void Hide()
    {
        _numHide = true;
    }

    public void UnHide()
    {
        _numHide = false;
    }

    // This will display the word. If the word is hidden it will be "___".
    public void Display()
    {
        if (_numHide)
        {
            Console.Write(new string('_', _text.Length) + " ");
        }
        else
        {
            Console.Write(_text + " ");
        }
    }
}