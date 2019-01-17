namespace PunchCardApp.Utils
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool Verify(string text, string hash);
    }
}