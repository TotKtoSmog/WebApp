using WebApp.Platform.Services.Interfaces;

namespace WebApp.Platform.Services
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);
        public bool VerifyPassword(string password, string hashedPassword)
            => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
