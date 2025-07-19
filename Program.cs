using System;

class Program
{
    static void Main(string[] args)
    {
        // Input phase
        Console.Write("Enter number of coupons: ");
        int n;

        // Ensure input is valid and within range
        while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 100)
        {
            Console.WriteLine("Invalid input. Enter a number between 1 and 100:");
        }

        int[] coupons = new int[n];
        Console.WriteLine("Enter coupon values, separated by spaces:");
        string[] inputs = Console.ReadLine().Split();

        while (inputs.Length != n)
        {
            Console.WriteLine($"Please enter exactly {n} values:");
            inputs = Console.ReadLine().Split();
        }

        for (int i = 0; i < n; i++)
        {
            while (!int.TryParse(inputs[i], out coupons[i]) || coupons[i] <= 0)
            {
                Console.WriteLine("Invalid value. Coupon values must be positive integers.");
                Console.Write($"Re-enter coupon #{i + 1}: ");
                int.TryParse(Console.ReadLine(), out coupons[i]);
            }
        }

        // Processing phase
        int totalValue = 0;
        int maxValue = coupons[0];
        int maxIndex = 0;

        int smallCount = 0;
        int mediumCount = 0;
        int largeCount = 0;

        for (int i = 0; i < n; i++)
        {
            int value = coupons[i];
            totalValue += value;

            if (value > maxValue)
            {
                maxValue = value;
                maxIndex = i;
            }

            // Category classification
            if (value <= 50)
                smallCount++;
            else if (value <= 100)
                mediumCount++;
            else
                largeCount++;
        }

        // Output phase
        Console.WriteLine("\n----- Daily Coupon Summary -----");
        Console.WriteLine($"Total coupons redeemed  : {n}");
        Console.WriteLine($"Total value collected   : {totalValue}");
        Console.WriteLine($"Highest coupon redeemed : {maxValue} (coupon #{maxIndex + 1})\n");

        Console.WriteLine("Category breakdown");
        Console.WriteLine($"Small  (≤50)   : {smallCount}");
        Console.WriteLine($"Medium (51-100): {mediumCount}");
        Console.WriteLine($"Large  (>100)  : {largeCount}");
    }
}
