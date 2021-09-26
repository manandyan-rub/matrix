using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = fadedColor;
            Console.CursorVisible = false;

            int width, height;
            int[] y;
            Initialize(out width, out height, out y);

            while (true)
            {
                Counter++;
                ColumnUpdate(width, height, y);
                if (Counter > flowSpeed)
                    Counter = 0;
            }
        }
        static int Counter;
        static Random randomPosition = new Random();
        static int flowSpeed = 100000;
        static ConsoleColor baseColor = ConsoleColor.DarkGreen;
        static ConsoleColor fadedColor = ConsoleColor.Red;
        static char AsciiCharacters
        {
            get
            { 
                return (char)(randomPosition.Next(20, 200));
            }
        }
        public static int YPositionFields(int yPosition, int height)
        {
            if (yPosition < 0)
            {
                return yPosition + height;
            }
            else if (yPosition < height)
            {
                return yPosition;
            }
            else return 0;
        }

        private static void Initialize(out int width,out int height,out int [] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth;
            y = new int[width];
            Console.Clear();

            for(int x = 0; x < width; x++) { y[x] = randomPosition.Next(height); }
        }
        
        private static void ColumnUpdate(int width, int height, int[] y) {
            int x;
            if (Counter < flowSpeed)
            {
                for (x = 0; x < width; x++)
                {
                    if (x % 10 == 1)
                    { 
                        Console.ForegroundColor = fadedColor; 
                    }
                    else
                    { 
                        Console.ForegroundColor = baseColor; 
                    }
                    Console.Write("  ");
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(AsciiCharacters);

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, YPositionFields(temp1, height));
                    y[x] = YPositionFields(y[x] + 1, height);
                    if ( x % 10 == 1)
                    {
                        string[] authors = { "Mahesh", "Joe", "Dave ", "Allen ","Monica ", "Henry ", " Kumar", " Prime","Rose", "Mike" };
                        Random rand = new Random();
                        int index = rand.Next(authors.Length);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(authors[index]);
                    }
                }
            }
            else if (Counter > flowSpeed)
            {
                for (x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, y[x]);
                    if (x % 10 == 9 )
                    {
                        
                        Console.ForegroundColor = fadedColor;
                    }
                    else
                    {
                        Console.Write(" ");
                        Console.ForegroundColor = baseColor;
                    }
                    Console.Write(AsciiCharacters);

                    y[x] = YPositionFields(y[x] , height);
                }
            }
            
            else if (Counter > 0)
            {
                for (x = 0; x < width; x++)
                { 
                    Console.SetCursorPosition(x, YPositionFields(y[x], height));
                    Console.Write("  ");
                }
            }
        }
    }
}
