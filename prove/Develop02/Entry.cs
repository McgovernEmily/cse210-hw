//This keeps and stores/organizes the the prompt, response, and date 
public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;

    public Entry(string prompt, string response, string date)
    {
       _prompt = prompt;
       _response = response;
        _date = date;

    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}, Prompt: {_prompt}, Response: {_response}");
    }
}