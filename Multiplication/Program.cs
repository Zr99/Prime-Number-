using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting ......");

        // Declare variables        
        var primesList = new List<int>();
        var products = new HashSet<long>();

        int count = 0;

        // Declare constant variable
        const long MAXIMUM_TWELVE_DIGITS = 1000000000000;
        const long MINIMUM_DIGIT = 99999999999;
        const int MAX_PRIME_NUMBER = 1000;
        const int TARGET_COUNT = 1;
        // Create a new random object
        var random = new Random();

        // Set the MAX CAP for the prime number
        //Add the prime number into a list called primesList
        for (int i = 2; i <= MAX_PRIME_NUMBER; i++)
        {
            // Check whether the value is prime number
            if (IsPrime(i))
            {
                //Add to the list if is prime
                primesList.Add(i);
            }
        }

        do
        {
            // Generate 4 random indices
            int indexA = random.Next(primesList.Count);
            int indexB = random.Next(primesList.Count);
            int indexC = random.Next(primesList.Count);
            int indexD = random.Next(primesList.Count);

            // Select 4 random prime numbers from the list
            int a = primesList[indexA];
            int b = primesList[indexB];
            int c = primesList[indexC];
            int d = primesList[indexD];

            // Multiply the 4 prime numbers and get the product
            long product = (long)a * b * c * d;

            // Make sure the product is 12 digits
            if (product < MAXIMUM_TWELVE_DIGITS && product > MINIMUM_DIGIT)
            {
                // Convert a long variable "product" into a list of digits as integer
                var digits = product.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToList();

                // Declare the variable
                bool isAscending = true;
                int previous = 0;

                // Loop through the digit
                for (int i = 0; i < digits.Count; i++)
                {
                    // Compare each digit with the previous one,
                    // and if any digit is less than the previous one,
                    // it sets the isAscending variable to false and breaks out of the loop.
                    if (digits[i] < previous)
                    {
                        isAscending = false;
                        break;
                    }
                    // Check if the difference between the current digit and the previous digit is greater than 1.
                    // If it is, set isAscending to false and break out of the loop.
                    if (i > 0 && (digits[i] - previous) > 1)
                    {
                        isAscending = false;
                        break;
                    }
                    
                    previous = digits[i];
                }

                // Check if the value is ascending order and not in the products list
                // Same product value but different combination will only show ONCE 
                if (isAscending && !products.Contains(product))
                {
                    // Print the a b c d value with the product
                    Console.WriteLine($"a: {a}, b: {b}, c: {c}, d: {d}, product: {product}");
                    // Add into the products list if the product is show first time
                    products.Add(product);
                    // Increase the count
                    count++;

                }
            }
        } while (count < TARGET_COUNT);

        // Check if the count is zero
        if (count == 0)
            Console.WriteLine("No 12-digit products found.");




        // Indicate finish calculation
        Console.WriteLine("Finish Calculate");
        Console.ReadLine();

    }
    // Check whether the number is prime
    static bool IsPrime(int number)
    {
        // positive value only
        if (number <= 1)
            return false;
        if (number == 2)
            return true;
        //Divisible by 2
        if (number % 2 == 0)
            return false;
        var boundary = (int)Math.Floor(Math.Sqrt(number));
        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}


