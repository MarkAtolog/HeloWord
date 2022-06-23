namespace Framework.Utils
{
    public class StringUtils
    {
        private const string upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";

        public static string GenerateString(int len = 10, bool isLower = true, bool isUpper = true, bool isDigit = true)
        {
            char[] result = new char[len];

            for (int i = 0; ;)
            {
                try
                {
                    if (isLower)
                    {
                        result[i] = GetRandomChar(lowerCaseLetters);
                        i++;
                    }

                    if (isUpper)
                    {
                        result[i] = GetRandomChar(upperCaseLetters);
                        i++;
                    }

                    if (isDigit)
                    {
                        result[i] = GetRandomChar(Digits);
                        i++;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            return new string(result);
        }

        private static char GetRandomChar(string sequence)
        {
            Random random = new();

            return sequence[random.Next(sequence.Length)];
        }
    }
}
