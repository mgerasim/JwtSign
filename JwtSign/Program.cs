using System;

namespace JwtSign
{
    class Program
    {
        static void Main(string[] args)
        {
            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.UtcNow;

            var iat = (int)issueTime.Subtract(utc0).TotalSeconds;
            var exp = (int)issueTime.AddSeconds(64).Subtract(utc0).TotalSeconds; // Expiration time is up to 1 hour, but lets play on safe side

            var payload = new
            {
                iss = "1f239f55-2041-4208-b62a-2d46690b1363",
                iat = iat,
                exp = exp,
            };

            var token = JsonWebToken.Encode(payload, "a21b799790bed61264f614e51a1fa1ef3d6c78b4fdefef90a147b153b3dee77d", JwtHashAlgorithm.HS512);

            Console.WriteLine(token);

            Console.WriteLine("Hello World!");
        }
    }
}
