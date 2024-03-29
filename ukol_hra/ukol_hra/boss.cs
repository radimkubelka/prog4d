﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ukol_hra
{
    internal class Boss
    {
        public string name;
        //public string difficulty;
        public string topic;
        public string form;
        //aby hráč vybral jednu z možností
        public int DumbTest()
        {
            int answer = 0;
            while (answer != 1 && answer != 2 && answer != 3)
            {
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    if (answer == 1 || answer == 2 || answer == 3)
                    {
                        return answer;
                    }
                    else
                    {
                        Console.WriteLine("zadej platnou možnost (1, 2 nebo 3)");
                    }
                }
                else
                {
                    Console.WriteLine("zadej platnou možnost (1, 2 nebo 3)");
                }
            }
            return -1;
        }
        public Boss(string name, string form, string topic)
        {
            this.name = name;
            this.form = form;
            //this.difficulty = difficulty;
            this.topic = topic;
        }
        public int AskWithOptions(string question, int canswer, string option1, string option2, string option3)
        {
            Console.WriteLine(question);
            Console.WriteLine("Možnosti:");
            Console.WriteLine($"1. {option1}");
            Console.WriteLine($"2. {option2}");
            Console.WriteLine($"3. {option3}");
            if (DumbTest() == canswer)
            {
                Console.WriteLine($"Správná odpověď.");
                return 1;
            }
            else
            {
                Console.WriteLine($"Špatná odpověď. Správná odpověď je: {canswer}.");
                return 0;
            }
        }
    }
}
