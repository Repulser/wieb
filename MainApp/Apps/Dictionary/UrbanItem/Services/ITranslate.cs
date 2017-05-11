using OpenQA.Selenium.Remote;

namespace Dictionary.Services
{
    internal interface ITranslate<T>
    {
        string Translate(string word, T lang, RemoteWebDriver driver);
        T Detect(string word, RemoteWebDriver driver);
    }
}