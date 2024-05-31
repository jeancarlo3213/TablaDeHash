namespace TablaDeHash.Models
{
    public static class HashUtils
    {
        public static int CustomHashFunction(string input, int size)
        {
            int hash = 0;
            int prime = 31;

            foreach (char c in input)
            {
                hash = (hash * prime) + c;
            }

            return Math.Abs(hash) % size;
        }
    }
}
