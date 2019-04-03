namespace Chess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<string, int> dict = new Dictionary<string, int>() { { "A", 1 }, { "B", 2 }, { "C", 3 }, { "D", 4 }, { "E", 5 }, { "F", 6 }, { "G", 7 }, { "H", 8 } };
        public static void Main(string[] args)
        {
            string line;
            string number = Console.ReadLine();
            long n = Int64.Parse(number);
            string message = "";
            while (n > 0)
            {
                line = Console.ReadLine();
                string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.None);
                string a1 = split[0];
                long y1 = Int64.Parse(split[1]);
                string b2 = split[2];
                long y2 = Int64.Parse(split[3]);
                long auxX, auxY;
                long x1 = dict[a1];
                long x2 = dict[b2];

                if ((x1 + y1) % 2 != (x2 + y2) % 2)
                {
                    message = "Impossible";
                }
                else if (x1 == x2 && y1 == y2)
                {
                    message = "0 " + a1 + " " + y1;
                }
                else if (x1 + y1 == x2 + y2 || x1 + y2 == x2 + y1)
                {
                    message = "1 " + a1 + " " + y1 + " " + b2 + " " + y2;
                }
                else
                {
                    auxX = x1;
                    auxY = y1;
                    var i = 1;
                    while (i <= 4)
                    {

                        if (auxX + auxY == x2 + y2 || auxX + y2 == x2 + auxY)
                        {
                            var xx = dict.FirstOrDefault(x => x.Value == auxX).Key;
                            message = "2 " + a1 + " " + y1 + " " + xx + " " + auxY + " " + b2 + " " + y2;
                            break;
                        }
                        switch (i)
                        {
                            case 1:
                                auxX++;
                                auxY++;
                                break;
                            case 2:
                                auxX--;
                                auxY++;
                                break;
                            case 3:
                                auxX--;
                                auxY--;
                                break;
                            case 4:
                                auxX++;
                                auxY--;
                                break;
                        }
                        if (auxX == 0 || auxX == 9 || auxY == 0 || auxY == 9) { 
                            i++;
                            auxX = x1;
                            auxY = y1;
                        }
                    }

                }
                n--;
                Console.WriteLine(message);
            }
            
            Console.ReadLine();
        }
    }
}
