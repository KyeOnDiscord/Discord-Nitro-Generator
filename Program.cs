using System;
using System.Linq;
using System.Threading;
using System.IO;
namespace NitroGen
{
    class Program
    {
        static string generated { get; set; }
        static void Main()
        {
            long codes;
            Console.Title = "Nitro Generator By Kye#5000 | https://github.com/promasterboy";
        start: Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Discord Nitro Generator by Kye#5000 | https://github.com/promasterboy");
            Console.WriteLine("");
            Console.WriteLine("How many Nitro Codes do you want to generate?");
            try
            {
                codes = Convert.ToInt64(Console.ReadLine());
            }
            catch
            {
                goto start;
            }
            Thread thread = new Thread(WriteOut);
            thread.Start();
            Console.WriteLine("Generating Discord Nitro Codes, sit back and relax!");
            for (long i = codes;; i--)
            {
                
                Console.Title = "Nitro Generator By Kye#5000 | https://github.com/promasterboy | " + i + "/" + codes + " Left";
                generated += "https://discord.gift/" + RandomString(16) + Environment.NewLine;
                if (i == 0)
                {
                    thread.Abort();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Almost done, please wait!");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Thread.Sleep(3000);
                    Console.WriteLine("Done!");
                    Console.ReadKey();
                    break;
                }
            }
            
        }

        static void WriteOut()
        {
            while (true)
            {
                using (StreamWriter stream = new StreamWriter("codes.txt", append: true))
                {
                    stream.Write(generated);
                    generated = "";
                }
                Thread.Sleep(3000);
            }
        }


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
