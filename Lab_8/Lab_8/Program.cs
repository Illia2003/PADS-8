using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    internal class Program
    {
        private static string username = "admin";
        private static string passwordHash = HashPassword("password123");

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Логін:");
            string inputUsername = Console.ReadLine();

            Console.WriteLine("Пароль:");
            string inputPassword = Console.ReadLine();

            if (Authenticate(inputUsername, inputPassword))
            {
                Console.WriteLine("Доступ надано!");
            }
            else
            {
                Console.WriteLine("Невірний логін або пароль.");
            }
        }

        private static bool Authenticate(string username, string password)
        {
            return username == Program.username && HashPassword(password) == passwordHash;
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
