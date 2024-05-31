namespace TablaDeHash.Models
{
    public class Nodo
    {
        public string Clave { get; set; }
        public string Valor { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }

        public Nodo(string clave, string valor)
        {
            Clave = clave;
            Valor = valor;
            Siguiente = null;
            Anterior = null;
        }
    }
}
