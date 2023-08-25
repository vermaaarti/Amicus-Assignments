/*namespace ass1.Models
{
    public class User
    {
    }
}*/


public class User
{
    public string UserId { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}

public static class UserData
{
    // Simulated user data stored in-memory
    public static List<User> Users = new List<User>
    {
        new User { UserId = "user1", Password = "pass123", Name = "John Doe", Department = "HR" },
        new User { UserId = "user2", Password = "pass456", Name = "Jane Smith", Department = "IT" }
    };
}
