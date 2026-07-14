using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public static class ConsoleInput
    {
        public static int ReadInt(string label, int? min = null, int? max = null)
        {
            while (true)
            {
                Console.Write(label);
                var input = Console.ReadLine();
                if(int.TryParse(input , out int value))
                {
                    if(min.HasValue && value < min.Value) { Console.WriteLine("Too small."); continue; }
                    if (max.HasValue && value > max.Value) { Console.WriteLine("Too large."); continue; }
                    return value;
                }
                Console.WriteLine("Invalid number. Try again.");
            }
        }

        public static decimal ReadDecimal(string label, int? min = null)
        {
            while (true)
            {
                Console.Write(label);
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal value))
                {
                    if (min.HasValue && value < min.Value) { Console.WriteLine("Too small."); continue; }
                    return value;
                }
                Console.WriteLine("Invalid number. Try again.");
            }
        }

        public static string ReadString(string label)
        {
            while (true)
            {
                Console.Write(label);
                var input = Console.ReadLine();
                if(!string.IsNullOrEmpty(input))
                    return input;
                Console.WriteLine("Empty value is not allowed. Try again");
            }
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to Continue...");
            
            Console.ReadLine();
        }
    }
}
