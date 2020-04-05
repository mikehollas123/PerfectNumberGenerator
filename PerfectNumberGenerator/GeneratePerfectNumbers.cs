// Perfect Number Generator
// Michael Hollas, 2020/4/2
// ---------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Numerics;

namespace PerfectNumberGenerator

{   /// <summary>
    /// Creates a perfect number generator objectCreates an object which will generate a list of perfect numbers - how many can be input by the user in the overflow - the defult is 7 - 8 will work, but validation is slow - 9 is too slow
    ///this code utlizes that perfect numbers are in the form (2^(p-1))*(2^p -1) where (2^p -1) is prime - also known as a Mersenne Prime
    ///each Perfect number has a Mersenne prime pair - so can be caluculated by finding Mersenne primes
    ///msut use the .Show() method to print the result to the console.
    ///.Validate() method will calculate the sum of the factors for each of these numbers, and if the sum is the same as the number, it will yield a bool value true.
    ///this is done for all found perfect numbers , and is output as a list of bools.
    /// </summary>
    public class GeneratePerfectNumbers
    {
        /// <summary>
        /// Starts the Generator - using the MersonnePrimes Method 
        /// </summary>
        /// <param name="totalNumberofPerfects">THe user can input how many Perfect numbers they wish to find before the program ends</param>
        /// <returns>Returns a List of the found perfect numbers</returns>
        public List<BigInteger> Generate(int totalNumberofPerfects = 7)
        {
            return MersennePrimes(totalNumberofPerfects); // evenutally this method will have different operations - one for LLH, brute force, etc
        }
        /// <summary>
        /// THis method generates Mersenne numbers in the form  2^p - 1 , then determines if that number is prime using the LucasLehmer Method.
        /// if deterimined to be prime, the number is added to the Perfect number list, and is also written to the console.
        /// </summary>
        /// <param name="numberOfPrimes">how many Perfect numbers they wish to find before the program ends - passed from the Generate method</param>
        /// <returns>Returns a List of the found perfect numbers</returns>
        private List<BigInteger> MersennePrimes(int numberOfPrimes)
        {
            int p = 2;
            int primeCount = 0;
            List<BigInteger> outlist = new List<BigInteger>();
            while (primeCount < numberOfPrimes)
            {
                BigInteger MPrimebig = BigPower(2, p) - 1;
                BigInteger MPairBig = BigPower(2, p - 1);
                if (LucasLehmer(p)) // Check if 2^p - 1 is prime - if it is, its as Mersonne prime - then add to the list
                {
                    BigInteger PerfectNumber = MPairBig * MPrimebig;
                    outlist.Add(PerfectNumber); // calculate perfect number
                    Console.WriteLine("Perfect Number Found: {0}", PerfectNumber);
                    primeCount++;
                }
                p++;
            }
            return outlist; // returns a list of perfect numbers - requires .Show()  to display to the console 
        }
        /// <summary>
        /// Allows the x^y for really large numbers. BigInterger doesn't have it's own power operator so I had to make one. 
        ///----ONLY WORKS IF Y +ve INT----
        /// </summary>
        /// <param name="x">input BigInteger to be operated on</param>
        /// <param name="y">input int x^y </param>
        /// <returns>returns x^y for realy big numbers</returns>
        private static BigInteger BigPower(BigInteger x, int y)
        {
            BigInteger outnum = x;
            for (int i = 1; i < y; i++)
            {
                outnum *= x;
            }
            return outnum;
        }

        /// <summary>
        /// deterimes if a number is prime - this is the brute force method - as opposed to the LucasLehmer method
        /// THis is not a prediciton - but slow!
        /// finds first factor, if one is found break and set isprime to false 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool Isprime(BigInteger num) // CURRENTLY UNUSED 
        {
            bool isprime = true;
            double Sqrtnum = Math.Sqrt((double)num); //hopefully double is large enough to hold this big interger. 

            if (num == 2)
            {
                return isprime;
            }
            if (num == 3)
            {
                return isprime;
            }
            for (ulong i = 2; i < Sqrtnum + 1; i++) // only need to go to the square root of number
            {
                if (num % i == 0)
                {
                    isprime = false;
                    break;
                }
            }
            return isprime;
        }
        /// <summary>
        /// Determines if a Mersonne number is prime (2^p - 1) 
        /// Is a prediction, but is highly predictive of a prime number - Known as LLH method - this is how people acctually find these numbers
        /// </summary>
        /// <param name="p">the input p for the mersonne number </param>
        /// <returns> bool true if number is probably prime, otherwise false</returns>
        public static bool LucasLehmer(int p)
        {
            bool isprime = false;
            BigInteger s = 4;
            BigInteger MersoneNumber = (BigPower(2, p) - 1);
            if (p == 2)
            {
                isprime = true;
                return isprime;
            }
            for (int i = 0; i < p - 2; i++)
            {

                s = ((s * s) - 2) % MersoneNumber;

            }
            if (s == 0)
            {
                isprime = true;
            }
            return isprime;
        }

        /// <summary>
        /// Static method that will output the perfect numbers as a string to the console 
        /// </summary>
        /// <param name="perfectNumbers">List of perfect numbers generated </param>
        public static void Show(List<BigInteger> perfectNumbers) // writes list of perfect numbers to the console 
        {
            Console.WriteLine(String.Join(", ", perfectNumbers));
        }

        /// <summary>
        /// Validates if a number id perfect for all numbers generated by the object --- this can be slow for really big numbers -- works well up to 8 perfect numbers
        /// this is a brute force method. it finds all the factors and sums them. This is very slow!!!
        /// </summary>
        /// <param name="perfectNumbers">List of perfect numbers generated</param>
        /// <returns> a list of bools the same length as the list of perfect number list</returns>
        public static List<bool> Validate(List<BigInteger> perfectNumbers)
        {
            List<bool> ValidateList = new List<bool>();
            foreach (BigInteger number in perfectNumbers)
            {
                BigInteger sum = 1;
                double sqrtnumber = Math.Sqrt((double)number);

                for (int i = 2; i <= sqrtnumber; i++) // find any factors, and their pairs, and add them up. as we are finding their pairs we don't need to go past the sqrt of the number
                {
                    if (number % i == 0)
                    {

                        sum += i;
                        sum += number / i;
                    }
                }
                if (sum == number)
                {
                    ValidateList.Add(true);
                    Console.WriteLine("{0} has been validated", number);
                }
                else
                {
                    ValidateList.Add(false);
                }
            }
            return ValidateList; // return this of bools - corresponding to the numbers generated by the object 
        }

    }
}
