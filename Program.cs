using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace HackBulgaria
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }
        //1
        public static BigInteger Factorial(int number)
        {
            if (number == 0)
                return 1;
            return number * Factorial(number - 1);
        }
        //2
        public static BigInteger NthLucas(int number)
        {
            BigInteger first_num = 2;
            BigInteger sec_num = 1;
            BigInteger sum = 0, i = 1;
            do
            {
                if (number == 0)
                {
                    sum = 2;
                    break;
                }
                else if(number == 1)
                {
                    sum = 1;
                    break;
                }
                sum = first_num + sec_num;
                first_num = sec_num;
                sec_num = sum;
                i++;
            } while (i < number);
            return sum;
        }

        public static List<BigInteger> FirstNLucas(int number)
        {
            List<BigInteger> list = new List<BigInteger>();
            for (int i = 0; i < number; i++)
            {
                list.Add(NthLucas(i));
            }
            return list;
        }

        //3
        public static int CountDigits(int number)
        {
            string length_of_number = number.ToString();
            return length_of_number.Length;
        }

        public static int SumDigits(int number)
        {
            string digits_in_numer = number.ToString();
            int sum = 0;
            for (int i = 0; i < digits_in_numer.Length; i++)
            {
                sum += int.Parse(digits_in_numer[i].ToString());
            }
            return sum;
        }

        public static BigInteger FactorialDigits(int number)
        {
            string digits = number.ToString();
            BigInteger sum = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                sum += Factorial(int.Parse(digits[i].ToString()));
            }
            return sum;
        }

        //4
        public static string FibNumber(int integer)
        {
            int first_fib = 1, sec_fib = 1, sum = 0;
            StringBuilder number = new StringBuilder();
            number.Append(first_fib.ToString());
            number.Append(sec_fib.ToString());
            for (int i = 2; i < integer; i++)
            {
                sum = first_fib + sec_fib;
                first_fib = sec_fib;
                sec_fib = sum;
                number.Append(sec_fib);
            }
            return number.ToString();
        }

        //5
        public static bool IsHack(int number)
        {
            string result = Convert.ToString(number, 2);
            if (result.EndsWith("1"))
            {
                return false;
            }
            int medium = result.Length / 2;
            string first = string.Empty, second = string.Empty;
            for (int i = 0; i < medium; i++)
            {
                if (result[medium - i].ToString() != result[medium + i].ToString())
                {
                    return false;
                }
            }
            return true;
        }

        //6
        public static int CountVowels(string str)
        {
            Regex pattern = new Regex("([aeiouy])");
            return pattern.Matches(str).Count;
        }

        //7
        public static int CountConsonants(string str)
        {
            Regex pattern = new Regex("[b-df-hj-np-tv-z]");
            return pattern.Matches(str).Count;
        }

        //8
        public static Dictionary<string,int> CharHistogram(string str)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dic.ContainsKey(str[i].ToString()))
                {
                    dic[str[i].ToString()]++;
                }
                else
                {
                    dic.Add(str[i].ToString(), 1);
                }
            }
            return dic;
        }

        //9//
        public static int PScore(string str)
        {
            int medium = str.Length / 2;
            string first = string.Empty, second = string.Empty;
            int i = 0, counter = 1, sum = int.Parse(str);
            do
            {
                if (str.Length % 2 == 0)
                {
                    first = str[medium - (1 + i)].ToString();
                    second = str[medium + i].ToString();
                }
                else
                {
                    first = str[medium - (1 + i)].ToString();
                    second = str[medium + (1 + i)].ToString();
                }
                
                if (first != second)
                {
                    counter++;
                    char[] arr = str.ToCharArray();
                    Array.Reverse(arr);
                    string str_new = new string(arr);
                    sum = int.Parse(str) + int.Parse(str_new);
                    str = sum.ToString();
                    medium = str.Length / 2;
                    i = 0;
                }
                else
                {
                    i++;
                }
            } while (i != medium);
            return counter;
        }

        //10
        public static bool IsIntPalindrome(int number)
        {
            string polindrome_integer = number.ToString();
            for (int i = 0; i < polindrome_integer.Length / 2; i++)
            {
                if (polindrome_integer[i] != polindrome_integer[polindrome_integer.Length - (i + 1)])
                {
                    return false;
                }
            }
            return true;
        }


        //11
        public static bool IsPrime(int number)
        {
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> ListFirstPrimes(int number)
        {
            List<int> primenum = new List<int>();
            int digit = 2, i = 0;
            bool isprime = false;
            do
            {
                isprime = IsPrime(digit);
                if (isprime == true)
                {
                    primenum.Add(digit);
                    i++;
                    isprime = false;
                }
                digit++;
            } while (i < number);
            return primenum;
        }
        //12
        public static int SumOfNumbersInString(string str)
        {
            Regex pattern = new Regex("[0-9]+");
            int sum = 0;
            foreach (Match item in pattern.Matches(str))
            {
                sum += int.Parse(item.Value);
            }
            return sum;
        }
        //13
        public static bool IsAnagram(string A, string B)
        {
            bool is_anagram = false;
            Regex pattern = new Regex("[" + A + "]");
            int numbers = pattern.Matches(B).Count;
            if (numbers == B.Length)
            {
                is_anagram = true;
            }
            return is_anagram;
        }

        //Matcix Bombing
        public static int MatrixBombing(int[,] matrix)
        {
            
            Console.WriteLine("Throw the bomb ar cordination :");
            int cordination = Convert.ToInt32(double.Parse(Console.ReadLine()) * 10);
            int bomb = matrix[cordination / 10, cordination % 10];
            int demage = 0;
            foreach (var item in matrix)
            {
                if (item <= bomb)
                {
                    demage += item;
                }
                else 
                {
                    demage += item - bomb;
                }
            }
            return demage;
        }
    }
}
