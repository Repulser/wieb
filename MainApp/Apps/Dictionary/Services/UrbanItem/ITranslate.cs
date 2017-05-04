namespace Dictionary.Services
{
    internal interface ITranslate<T>
    {
        string Translate(string word, T lang);
        T Detect(string word);
    }
}