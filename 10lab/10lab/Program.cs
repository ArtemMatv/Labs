namespace _10lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 5, 6, 1, 3 };

            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }

            arr.SortByDecrease();
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }

            System.Console.ReadKey();
        }
    }
}
