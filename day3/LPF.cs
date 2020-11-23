using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace EulerProject
{
    // Creates three methods of solving the Largest Prime Factor algorithm. Recursive, Iterative 
    // and a normal loop.
    class Program
    {

        // Stores the prime factors of the recursive method's number.
        List<int> factors;

        // --------------------------------------
        //          ITERATIVE VERSION 
        // --------------------------------------

        // Base method for the iterative LPF algorithm. 
        /// <param name="number"> The number we are find the LPF of. </param>
        /// <returns> The largest prime factor of number. </param>
        long IterativeLPF(long number)
        {
            long max = 0;

            while (number != 1)
            {
                if (number % 2 == 0)
                {
                    number = number / 2;
                    if (2 > max) max = 2;
                    continue;
                }

                // Checks if the current number is prime. If it is it will skip the next long loop.
                if (CheckIfPrime(number))
                {
                    if (number > max) max = number;
                    number = 1;
                    continue;
                }

                // Loops through remaining numbers to check for factors.
                for (int i = 3; i < number; i = i + 2)
                {
                    if (number % i == 0)
                    {
                        if (CheckIfPrime(i))
                        {
                            max = i;
                            number = number / i;
                            break;
                        }
                    }
                }

            }

            return max;
        }

        // --------------------------------------
        //          RECURSIVE VERSION 
        // --------------------------------------

        // Base method for the recursive LPF algorithm. 
        /// <param name="number"> The number we are find the LPF of. </param>
        /// <returns> The largest prime factor of number. </param>
        int RecursiveLPF(long number)
        {
            factors = new List<int>();

            RecursiveHelper(number);

            return factors.Max();
        }

        // Adds the smallest prime number to the list of factors, then recalls the method with the new number.
        // Returns when the number is one.
        /// <param name="number"> The number we are find the LPF of. </param>
        void RecursiveHelper(long number)
        {
            // When the number is one all factors have been found, so break.
            if (number == 1)
            {
                return;
            }

            // If it is even it shouldn't reach the loop.
            if (number % 2 == 0)
            {
                factors.Add(2);
                RecursiveHelper(number / 2);
                return;
            }

            // Checks if the current number is prime. If it is it will skip the next long loop.
            if (CheckIfPrime(number))
            {
                factors.Add((int)number);
                RecursiveHelper(1);
                return;
            }

            // Loops through remaining numbers to check for factors.
            for (int i = 3; i < number; i = i + 2)
            {
                if (number % i == 0)
                {
                    if (CheckIfPrime(i))
                    {
                        factors.Add(i);
                        RecursiveHelper(number / i);
                        break;
                    }
                }
            }
        }

        // long LargestPrimeFactor(long number)
        // {
        //     if (number % 2 == 0)
        //     {
        //         return 2;
        //     }

        //     long prime = 1;
        //     if (CheckIfPrime(number)) { return number; }

        //     long sqr = (long)Math.Sqrt(number);
        //     if (sqr % 2 == 0) sqr = sqr + 1;

        //     for (long i = 3; i < sqr; i = i + 2)
        //     {
        //         if (number % i == 0)
        //         {
        //             if (CheckIfPrime(i))
        //             {
        //                 if (CheckIfPrime(number / i))
        //                 {
        //                     Console.WriteLine(number / i);
        //                     return number / i;
        //                 }
        //                 Console.WriteLine(i);
        //                 return i;
        //             }
        //         }
        //     }


        //     return prime;
        // }

        // Finds the average time based of 1000 runs.
        /// <param name="times"> The list of times of each run of the algorithm. </param>
        static double average(long[] times)
        {
            long average = 0;
            for (int i = 0; i < times.Length; i++)
            {
                average = average + times[i];
            }

            return average / 1000.0;

        }

        // --------------------------------------
        //          HELPERS METHODS  
        // --------------------------------------

        // Checks if a number is prime. Helper method for the LPF algorithm.
        /// <param name="number"> The number we are find the LPF of. </param>
        bool CheckIfPrime(long number)
        {
            for (long i = 3; i < number; i = i + 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            //long[] times = new long[1000];
            //for(int i = 0; i < 1000; i++) {
            // Stopwatch stopWatch = new Stopwatch();
            // stopWatch.Start();
            // new Program().LargestPrimeFactor(21313123121);
            // stopWatch.Stop();
            //times[i] = stopWatch.ElapsedMilliseconds;

            //}    

            //Console.WriteLine("" + average(times));

            Program p = new Program();
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            Console.WriteLine(p.IterativeLPF(21313123121));
            stopWatch.Stop();
            Console.WriteLine("Iterative Method: Took " + stopWatch.ElapsedMilliseconds + " milliseconds.");

            stopWatch.Start();
            Console.WriteLine(p.RecursiveLPF(21313123121));
            stopWatch.Stop();
            Console.WriteLine("Recursive Method: Took " + stopWatch.ElapsedMilliseconds + " milliseconds.");

        }
    }
}
