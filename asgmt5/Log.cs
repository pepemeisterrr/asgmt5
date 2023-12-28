using System;

namespace asgmt5
{
    public class Log
    {
      
        public static void Error(string text, int ln)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" [ERROR]   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text, true);
            if (ln == 1) Console.WriteLine();
        }

        public static void Info(string text, int ln)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" [INFO]    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text, true);
            if (ln == 1) Console.WriteLine();
        }
        public static void Head(string text, int ln)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" [INFO]    ");
            //Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text, true);
            if (ln == 1) Console.WriteLine();
        }

        public static void Input()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" [INPUT]   ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Input(string text, int ln)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" [INPUT]   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text, true);
            if (ln == 1) Console.WriteLine();
        }
        public static void Num(string text, int n, int ln) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" [{n + 1}]      ");
            if (n < 9) Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text, true);
            if (ln == 1) Console.WriteLine();
        }
        public static void Num(string text, ulong n, int ln)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" [{n + 1}]      ");
            if (n < 9) Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text, true);
            if (ln == 1) Console.WriteLine();
        }
    }
}
