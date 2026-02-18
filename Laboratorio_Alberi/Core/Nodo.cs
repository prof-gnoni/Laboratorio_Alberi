namespace Laboratorio_Alberi.Core
{
    public class Nodo
    {
        public string Valore { get; set; }
        public Nodo Sinistro { get; set; }
        public Nodo Destro { get; set; }

        public Nodo(string valore)
        {
            Valore = valore;
            Sinistro = null;
            Destro = null;
        }
    }
}