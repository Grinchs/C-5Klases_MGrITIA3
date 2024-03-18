using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_5Klases_MGrITIA3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona();
            persona.Reģistrēt();

            if (persona.PietiekLidzeklu())
            {
                Console.WriteLine("Nauda tev pietika, nedēļu vēl izdzīvosi!");
            }
            else
            {
                Console.WriteLine("Aizej nodod depozīt, jauniet! Tev baigi tukšs maciņš...");
            }

            persona.Izvadīt();
        }

        public class Prece
        {
            public string nosaukums;
            public double cena;

            public void Reģistrēt()
            {
                Console.WriteLine("Ievadiet preces nosaukumu:");
                nosaukums = Console.ReadLine();
                Console.WriteLine("Ievadiet preces cenu:");
                cena = double.Parse(Console.ReadLine());
            }

            public void Izvadīt()
            {
                Console.WriteLine("Preces nosaukums: " + nosaukums);
                Console.WriteLine("Preces cena: " + cena);
            }
        }

        public class Grozs
        {
            public int skaits;
            public Prece[] preces;

            public void Reģistrēt()
            {
                Console.WriteLine("Ievadiet preču skaitu grozā:");
                skaits = int.Parse(Console.ReadLine());
                preces = new Prece[skaits];

                for (int i = 0; i < skaits; i++)
                {
                    Console.WriteLine("Ievadiet informāciju par " + (i + 1) + ". preci:");
                    preces[i] = new Prece();
                    preces[i].Reģistrēt();
                }
            }

            public double Kopsuma()
            {
                double summa = 0;
                foreach (Prece p in preces)
                {
                    summa += p.cena;
                }
                return summa;
            }

            public void Izvadīt()
            {
                Console.WriteLine("Preču skaits grozā: " + skaits);
                Console.WriteLine("Preču saraksts un cenas:");
                foreach (Prece p in preces)
                {
                    p.Izvadīt();
                }
                Console.WriteLine("Kopējā summa: " + Kopsuma());
            }
        }

        public class Persona
        {
            public string vards;
            private string parole;
            public Grozs grozs;
            public double lidzekli;

            public void Reģistrēt()
            {
                Console.WriteLine("Ievadiet personas vārdu:");
                vards = Console.ReadLine();
                Console.WriteLine("Ievadiet paroli:");
                parole = Console.ReadLine();
                Console.WriteLine("Ievadiet personas līdzekļus:");
                lidzekli = double.Parse(Console.ReadLine());

                grozs = new Grozs();
                grozs.Reģistrēt();
            }

            public bool PietiekLidzeklu()
            {
                return lidzekli >= grozs.Kopsuma();
            }

            public void Izvadīt()
            {
                Console.WriteLine("Persona: " + vards);
                Console.WriteLine("Parole: " + parole);   
                Console.WriteLine("Pieejamie līdzekļi: " + lidzekli);
                Console.WriteLine();
                grozs.Izvadīt();
            }
        }
    }
}

