namespace Monoalphabet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Monoalphabet mon = new Monoalphabet();

            string key = mon.GeneratePermutation();

            Console.WriteLine("Actual:" + key);

            string encr = mon.Encrypt(File.ReadAllText(@"../../../Sampletext.txt"), key);

            string guess = mon.Cryptanalisys(encr);

            Console.WriteLine("Guess: " + guess);

            File.WriteAllText(@"../../../Output.txt", mon.Decrypt(encr, guess));

        }
    }
}