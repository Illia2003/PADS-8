using System;
using System.Security.Cryptography;
using System.Text;

class OBFUSCATED
{
    private static string USER = "admin";

    // Розділені частини хешу пароля
    private static string[] PASS_PARTS = { "5e", "884", "a2", "b", "c0", "f", "5e0", "ee", "4c", "8", "3b", "c", "8f", "d5" };

    static void Main()
    {
        Console.WriteLine("Логін:");
        string u = Console.ReadLine();

        Console.WriteLine("Пароль:");
        string p = Console.ReadLine();

        if (Authenticate(u, p))
        {
            Console.WriteLine("Доступ надано!");
        }
        else
        {
            Console.WriteLine("Невірний логін або пароль.");
        }
    }

    private static bool Authenticate(string u, string p)
    {
        return u == USER && Hash(p) == GetFullHash();
    }

    private static string GetFullHash()
    {
        // Збираємо хеш пароля з його частин
        return string.Join("", PASS_PARTS);
    }

    private static string Hash(string p)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] b = sha.ComputeHash(Encoding.UTF8.GetBytes(p));
            StringBuilder s = new StringBuilder();
            foreach (byte v in b)
            {
                s.Append(v.ToString("x2"));
            }
            return s.ToString();
        }
    }
}
