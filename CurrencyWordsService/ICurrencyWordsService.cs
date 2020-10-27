namespace Currency.Services {

    public interface ICurrencyWordsService
    {
        string toWordsInDollarsAndCents(decimal candidate);
    }

}