using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to my game! Let's do some math!");
                StartSequence();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Invalid input. The number is too large.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Program completed.");
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Please enter a number greater than zero:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[size];

            numbers = Populate(numbers);

            int sum = GetSum(numbers);
            int product = GetProduct(numbers, sum);
            decimal quotient = GetQuotient(product);

            Console.WriteLine($"Your array is size: {size}");
            Console.WriteLine($"The numbers in the array are: {string.Join(",", numbers)}");
            Console.WriteLine($"The sum of the array is: {sum}");
            Console.WriteLine($"The product of the array and random number is: {product}");
            Console.WriteLine($"The quotient of the product and user input is: {quotient}");
        }

        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Please enter number {i + 1} of {numbers.Length}: ");
                string input = Console.ReadLine();
                numbers[i] = int.Parse(input);
            }

            return numbers;
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }

            return sum;
        }

        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine("Please select a random number between 1 and the length of the integer array:");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= numbers.Length)
            {
                throw new IndexOutOfRangeException("Invalid index. Index is out of range.");
            }

            int product = sum * numbers[index];
            return product;
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by:");
            decimal divisor = decimal.Parse(Console.ReadLine());

            if (divisor == 0)
            {
                Console.WriteLine("Divide by zero exception. Quotient is set to 0.");
                return 0;
            }

            decimal quotient = decimal.Divide(product, divisor);
            return quotient;
        }
    }
}
