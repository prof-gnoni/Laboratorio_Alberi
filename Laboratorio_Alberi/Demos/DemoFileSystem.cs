using Laboratorio_Alberi.Core;
using System;

namespace Laboratorio_Alberi.Demos
{
    public class DemoFileSystem
    {
        // Simuliamo che il "Valore" del nodo sia il nome del file/cartella
        // E aggiungiamo una logica fittizia per il peso

        public Nodo RootFolder { get; private set; }

        public DemoFileSystem()
        {
            RootFolder = new Nodo("C:");
            RootFolder.Sinistro = new Nodo("Programmi");
            RootFolder.Destro = new Nodo("Utenti");

            RootFolder.Sinistro.Sinistro = new Nodo("Minecraft"); // 100MB
            RootFolder.Destro.Sinistro = new Nodo("Documenti");   // 50MB
            RootFolder.Destro.Destro = new Nodo("Desktop");       // 20MB
        }

        // Calcola la dimensione totale simulata (Post-Order Traversal)
        public int CalcolaDimensione(Nodo cartella)
        {
            if (cartella == null) return 0;

            // 1. Scendo in profondità prima di calcolare
            int pesoSinistra = CalcolaDimensione(cartella.Sinistro);
            int pesoDestra = CalcolaDimensione(cartella.Destro);

            // 2. Logica di business simulata (ogni nodo "foglia" pesa tot)
            int pesoCorrente = SimulaPesoFile(cartella.Valore);

            int totale = pesoCorrente + pesoSinistra + pesoDestra;

            // Visualizzazione indentata per far capire la risalita
            Console.WriteLine($"Cartella '{cartella.Valore}': peso locale {pesoCorrente} + sub {pesoSinistra + pesoDestra} = {totale} MB");

            return totale;
        }

        private int SimulaPesoFile(string nome)
        {
            // Assegnazione pesi arbitraria per l'esempio
            if (nome == "Minecraft") return 100;
            if (nome == "Documenti") return 50;
            if (nome == "Desktop") return 20;
            return 1; // Le cartelle vuote pesano 1MB
        }
    }
}