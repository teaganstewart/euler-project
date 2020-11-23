using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Palindromes
{
    class Program
    {

        int Power(int a, int b) {
            int pow = 1;
            for(int i = 0; i < b; i ++) {
                pow *= a;
            }
            return pow;
        }

        int LargestPalindromeProduct(int n)
        {
            int top = Power(10,n);
            int bottom = Power(10, n-1);

            int max = 0;
            for (int i = top; i > bottom; --i)
            {
                for (int j = i; j > bottom; --j)
                {
                    int l = i * j;

                    if (CheckPalindrome(l))
                    {
                        if (l > max) max = l;
                    }
                }
            }

            return max;
        }

        bool CheckPalindrome(int n)
        {
            string str = n.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(new Program().LargestPalindromeProduct(3));
        }
    }

}
