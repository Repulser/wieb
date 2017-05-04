using System;
using System.Collections.ObjectModel;
using System.Linq;
using Dictionary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DictionaryTests
{
    [TestClass]
    public class SeleniumTranslateTest
    {
        [TestMethod]
        public void TestTranslate()
        {
            var translate = new SeleniumTranslate();
            //var languages = 
            var langsLeft = translate.Languages.ToList();
            foreach (var lang in langsLeft)
            {
                var first = langsLeft.First();
                var translated = translate.Translate("Hello", first);
                if (translated != "NoSuchElementException")
                {
                    
                }
                langsLeft.Remove(first);
            }
            
        }
    }
}
