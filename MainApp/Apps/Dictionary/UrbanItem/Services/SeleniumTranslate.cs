using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace Dictionary.Services
{
    public class SeleniumTranslate : ITranslate<SeleniumTranslate.Languages>
    {
        public enum Languages
        {
            [Description("Afrikaans")] Afrikaans,
            [Description("Albanian")] Albanian,
            [Description("Amharic")] Amharic,
            [Description("Arabic")] Arabic,
            [Description("Armenian")] Armenian,
            [Description("Azerbaijani")] Azerbaijani,
            [Description("Basque")] Basque,
            [Description("Belarusian")] Belarusian,
            [Description("Bengali")] Bengali,
            [Description("Bosnian")] Bosnian,
            [Description("Bulgarian")] Bulgarian,
            [Description("Catalan")] Catalan,
            [Description("Cebuano")] Cebuano,
            [Description("Chichewa")] Chichewa,
            [Description("Chinese (Simplified)")] ChineseSimplified,
            [Description("Chinese (Traditional)")] ChineseTraditional,
            [Description("Corsican")] Corsican,
            [Description("Croatian")] Croatian,
            [Description("Czech")] Czech,
            [Description("Danish")] Danish,
            [Description("Dutch")] Dutch,
            [Description("English")] English,
            [Description("Esperan")] Esperato,
            [Description("Estonia")] Estonan,
            [Description("Filipino")] Filipino,
            [Description("Finnish")] Finnish,
            [Description("French")] French,
            [Description("Frisian")] Frisian,
            [Description("Galician")] Galician,
            [Description("Georgian")] Georgian,
            [Description("German")] German,
            [Description("Greek")] Greek,
            [Description("Gujarati")] Gujarati,
            [Description("Haitian Creole")] HaitianCreole,
            [Description("Hausa")] Hausa,
            [Description("Hawaiian")] Hawaiian,
            [Description("Hebrew")] Hebrew,
            [Description("Hindi")] Hindi,
            [Description("Hmong")] Hmong,
            [Description("Hungarian")] Hungarian,
            [Description("Icelandic")] Icelandic,
            [Description("Igbo")] Igbo,
            [Description("Indonesian")] Indonesian,
            [Description("Irish")] Irish,
            [Description("Italian")] Italian,
            [Description("Japanese")] Japanese,
            [Description("Javanese")] Javanese,
            [Description("Kannada")] Kannada,
            [Description("Kazakh")] Kazakh,
            [Description("Khmer")] Khmer,
            [Description("Korean")] Korean,
            [Description("Kurdish (Kurmanji)")] KurdishKurmanji,
            [Description("Kyrgyz")] Kyrgyz,
            [Description("Lao")] Lao,
            [Description("Latin")] Latin,
            [Description("Latvian")] Latvian,
            [Description("Lithuanian")] Lithuanian,
            [Description("Luxembourgish")] Luxembourgish,
            [Description("Macedonian")] Macedonian,
            [Description("Malagasy")] Malagasy,
            [Description("Malay")] Malay,
            [Description("Malayalam")] Malayalam,
            [Description("Maltese")] Maltese,
            [Description("Maori")] Maori,
            [Description("Marathi")] Marathi,
            [Description("Mongolian")] Mongolian,
            [Description("Mynamar (Burmese)")] MynamarBurmese,
            [Description("Nepali")] Nepali,
            [Description("Norwegian")] Norwegian,
            [Description("Pashto")] Pashto,
            [Description("Persian")] Persian,
            [Description("Polish")] Polish,
            [Description("Portuguese")] Portuguese,
            [Description("Punjabi")] Punjabi,
            [Description("Romanian")] Romanian,
            [Description("Russian")] Russian,
            [Description("Samoan")] Samoan,
            [Description("Scots Gaelic")] ScotsGaelic,
            [Description("Serbian")] Serbian,
            [Description("Sesotho")] Sesotho,
            [Description("Shona")] Shona,
            [Description("Sindhi")] Sindhi,
            [Description("Sinhala")] Sinhala,
            [Description("Slovak")] Slovak,
            [Description("Slovenian")] Slovenian,
            [Description("Somali")] Somali,
            [Description("Spanish")] Spanish,
            [Description("Sundanese")] Sundanese,
            [Description("Swahili")] Swahili,
            [Description("Swedish")] Swedish,
            [Description("Tajik")] Tajik,
            [Description("Tamil")] Tamil,
            [Description("Telugu")] Telugu,
            [Description("Thai")] Thai,
            [Description("Turkish")] Turkish,
            [Description("Ukrainian")] Ukrainian,
            [Description("Urdu")] Urdu,
            [Description("Uzbek")] Uzbek,
            [Description("Vietnamese")] Vietnamese,
            [Description("Welsh")] Welsh,
            [Description("Xhosa")] Xhosa,
            [Description("Yiddish")] Yiddish,
            [Description("Yoruba")] Yoruba,
            [Description("Zulu")] Zulu
        }

        private static RemoteWebDriver _driver;

        public string Translate(string word, Languages langs)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TypeInTextBox(word);
            SelectLanguages(langs);

            _driver.FindElementByCssSelector("#gt-submit").Click(); //Click translate button

            string result = _driver.FindElementByCssSelector("#result_box").Text;
            _driver.Quit();
            return result;
        }

        public Languages Detect(string word)
        {
            IWebElement detect = _driver.FindElementByCssSelector
            (
                "#gt-sl-sugg > div.goog-inline-block.jfk-button.jfk-button-standard.jfk-button-collapse-left.jfk-button-collapse-right.jfk-button-checked");
            detect.Click(); //Click DetectLanguage
            TypeInTextBox(word);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            string lang = detect.Text?.Replace(" - detected", "");
            Enum @enum = GetEnum(lang, typeof(Languages));
            _driver.Quit();
            return (Languages)@enum;
        }

        public static void Factory(string path)
        {
            Task.Run(() => { _driver = DriverFactory(_driver, path); });
        }

        private static RemoteWebDriver DriverFactory(RemoteWebDriver driver, string path)
        {
            DriverService driverService = ServiceFactory(driver, path);
            driverService.HideCommandPromptWindow = true;
            return new ChromeDriver((ChromeDriverService)driverService, new ChromeOptions())
            {
                Url = "https://translate.google.com/"
            };
        }

        private static DriverService ServiceFactory(RemoteWebDriver driver, string path)
        {
            if (driver is ChromeDriver)
            {
                return ChromeDriverService.CreateDefaultService(path);
            }

            if (driver is FirefoxDriver)
            {
                return FirefoxDriverService.CreateDefaultService(path);
            }

            if (driver is EdgeDriver)
            {
                return EdgeDriverService.CreateDefaultService(path);
            }

            if (driver is InternetExplorerDriver)
            {
                return InternetExplorerDriverService.CreateDefaultService(path);
            }

            return PhantomJSDriverService.CreateDefaultService(path);
        }

        private static string GetString(Enum @enum)
        {
            FieldInfo fi = @enum.GetType().GetField(@enum.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0
                ? attributes[0].Description
                : @enum.ToString();
        }

        private static Enum GetEnum(string value, Type @enum)
        {
            string[] names = Enum.GetNames(@enum);
            foreach (string name in names)
            {
                var enumValue = (Enum)Enum.Parse(@enum, name);
                if (GetString(enumValue) == value)
                {
                    return enumValue;
                }
            }

            throw new ArgumentException("The string does not exist in the enum.");
        }

        private void TypeInTextBox(string word)
        {
            IWebElement textBox = _driver.FindElementByCssSelector("#source");
            textBox.SendKeys(word);
        }

        private void SelectLanguages(Languages langs)
        {
            _driver.FindElementByCssSelector("#gt-tl-gms").Click(); //Click the moreButton
            try
            {
                string lang = GetString(langs);
                _driver.FindElementByXPath($"//*[contains(text(), '{lang}')]").Click(); //Click language
            }
            catch (NoSuchElementException)
            {
                _driver.Quit();
            }
        }
    }
}