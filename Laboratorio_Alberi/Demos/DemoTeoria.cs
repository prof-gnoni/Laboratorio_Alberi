using System;
using System.Collections.Generic;
using Laboratorio_Alberi.Core;

namespace Laboratorio_Alberi.Demos
{
    public class DemoTeoria
    {
        public Nodo Radice { get; private set; }

        public DemoTeoria()
        {
            // Costruzione albero dummy per i test
            //       [Radice]
            //       /      \
            //     [A]      [B]
            //     / \      / \
            //   [C] [D]  [E] [F]

            Radice = new Nodo("Radice");
            Radice.Sinistro = new Nodo("A");
            Radice.Destro = new Nodo("B");

            Radice.Sinistro.Sinistro = new Nodo("C");
            Radice.Sinistro.Destro = new Nodo("D");

            Radice.Destro.Sinistro = new Nodo("E");
            Radice.Destro.Destro = new Nodo("F");
        }

        // 1. APPROCCIO RICORSIVO (Elegante ma rischia StackOverflow)
        public void VisitaRicorsiva(Nodo nodo)
        {
            if (nodo == null) return;

            Console.Write($"[{nodo.Valore}] -> "); // Visita (Pre-Order)
            VisitaRicorsiva(nodo.Sinistro);
            VisitaRicorsiva(nodo.Destro);
        }

        // 2. APPROCCIO ITERATIVO (Robusto, usa Stack esplicito)
        public void VisitaIterativa()
        {
            if (Radice == null) return;

            // Ecco lo Stack esplicito!
            Stack<Nodo> nodiDaVisitare = new Stack<Nodo>();

            nodiDaVisitare.Push(Radice);

            while (nodiDaVisitare.Count > 0)
            {
                Nodo corrente = nodiDaVisitare.Pop();
                Console.Write($"[{corrente.Valore}] -> ");

                // IMPORTANTE: Inserisco PRIMA il destro, così il sinistro 
                // finisce in cima allo Stack e viene visitato per primo.
                if (corrente.Destro != null) nodiDaVisitare.Push(corrente.Destro);
                if (corrente.Sinistro != null) nodiDaVisitare.Push(corrente.Sinistro);
            }
        }
    }
}