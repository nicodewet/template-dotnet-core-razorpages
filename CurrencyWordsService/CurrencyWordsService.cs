using System;
using System.Collections.Generic;

namespace Currency.Services
{
    public class CurrencyWordsService : ICurrencyWordsService
    {
        private static IReadOnlyDictionary<int, string> _intToText = new Dictionary<int, string> {
            {0, "zero"}
        };
        public static IReadOnlyDictionary<int, string> IntToText => _intToText;
        private static readonly string DOLLAR = "dollar";
        private static readonly string DOLLARS = DOLLAR + "s"; 

        public string toWordsInDollarsAndCents(decimal candidate)
        {
            string result = "";

            if (candidate == decimal.Zero)
            {
                IntToText.TryGetValue(0, out result);
                result = String.Format("{0} {1}", result, DOLLARS);

            } else {

                bool isInt = candidate % 1 == 0;

                if (isInt)
                {
                    throw new NotImplementedException("only supporting zero at present");
                }
                else
                {
                    throw new NotImplementedException("only supporting whole numbers at present");
                }

            }
            
            return result.ToUpper();

        }
    }
}
