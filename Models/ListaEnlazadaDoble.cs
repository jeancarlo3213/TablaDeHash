namespace TablaDeHash.Models
{
    public class ListaEnlazadaDoble
    {
        private Nodo primerNodo;
        private Nodo ultimoNodo;

        public ListaEnlazadaDoble()
        {
            primerNodo = null;
            ultimoNodo = null;
        }

        public void Agregar(string clave, string valor)
        {
            Nodo nuevoNodo = new Nodo(clave, valor);
            if (primerNodo == null)
            {
                primerNodo = nuevoNodo;
                ultimoNodo = nuevoNodo;
            }
            else
            {
                ultimoNodo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = ultimoNodo;
                ultimoNodo = nuevoNodo;
            }
        }

        public bool Eliminar(string clave)
        {
            Nodo actual = primerNodo;
            while (actual != null)
            {
                if (actual.Clave == clave)
                {
                    if (actual.Anterior != null)
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                    }
                    else
                    {
                        primerNodo = actual.Siguiente;
                    }

                    if (actual.Siguiente != null)
                    {
                        actual.Siguiente.Anterior = actual.Anterior;
                    }
                    else
                    {
                        ultimoNodo = actual.Anterior;
                    }
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public string ObtenerValor(string clave)
        {
            Nodo actual = primerNodo;
            while (actual != null)
            {
                if (actual.Clave == clave)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public Nodo ObtenerPrimerNodo()
        {
            return primerNodo;
        }
    }
}
