public class UserStorage
{
    private List<User> _users;

    public UserStorage()
    {
        _users = new List<User>();
    }

    // Adding the user to a list. 
    public void AddUser(string name, double weight, string gender, int activity, double proteinGoal)
    {
        _users.Add(new User(name, weight, gender, activity, proteinGoal));
    }

    // Finding the user in that list.
    public User GetUser(string name)
    {
        return _users.Find(user => user.GetName() == name);
    }
}