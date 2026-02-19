namespace Laboratorio_Alberi.Core
{
    public class Nodo<T>
    {
        public T Valore { get; set; }
        public Nodo<T> Sinistro { get; set; }
        public Nodo<T> Destro { get; set; }

        public Nodo(T valore)
        {
            Valore = valore;
            Sinistro = null;
            Destro = null;
        }
    }
}