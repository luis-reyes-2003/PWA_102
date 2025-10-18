namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSum();
        }

        private static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public static void PrintSum()
        {
            int sum = AddNumbers(3, 6);
            Console.Write($"Suma: {sum}");
        }
    }
}