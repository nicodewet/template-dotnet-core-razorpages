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
        };
        public static IReadOnlyDictionary<int, string> DigitToText => _digitToText;
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
            } else if (dollars >= 0 && dollars <= 9) {
                return String.Format("{0} {1}", positiveNumberToText(dollars), DOLLARS);
            } else {
                return "";
            }
        }

        private string centsToText(int cents) {
            if (cents < 0 || cents > 99) {
                throw new ArgumentException("cents must be 0 to 99");
            }
            if (cents == 1) {
                return String.Format("{0} {1}", positiveNumberToText(cents), CENT);
            } else if (cents >= 0 && cents <= 9) {
                return String.Format("{0} {1}", positiveNumberToText(cents), CENTS);
            } else {
                return "";
            }
        }

        private string positiveNumberToText(int number) {
            string result = "";
            if (number < 0) {
                throw new ArgumentException("number must be positive");
            }
            int numberOfDigits = number.ToString().Length; 
            if (numberOfDigits == 1) {
                DigitToText.TryGetValue(number, out result);
                return result; 
            } else {
                return result;
            }
        }
    }
}
