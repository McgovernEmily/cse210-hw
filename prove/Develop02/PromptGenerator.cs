//Will randomly generate one of the prompts I created.
public class PromptGenerator
{
    public List<string> _entries = new List<string>()
    {
        "What was the best thing that happened today?",
        "What did you eat for breakfast, Lunch, and Dinner?",
        "How were you feeling today?",
        "How were you feeling today?",
        "If you could change anything about today, what would it be?",
        "Did you do anything fun today?"
    };

    public Random randomGenerator = new Random();
    
    public string RandomPrompt()
    {
        int num = randomGenerator.Next(_entries.Count);
        return _entries[num];

    }

}