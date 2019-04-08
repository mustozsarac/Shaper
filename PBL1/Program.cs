using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void print(string[,] comp , string[,] player , int round)
        {
            round++;
            Console.WriteLine("--------Round " + round + "-----------");
            Console.Write("| " + comp[0, 0] + " " + comp[0, 1] + " " + comp[0, 2] + " |"); Console.WriteLine("  | " + player[0, 0] + " " + player[0, 1] + " " + player[0, 2] + " |");
            Console.Write("| " + comp[1, 0] + " " + comp[1, 1] + " " + comp[1, 2] + " |"); Console.WriteLine("  | " + player[1, 0] + " " + player[1, 1] + " " + player[1, 2] + " |");
            Console.Write("| " + comp[2, 0] + " " + comp[2, 1] + " " + comp[2, 2] + " |"); Console.WriteLine("  | " + player[2, 0] + " " + player[2, 1] + " " + player[2, 2] + " |");
            Console.Write("+ - - - +  "); Console.WriteLine("+ - - - +  ");
        }

        static void endPrint(string[,] comp, string[,] player, int round)
        {
            Console.WriteLine("--------You Win----------");
            Console.WriteLine("+ - - - +  + - - - +  ");
            print(comp, player, round);
            Console.WriteLine("Score: " + (200 - round * 10));
        }

        static void createRandom_X(int vertorhor, string[] random_x )
        {
            Random Rnd = new Random();
            vertorhor = Rnd.Next(2);
            int sayi = Rnd.Next(20);
            if (sayi <= 17)
            {
                random_x[0] = "X";
                random_x[1] = "X";
            }
            else if (sayi == 18)
            {
                random_x[0] = "X";
                random_x[1] = " ";
            }
            else
            {
                random_x[0] = " ";
                random_x[1] = "X";
            }
        }

        static void printRandom_X(int vertorhor, string[] random_x)
        {
            if (vertorhor == 0)
            {
                Console.WriteLine("+ - +");
                Console.WriteLine("| " + random_x[0] + "" + " | ");
                Console.WriteLine("| " + random_x[1] + "" + " | ");
                Console.WriteLine("+ - +");

            }
            else
            {
                Console.WriteLine("+ - - +");
                Console.WriteLine("| " + random_x[0] + " " + random_x[1] + " | ");
                Console.WriteLine("+ - - +");
            }
        }

        static void XOR(int vertorhor, string[,] player , string[] random_x , int comi, int comj)
        {
            comi--; comj--;
            bool flag = true;

            if (comi > 2 || comj > 2 ) { Console.WriteLine("Out of board error!"); flag = false; }

            if (vertorhor == 0)
            {
                if (comi == 2) { Console.WriteLine("Out of board error!"); flag = false; }
                if (flag)
                {
                    if (player[comi, comj] == random_x[0]) { player[comi, comj] = " "; } else { player[comi, comj] = "X"; }
                    if (player[comi + 1, comj] == random_x[1]) { player[comi + 1, comj] = " "; } else { player[comi+1, comj] = "X"; }
                }
            }
            else
            {
                if(comj == 2) { Console.WriteLine("Out of board error!"); flag = false; }
                if (flag)
                {
                    if (flag && player[comi, comj] == random_x[0]) { player[comi, comj] = " "; } else { player[comi, comj] = "X"; }
                    if (flag && player[comi, comj + 1] == random_x[1]) { player[comi, comj + 1] = " "; } else { player[comi, comj + 1] = "X"; }
                }
            }
        }

        static void rotateRandom_X(int vertorhor, string[] random_x)
        {
            string rotater = " ";
            if (vertorhor == 0)
            {
                rotater = random_x[0];
                random_x[0] = random_x[1];
                random_x[1] = rotater;
                vertorhor = 1;
            }
            else
            {
                rotater = random_x[0];
                random_x[0] = random_x[1];
                random_x[1] = rotater;
                vertorhor = 0;
            }
        }

        static bool isEqual(string[,] com, string[,] player)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(player[i, j] != com[i, j])
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        } 

        static void Main(string[] args)
        {
            int round = 0;
            bool isRotated = false;
            int vertorhor = 0;

            string[,] comp = new string[3, 3];
            string[,] player = new string[3, 3];
            string[] random_x = new string[2];
            Random Rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int rand_number = Rnd.Next(2);
                    if (rand_number == 1)
                    {
                        comp[i, j] = "X";
                    }
                    else
                    {
                        comp[i, j] = " ";
                    }
                    player[i, j] = " ";
                }
            }

            do
            {
                print(comp,player,round);

                if (!isRotated)
                {
                    createRandom_X(vertorhor, random_x);
                }
                printRandom_X(vertorhor, random_x);

                int Command, comi, comj;
                Console.Write("Command:");
                Command = Convert.ToInt32(Console.ReadLine());
                comi = Command / 10;
                comj = Command % 10;

                if(Command == 41)
                {
                    rotateRandom_X(vertorhor, random_x);
                    isRotated = true;
                }
                else
                {
                    XOR(vertorhor, player, random_x, comi, comj);
                }
            }

            while (isEqual(comp,player) == false);
            endPrint(comp, player, round);
            Console.ReadLine();
        }
    }
}
