namespace TablaDeHash.Models
{
    public static class SimpleHash
    {
        public static int Hash(string key, int tamaño)
        {
            int hash = key.Length;
            return hash % tamaño;
        }
    }
}
