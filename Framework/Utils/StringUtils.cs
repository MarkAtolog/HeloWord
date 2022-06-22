namespace Framework.Utils
{
    public class StringUtils
    {
        private static readonly char[] Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] Digits = "0123456789".ToCharArray();
        public static string GenerateString(int len = 10, bool lower = true, bool upper = true, bool digits = true)
        {
            Random random = new();
            string result = String.Empty;

            for (int i = 0; i < len;)
            {
                if (lower)
                {
                    int letterNum = random.Next(Letters.Length);
                    result += Char.ToLower(Letters[letterNum]);
                    i++;
                }

                if (upper)
                {
                    int letterNum = random.Next(Letters.Length);
                    result += Letters[letterNum];
                    i++;
                }

                if (digits)
                {
                    int digitNum = random.Next(Digits.Length);
                    result += Char.ToLower(Digits[digitNum]);
                    i++;
                }
            }

            return result;
        }
    }
}
