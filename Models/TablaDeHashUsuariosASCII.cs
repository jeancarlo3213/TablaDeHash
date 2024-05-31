namespace TablaDeHash.Models
{
    public class TablaDeHashUsuariosASCII
    {
        private ListaEnlazadaDoble[] tabla;
        private int tamaño;

        public TablaDeHashUsuariosASCII(int tamaño)
        {
            this.tamaño = tamaño;
            tabla = new ListaEnlazadaDoble[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                tabla[i] = new ListaEnlazadaDoble();
            }
        }

        public void Agregar(string clave, string valor, out int hash)
        {
            int indice = HashUtilsASCII.CustomHashFunctionASCII(clave, tamaño) + 1;
            hash = indice;
            tabla[indice - 1].Agregar(clave, valor); // Ajustar índice para la matriz
        }

        public bool Eliminar(string clave, out int hash)
        {
            int indice = HashUtilsASCII.CustomHashFunctionASCII(clave, tamaño) + 1;
            hash = indice;
            return tabla[indice - 1].Eliminar(clave); // Ajustar índice para la matriz
        }

        public string ObtenerValor(string clave, out int hash)
        {
            int indice = HashUtilsASCII.CustomHashFunctionASCII(clave, tamaño) + 1;
            hash = indice;
            return tabla[indice - 1].ObtenerValor(clave); // Ajustar índice para la matriz
        }

        public NodoAgrupado[] ObtenerTodosLosNodosAgrupados()
        {
            NodoAgrupado[] resultado = new NodoAgrupado[tamaño];
            for (int i = 0; i < tamaño; i++)
            {
                resultado[i] = new NodoAgrupado
                {
                    Indice = i + 1, // Ajustar índice para que empiece desde 1
                    PrimerNodo = tabla[i].ObtenerPrimerNodo()
                };
            }
            return resultado;
        }
    }
}
