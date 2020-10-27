using System;
using System.Collections.Generic;

namespace Currency.Services
{
    public class CurrencyWordsService : ICurrencyWordsService
    {
        private static IReadOnlyDictionary<int, string> _digitToText = new Dictionary<int, string> {
            {0, "zero"},
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"} 
        };
        private static IReadOnlyDictionary<int, string> _secondDigitToText = new Dictionary<int, string> {
            {20, "twenty"},
            {30, "thirty"},
            {40, "fourty"},
            {50, "fifty"},
            {60, "sixty"},
            {70, "seventy"},
            {80, "eighty"},
            {90, "ninety"}
        };
        public static IReadOnlyDictionary<int, string> DigitToText => _digitToText;
        public static IReadOnlyDictionary<int, string> SecondToText => _secondDigitToText;
        private static readonly string DOLLAR = "dollar";
        private static readonly string CENT = "cent";
        private static readonly string DOLLARS = DOLLAR + "s"; 
        private static readonly string CENTS = CENT + "s";

        public string toWordsInDollarsAndCents(decimal candidate)
        {
            string result = "";

            decimal roundedCandidate = Math.Round(candidate, 2, MidpointRounding.ToEven);

            int dollars = (int) roundedCandidate;
            int cents = (int) ((candidate - dollars) * 100);
            
            string dollarsAsText = dollarsToText(dollars);
            string centsAsText = centsToText(cents);

            result = String.Format("{0} and {1}", dollarsAsText, centsAsText);
            
            return result.ToUpper();
        }

        private string dollarsToText(int dollars) {
            if (dollars < 0) {
                throw new ArgumentException("dollars must be positive");
            }
            if (dollars == 1) {
                return String.Format("{0} {1}", positiveNumberToText(dollars), DOLLAR);
            } else {
                return String.Format("{0} {1}", positiveNumberToText(dollars), DOLLARS);
            } 
        }

        private string centsToText(int cents) {
            if (cents < 0 || cents > 99) {
                throw new ArgumentException("cents must be 0 to 99");
            }
            if (cents == 1) {
                return String.Format("{0} {1}", positiveNumberToText(cents), CENT);
            } else {
                return String.Format("{0} {1}", positiveNumberToText(cents), CENTS);
            }
        }

        private string positiveNumberToText(int number) {
            string result = "";
            if (number < 0) {
                throw new ArgumentException("number must be positive");
            }
            //int numberOfDigits = number.ToString().Length; 
            if (number <= 19) {
                DigitToText.TryGetValue(number, out result);
                return result; 
            } else if (number > 19 && number < 100) {
                if (SecondToText.ContainsKey(number)) {
                    SecondToText.TryGetValue(number, out result);
                    return result;
                } else {
                    int[] numberParts = GetIntParts(number);
                    Console.WriteLine(numberParts[0]);
                    Console.WriteLine(numberParts[1]);
                    string firstPart = "";
                    SecondToText.TryGetValue(numberParts[1], out firstPart);
                    string secondPart = "";
                    DigitToText.TryGetValue(numberParts[0], out secondPart);
                    return String.Format("{0}-{1}", firstPart, secondPart);
                }
            } else {
                return result;
            }
        }
        private int [] GetIntParts(int num) {
            if (num < 10 || num > 99) {
                throw new ArgumentException("only 10 to 99 are valid");
            }
            int[] parts = new int[2];
            int remainder = num % 10;
            parts[0] = remainder;
            int quotient = num - remainder;
            parts[1] = quotient;
            return parts;
        }
    }
}
