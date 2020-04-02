// ---------------------------------------------------------------------------------------
// Perfect Number Generator
// Michael Hollas, 2020/4/2
// ---------------------------------------------------------------------------------------



// ---------------------------------------------------------------------------------------
// IMPORTS
// ---------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;



namespace PerfectNumberGenerator
    // ---------------------------------------------------------------------------------------
{   // CLASSES
    // ---------------------------------------------------------------------------------------


    // ---------------------------------------------------------------------------------------
    // CLASS: Generate Perfect Numbers
    // ---------------------------------------------------------------------------------------
    public class GeneratePerfectNumbers
    {
        /* 
         Creates an object which will generate a list of perfect numbers - how many can be input by the user in the overflow - the defult is 7 - 8 will work, but validation is slow - 9 is too slow

            this code utlizes that perfect numbers are in the form (2^(p-1))*(2^p -1) where (2^p -1) is prime - also known as a Mersenne Prime
            
            each Perfect number has a Mersenne prime pair - so can be caluculated by finding Mersenne primes 

            msut use the .Show() method to print the result to the console.

            .Validate() method will calculate the sum of the factors for each of these numbers, and if the sum is the same as the number, it will yield a bool value true.
            this is done for all found perfect numbers , and is output as a list of bools.


             */
        public List<long> perfectNumbers;

        // ---------------------------------------------------------------------------------------
        //METHOD: Generate Perfect Numbers
        // ---------------------------------------------------------------------------------------
        public GeneratePerfectNumbers(int totalNumberofPerfects = 7)
        {

          perfectNumbers =  MersennePrimes(totalNumberofPerfects);
           
        }

        // ---------------------------------------------------------------------------------------
        //METHOD: Mersenne Primes
        // ---------------------------------------------------------------------------------------
        public List<long> MersennePrimes(int numberOfPrimes)
        {
            /*
             THis method generates Mersenne primes - then outputs a list of perfect numbers assoiated with those primes 
             the total number is determiend by the overflow when creting the object


             */
            int p = 2;
            int primeCount = 0;
            List<long> outlist = new List<long>();
            while (primeCount < numberOfPrimes)
            {
                if (Isprime((long)(Math.Pow(2, p)) - 1)) // Check if 2^p - 1 is prime - if it is, its as Mersonne prime - then add to the list
                {
                    outlist.Add((long)Math.Pow(2, p-1) * ((long)Math.Pow(2, p) - 1)); // calculate perfect number
                    primeCount++;
                }
                p++;
            }
            return outlist; // returns a list of perfect numbers - requires .Show()  to display to the console 
        }

        // ---------------------------------------------------------------------------------------
        //METHOD: Is Prime
        // ---------------------------------------------------------------------------------------
        public bool Isprime(long num)

            /*
         check if a number is prime
         finds first factor, if one is found break and set isprime to false 
         */
        {
            bool isprime = true;
            
            if (num == 2)
            {
                
                return isprime;
            }
            if (num == 3)
            {
                
                return isprime;
            }
            for (long i = 2; i < Math.Sqrt(num)+1; i++) // only need to go to the square root of number
            {
                if (num%i == 0)
                {
                    isprime = false;
                    break;
                }
            }
            return isprime;
        }

        // ---------------------------------------------------------------------------------------
        //METHOD: Show
        // ---------------------------------------------------------------------------------------
        public void Show() // writes list of perfect numbers to the console 
        {
            Console.WriteLine(String.Join(", ", perfectNumbers));
        }

        // ---------------------------------------------------------------------------------------
        //METHOD: Validate
        // ---------------------------------------------------------------------------------------
        public List<bool> Validate() // Validates if a number id perfect for all numbers generated by the object --- this can be slow for really big numbers -- works well up to 8 perfect numbers 
        {
            List<bool> ValidateList = new List<bool>();
            foreach (long number in perfectNumbers)
            {
                long sum = 1;

                    
                for (long i = 2; i <= Math.Sqrt(number) ; i++) // find any factors, and their pairs, and add them up. as we are finding their pairs we don't need to go past the sqrt of the number
                {
                    if (number % i == 0)
                    {

                        sum += i;
                        sum += number / i;
                    }
                }
                

                if (sum == number)
                {
                    ValidateList.Add(true)    ;
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
