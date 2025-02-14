public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    // This is a constructor for multiple verses.
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    // This is my constructor for one verse.
    public Reference(string book, int chapter, int verseStart)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseStart;
    }   

    // This displays the reference.
    public void Display()
    {
        // If statement see if the start and end verses are the same
        if (_verseStart == _verseEnd)
        {
            Console.WriteLine($"{_book} {_chapter}:{_verseStart}");
        }
        else
        {
            Console.WriteLine($"{_book} {_chapter}:{_verseStart}-{_verseEnd}");
        }
    }
}