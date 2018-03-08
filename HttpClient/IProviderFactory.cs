namespace GlobalProvider.HttpClient
{
    public interface IProviderFactory<out TProvider>
    {
        TProvider Create();
    }
}