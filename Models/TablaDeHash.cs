namespace TablaDeHash.Models
{
    public class TablaDeHash
    {
        private ListaEnlazadaDoble[] tabla;
        private int tamaño;
        private bool useSimpleHash;
        private bool useWeightedHash;

        public TablaDeHash(int tamaño, bool useSimpleHash = false, bool useWeightedHash = false)
        {
            this.tamaño = tamaño;
            this.useSimpleHash = useSimpleHash;
            this.useWeightedHash = useWeightedHash;
            tabla = new ListaEnlazadaDoble[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                tabla[i] = new ListaEnlazadaDoble();
            }
        }

        private int CustomHashFunction(string clave)
        {
            int hash = 0;
            int prime = 31;

            foreach (char c in clave)
            {
                hash = (hash * prime) + c;
            }

            return Math.Abs(hash) % tamaño;
        }

        private int SimpleHashFunction(string clave)
        {
            int hash = clave.Length;
            return hash % tamaño;
        }

        private int WeightedHashFunction(string clave)
        {
            int hash = 0;
            for (int i = 0; i < clave.Length; i++)
            {
                hash += (i + 1) * clave[i]; // Peso por posición
            }
            return Math.Abs(hash) % tamaño;
        }

        public void Agregar(string clave, string valor)
        {
            int indice = useSimpleHash ? SimpleHashFunction(clave) : useWeightedHash ? WeightedHashFunction(clave) : CustomHashFunction(clave);
            tabla[indice].Agregar(clave, valor);
        }

        public bool Eliminar(string clave)
        {
            int indice = useSimpleHash ? SimpleHashFunction(clave) : useWeightedHash ? WeightedHashFunction(clave) : CustomHashFunction(clave);
            return tabla[indice].Eliminar(clave);
        }

        public string ObtenerValor(string clave)
        {
            int indice = useSimpleHash ? SimpleHashFunction(clave) : useWeightedHash ? WeightedHashFunction(clave) : CustomHashFunction(clave);
            return tabla[indice].ObtenerValor(clave);
        }

        public NodoAgrupado[] ObtenerTodosLosNodosAgrupados()
        {
            NodoAgrupado[] resultado = new NodoAgrupado[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                resultado[i] = new NodoAgrupado
                {
                    Indice = i,
                    PrimerNodo = tabla[i].ObtenerPrimerNodo()
                };
            }
            return resultado;
        }
    }
}
