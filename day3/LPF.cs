using System;
using System.Collections.Generic; 
using System.Linq;
using System.Diagnostics;

namespace EulerProject
{
    class Program
    {

        List<int> factors;

        int RecursiveLPF(long number) {
            factors = new List<int>();

            RecursiveHelper(number);
            
            return factors.Max();
        }

        void RecursiveHelper(long number) {
            if(number == 1) {
                return;
            }

            if(number % 2 == 0) {
                factors.Add(2);
                RecursiveHelper(number/2);
                return;
            }
            
            if(CheckIfPrime(number)) {
                factors.Add((int) number);
                RecursiveHelper(1);
                return;
            }

            for(int i = 3; i <= number; i = i + 2) {
                if(number % i == 0) {
                    if(CheckIfPrime(i)) {
                        factors.Add(i);
                        RecursiveHelper(number/i);
                        break;
                    }
                }
            } 
        }

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

        long LargestPrimeFactor(long number)
        {
            if (number % 2 == 0)
            {
                return 2;
            }

            long prime = 1;
            if (CheckIfPrime(number)) { return number; }

            long sqr = (long) Math.Sqrt(number);
            if (sqr % 2 == 0) sqr = sqr + 1;

            for (long i = 3; i < sqr; i = i + 2)
            {
                if (number % i == 0)
                {
                    if (CheckIfPrime(i))
                    {
                        if(CheckIfPrime(number / i)) {
                            Console.WriteLine(number/i);
                            return number / i;
                        }
                        Console.WriteLine(i);
                        return i;
                    }
                }
            }

            
            return prime;
        }

        static double average(long[] times) {
            long average = 0;
            for(int i = 0; i < times.Length; i ++) {
                average = average + times[i];
            }

            return average/1000.0;

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
            Console.WriteLine(p.RecursiveLPF(21313123121));
            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds + " milliseconds.");

        }
    }
}
