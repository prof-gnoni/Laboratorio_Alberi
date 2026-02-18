using Laboratorio_Alberi.Demos;
using System;
using System.Threading;

namespace Laboratorio_Alberi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Laboratorio Alberi & DFS";
            bool esci = false;

            while (!esci)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== GESTIONE STRUTTURE AD ALBERO ===");
                Console.ResetColor();
                Console.WriteLine("1. Teoria: DFS Ricorsiva vs Iterativa (Stack)");
                Console.WriteLine("2. Pratica: File System (Calcolo Dimensioni)");
                Console.WriteLine("0. Esci");
                Console.WriteLine("------------------------------------");
                Console.Write("Scelta: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int scelta))
                {
                    MostraErrore("Inserisci un numero valido!");
                    continue;
                }

                Console.WriteLine(); // Spaziatura

                switch (scelta)
                {
                    case 1:
                        EseguiDemoTeoria();
                        break;
                    case 2:
                        EseguiDemoFileSystem();
                        break;
                    case 0:
                        esci = true;
                        Console.WriteLine("Chiusura in corso...");
                        Thread.Sleep(1000);
                        break;
                    default:
                        MostraErrore("Opzione non disponibile.");
                        break;
                }

                if (!esci)
                {
                    Console.WriteLine("\n\nPremi un tasto per tornare al menu...");
                    Console.ReadKey();
                }
            }
        }

        static void EseguiDemoTeoria()
        {
            var demo = new DemoTeoria();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- VISITA RICORSIVA (Pre-Order) ---");
            Console.ResetColor();
            demo.VisitaRicorsiva(demo.Radice);

            Console.WriteLine("\n\n------------------------------------");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- VISITA ITERATIVA (Stack Esplicito) ---");
            Console.ResetColor();
            demo.VisitaIterativa();
        }

        static void EseguiDemoFileSystem()
        {
            var fs = new DemoFileSystem();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("--- ANALISI SPAZIO DISCO (Post-Order) ---");
            Console.ResetColor();
            Console.WriteLine("Calcolo dimensione totale partendo da C:...\n");

            int totale = fs.CalcolaDimensione(fs.RootFolder);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[TOTALE] Dimensione occupata: {totale} MB");
            Console.ResetColor();
        }

        static void MostraErrore(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"(!) {msg}");
            Console.ResetColor();
            Thread.Sleep(1500);
        }
    }
}