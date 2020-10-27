using System;
using Xunit;

namespace Currency.Services.Tests
{
    public class CurrencyServiceTest
    {
        private readonly CurrencyWordsService _currencyWordsService;

        public CurrencyServiceTest() {
            _currencyWordsService = new CurrencyWordsService();
        }

       [Theory]
       [InlineData("0", "ZERO DOLLARS")]
       public void ToWords(string value, string expected)
       {
           decimal number = Convert.ToDecimal(value);

           var result = _currencyWordsService.toWordsInDollarsAndCents(number);

           Assert.Equal(expected, result);
       }
    }
}
