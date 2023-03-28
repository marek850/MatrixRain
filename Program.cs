namespace MatrixV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool directionUp = false;
            ConsoleColor color = ConsoleColor.Green;
            int delaySpeed = 1;
            string characters = "Numeric";
            bool help = false;
            string density = "";

            
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--direction-up":
                        directionUp = true;
                        break;
                    case "--color":
                        if (i + 1 < args.Length && Enum.TryParse(args[i + 1], true, out ConsoleColor c))
                        {
                            color = c;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value for --color argument.");

                        }
                        break;
                    case "--delay-speed":
                        if (i + 1 < args.Length && int.TryParse(args[i + 1], out int speed))
                        {
                            delaySpeed = speed;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value for --delay-speed argument.");

                        }
                        break;
                    case "--characters":
                        if (i + 1 < args.Length)
                        {
                            characters = args[i + 1];
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value for --characters argument.");
                        }
                        break;
                    case "--help":
                        help = true;
                        break;
                    case "--density":
                        if (i + 1 < args.Length)
                        {
                            density = args[i + 1];
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Invalid value for --density argument.");
                        }
                        break;
                    default:
                        Console.WriteLine($"Invalid argument: {args[i]}");
                        break;

                }
            }

            if (help)
            {
                Console.WriteLine("Usage: MatrixRain [--direction-up] [--color <ConsoleColor>] [--delay-speed <int>] [--characters <string>] [--help]");
            }
            string charactersToUse;
            switch (characters)
            {
                case "Alpha":
                    charactersToUse = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                case "Numeric":
                    charactersToUse = "0123456789";
                    break;
                case "AlphaNumeric":
                default:
                    charactersToUse = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    break;
            }
            
            Random rand = new Random();
            int hustota = rand.Next();
            switch (density)
            {
                case "Vysoka":
                    hustota = Console.WindowWidth;
                    break;
                case "Stredna":
                    hustota = Console.WindowWidth/2;
                    break;
                case "Nizka":
                    hustota = Console.WindowWidth / 3;
                    break;
                default:
                    hustota = Console.WindowWidth / 2;
                    break;
            }
            Console.Clear();
            Console.CursorVisible = false;
            
            
            Kvapka[] kvapky = new Kvapka[hustota];
            for (int i = 0; i < kvapky.Length; i++)
            {
                kvapky[i] = new(rand.Next(2, Console.WindowHeight), rand.Next(Console.WindowWidth), rand.Next(0, 20) * -1, directionUp, charactersToUse);
            }
            while (true) { 
                //funkcionalita pridavania kvapiek v kazdom opakovani cyklu, spomalilo  tak nevyuzivam
                //if (rand.Next(100) > 50){
                //    vygenerujKvapky(kvapky, directionUp, charactersToUse);
                //}
                foreach (Kvapka item in kvapky)
                {

                    if (item.Y >= 0 && item.Y <= Console.WindowHeight)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(item.X, item.Y);
                        Console.Write(item.Znak);
                    }
                    item.posun();
                    Kvapka[] teloKvapky = item.TeloKvapky;
                    foreach (var i in teloKvapky)
                    {
                        if (i.Y >= 0 && i.Y <= Console.WindowHeight)
                        {
                            Console.ForegroundColor = color;
                            Console.SetCursorPosition(i.X, i.Y);
                            Console.Write(i.Znak);
                            
                            
                        }
                        if (teloKvapky[teloKvapky.Length - 1] == i && i.Y - 1 >= 0 && i.Y - 1 <= Console.WindowHeight)
                        {
                            Console.SetCursorPosition(i.X, i.Y - 1);
                            Console.Write(" ");
                            if (i.Y > Console.WindowHeight)
                            {
                                item.setX(rand.Next(Console.WindowWidth));
                                item.setY(rand.Next(0, 20) * -1);
                                item.setLength(rand.Next(2, Console.WindowHeight));
                                break;

                            }
                        }
                        
                        i.posun();
                        
                    }

                }
                Thread.Sleep(delaySpeed);
            }
        }

        static void vygenerujKvapky(Kvapka[] dazd, bool directionUp, string charactersToUse)
        {
            Kvapka[] temp = dazd;
            Random rand = new Random();
            int poc = rand.Next(2);
            dazd = new Kvapka[temp.Length + poc];
            int index = 0;
            foreach (Kvapka k in temp)
            {
                dazd[index] = k;
                index++;
            }
            for (int i = 0; i < dazd.Length; i++)
            {
                if (dazd[i] != null)
                {
                    dazd[i] = new(rand.Next(2, Console.WindowHeight), rand.Next(Console.WindowWidth), rand.Next(0, 4) * -1, directionUp, charactersToUse);
                }
            }
        }
    }
}