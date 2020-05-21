using System;

namespace SellNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellNumber("19778999");
            SpellNumber("5523");
            SpellNumber("2");
            SpellNumber("8989");
            
        }

        // A function that prints  
        // given number in words  
        static void SpellNumber(string Number)
        {
            long numcheck;
            bool check = long.TryParse(Number, out numcheck);

            if (!check)
            {
                Console.WriteLine("Not a Number");
                return;
            }

            // Get number of digits  
            // in given number  
            int len = Number.ToCharArray().Length;

            // Base cases  
            if (len == 0)
            {
                Console.WriteLine("empty string");
                return;
            } 

            // Convert string to char array 
            Char[] num = Number.ToCharArray();

            /* The first string is not used,  
               it is to make array indexing simple */
            string[] single_digits = new string[]{ "zero", "one", "two",
                                           "three", "four", "five",
                                           "six", "seven", "eight",
                                           "nine"};

            /* The first string is not used,  
               it is to make array indexing simple */
            string[] two_digits = new string[]{"", "ten", "eleven", "twelve",
                                       "thirteen", "fourteen",
                                       "fifteen", "sixteen", "seventeen",
                                       "eighteen", "nineteen"};

            /* The first two string are not used, 
               they are to make array indexing simple*/
            string[] tens_multiple = new string[]{"", "", "twenty", "thirty",
                                          "forty", "fifty","sixty",
                                          "seventy", "eighty", "ninety"};

            string[] tens_power = new string[] { "hundred", "thousand" };

            /* Used for debugging purpose only */
            Console.Write((new string(num)) + ": ");

            /* For single digit number */
            if (len == 1)
            {
                Console.WriteLine(single_digits[num[0] - '0']);
                return;
            }

            /* Iterate while num  
                is not '\0' */
            int x = 0;
            while (x < num.Length)
            {

                /* Code path for first 2 digits */
                if (len >= 3)
                {
                    if (num[x] - '0' != 0)
                    {

                        if (len%6==0 || len %3==0)
                        {
                            Console.Write(single_digits[num[x] - '0'] + " ");
                            Console.Write(tens_power[0] + " ");
                        }
                        if (len % 4 ==0 || len % 6 == 1)
                        {
                            Console.Write(single_digits[num[x] - '0'] + " ");
                            Console.Write(tens_power[1] + " ");
                        }
                        else if (len % 5 == 0 || (x > 7 && len % 5 == 1))
                        {
                            int i = (num[x] - '0');
                            if (i > 0)
                                Console.Write(tens_multiple[i] + " ");
                            else
                                Console.Write("");
                        }


                        // here len can be 3 or 4  
                    }
                    --len;
                }

                /* Code path for last 2 digits */
                else
                { 
                    /* Need to explicitly handle  
                    10-19. Sum of the two digits  
                    is used as index of "two_digits"  
                    array of strings */
                    if (num[x] - '0' == 1)
                    {
                        int sum = num[x] - '0' +
                                  num[x] - '0';
                        Console.WriteLine(two_digits[sum]);
                        return;
                    }

                    /* Need to explicitely handle 20 */
                    else if (num[x] - '0' == 2 &&
                             num[x + 1] - '0' == 0)
                    {
                        Console.WriteLine("twenty");
                        return;
                    }

                    /* Rest of the two digit  
                    numbers i.e., 21 to 99 */
                    else
                    {
                        int i = (num[x] - '0');
                        if (i > 0)
                            Console.Write(tens_multiple[i] + " ");
                        else
                            Console.Write("");
                        ++x;
                        if (num[x] - '0' != 0)
                            Console.WriteLine(single_digits[num[x] - '0']);
                    }
                }
                ++x;
            }
        }
    }
}
