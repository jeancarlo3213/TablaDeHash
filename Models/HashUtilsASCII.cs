namespace TablaDeHash.Models
{
    public static class HashUtilsASCII
    {
        public static int CustomHashFunctionASCII(string input, int size)
        {
            int hash = 0;
            foreach (char c in input)
            {
                hash += c;
            }
            return Math.Abs(hash) % size;
        }
    }
}
