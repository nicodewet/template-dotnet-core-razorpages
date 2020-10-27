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
       [InlineData("0", "ZERO DOLLARS AND ZERO CENTS")]
       [InlineData("0.00", "ZERO DOLLARS AND ZERO CENTS")]
       [InlineData("0.01", "ZERO DOLLARS AND ONE CENT")]
       [InlineData("0.02", "ZERO DOLLARS AND TWO CENTS")]
       [InlineData("0.03", "ZERO DOLLARS AND THREE CENTS")]
       [InlineData("0.04", "ZERO DOLLARS AND FOUR CENTS")]
       [InlineData("0.05", "ZERO DOLLARS AND FIVE CENTS")]
       [InlineData("0.06", "ZERO DOLLARS AND SIX CENTS")]
       [InlineData("0.07", "ZERO DOLLARS AND SEVEN CENTS")]
       [InlineData("0.08", "ZERO DOLLARS AND EIGHT CENTS")]
       [InlineData("0.09", "ZERO DOLLARS AND NINE CENTS")]
       [InlineData("1.00", "ONE DOLLAR AND ZERO CENTS")]
       [InlineData("1.01", "ONE DOLLAR AND ONE CENT")]
       [InlineData("1.02", "ONE DOLLAR AND TWO CENTS")]
       [InlineData("1.03", "ONE DOLLAR AND THREE CENTS")]
       [InlineData("1.04", "ONE DOLLAR AND FOUR CENTS")]
       [InlineData("1.05", "ONE DOLLAR AND FIVE CENTS")]
       [InlineData("1.06", "ONE DOLLAR AND SIX CENTS")]
       [InlineData("1.07", "ONE DOLLAR AND SEVEN CENTS")]
       [InlineData("1.08", "ONE DOLLAR AND EIGHT CENTS")]
       [InlineData("1.09", "ONE DOLLAR AND NINE CENTS")]
       [InlineData("2.00", "TWO DOLLARS AND ZERO CENTS")]
       [InlineData("2.01", "TWO DOLLARS AND ONE CENT")]
       [InlineData("2.02", "TWO DOLLARS AND TWO CENTS")]
       [InlineData("2.03", "TWO DOLLARS AND THREE CENTS")]
       [InlineData("2.04", "TWO DOLLARS AND FOUR CENTS")]
       [InlineData("2.05", "TWO DOLLARS AND FIVE CENTS")]
       [InlineData("2.06", "TWO DOLLARS AND SIX CENTS")]
       [InlineData("2.07", "TWO DOLLARS AND SEVEN CENTS")]
       [InlineData("2.08", "TWO DOLLARS AND EIGHT CENTS")]
       [InlineData("2.09", "TWO DOLLARS AND NINE CENTS")]
       public void ToWords(string value, string expected)
       {
           decimal number = Convert.ToDecimal(value);

           var result = _currencyWordsService.toWordsInDollarsAndCents(number);

           Assert.Equal(expected, result);
       }
    }
}
