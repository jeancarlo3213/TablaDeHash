namespace TablaDeHash.Models
{
    public static class WeightedHash
    {
        public static int Hash(string key, int tamaño)
        {
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash += (i + 1) * key[i]; // Peso por posición
            }
            return Math.Abs(hash) % tamaño;
        }
    }
}
