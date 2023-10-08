namespace Monoalphabet
{
    internal class Monoalphabet
    {
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public string GeneratePermutation()
        {
            Random rnd = new Random();
            char[] permutation = alphabet.ToCharArray();

            for (int i = 0; i < permutation.Length; i++)
            {
                int randIndex = rnd.Next(0, permutation.Length);

                (permutation[i], permutation[randIndex]) = (permutation[randIndex], permutation[i]);
            }

            return string.Join("", permutation);
        }

        public string Encrypt(string input)
        {
            return Encrypt(input, this.GeneratePermutation());
        }

        public string Encrypt(string input, string permutation)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                int index = alphabet.IndexOf(char.ToLower(input[i]));
                char currentChar = input[i];

                if (index != -1)
                {
                    currentChar = permutation[index];
                    if (char.IsUpper(input[i])) currentChar = char.ToUpper(currentChar);
                }

                output += currentChar;
            }


            return output;
        }

        public string Decrypt(string input, string permutation)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                int index = permutation.IndexOf(char.ToLower(input[i]));
                char currentChar = input[i];

                if (index != -1)
                {
                    currentChar = alphabet[index];
                    if (char.IsUpper(input[i])) currentChar = char.ToUpper(currentChar);
                }

                output += currentChar;
            }


            return output;
        }

        public string Cryptanalisys(string input)
        {
            char[] englishFrequency = "etaoinsrhdlucmfywgpbvkxqjz".ToCharArray();

            int[] frequency = new int[alphabet.Length];
            char[] localAlphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                int index = alphabet.IndexOf(input[i]);
                if (index != -1) frequency[index]++;
            }

            for (int i = 0; i < frequency.Length; i++)
            {
                for (int j = 0; j < frequency.Length - 1; j++)
                {
                    if (frequency[j] < frequency[j + 1])
                    {
                        (localAlphabet[j], localAlphabet[j + 1]) = (localAlphabet[j + 1], localAlphabet[j]);
                        (frequency[j], frequency[j + 1]) = (frequency[j + 1], frequency[j]);
                    }
                }
            }

            for (int i = 0; i < englishFrequency.Length; i++)
            {
                for (int j = 0; j < englishFrequency.Length - 1; j++)
                {
                    if (englishFrequency[j] > englishFrequency[j + 1])
                    {
                        (localAlphabet[j], localAlphabet[j + 1]) = (localAlphabet[j + 1], localAlphabet[j]);
                        (englishFrequency[j], englishFrequency[j + 1]) = (englishFrequency[j + 1], englishFrequency[j]);
                    }
                }
            }

            return string.Join("", localAlphabet);
        }

    }
}
