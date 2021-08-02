using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    public static class FizzBuzzer
    {
        private static int _firstDivisor;
        private static int _secondDivisor;
        private static int _leastCommonMultiple;

        public static int FirstDivisor
        {
            get
            {
                if (_firstDivisor == 0)
                {
                    _firstDivisor = 3;
                }

                return _firstDivisor;
            }
            set
            {
                if (_firstDivisor != value)
                {
                    _firstDivisor = value;
                    LeastCommonMultiple = GetLeastCommonMultiple(FirstDivisor, SecondDivisor);
                }
            }
        }

        public static int SecondDivisor
        {
            get
            {
                if (_secondDivisor == 0)
                {
                    _secondDivisor = 5;
                }

                return _secondDivisor;
            }
            set
            {
                if (_secondDivisor != value)
                {
                    _secondDivisor = value;

                    LeastCommonMultiple = GetLeastCommonMultiple(FirstDivisor, SecondDivisor);
                }
            }
        }

        public static int LeastCommonMultiple
        {
            get
            {
                if (_leastCommonMultiple == 0)
                {
                    _leastCommonMultiple = GetLeastCommonMultiple(FirstDivisor, SecondDivisor);
                }

                return _leastCommonMultiple;
            }
            private set { _leastCommonMultiple = value; }
        }

        public static string GetValueForNumber(int number)
        {
            string output;

            if (number % LeastCommonMultiple == 0)
            {
                output = "FizzBuzz";
            }
            else if (number % FirstDivisor == 0)
            {
                output = "Fizz";
            }
            else if (number % SecondDivisor == 0)
            {
                output = "Buzz";
            }
            else
            {
                output = number.ToString();
            }

            return output;
        }

        public static string PrintValues(int startingValue, int endingValue)
        {
            if (startingValue > endingValue)
            {
                var message = $"{nameof(startingValue)} must be less or equal than {nameof(endingValue)}";
                throw new ArgumentException(message, nameof(startingValue));
            }

            var output = new StringBuilder();

            for (int i = startingValue; i <= endingValue; i++)
            {
                output.AppendLine(GetValueForNumber(i));
            }

            return output.ToString();
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int GetLeastCommonMultiple(int a, int b)
        {
            return (a / GreatestCommonDivisor(a, b)) * b;
        }
    }
}
