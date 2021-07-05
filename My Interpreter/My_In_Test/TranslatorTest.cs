using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator;
using static Translator.LanguageList;
using MadMilkman.Ini;
using System.Collections.Generic;

namespace My_In_Test
{
    [TestClass]
    public class TranslatorTest
    {
        RapidSystran sys;
        Yandex yandex;

        [TestInitialize]
        public void TestInit()
        {
            string path = Environment.CurrentDirectory + "\\..\\..\\..\\key.ini";
            var file = new IniFile();
            file.Load(path);
            yandex = new Yandex(file.Sections["Yandex"].Keys["key"].Value);
            var rapid = file.Sections["Rapid"].Keys;
            sys = new RapidSystran(rapid["host"].Value, rapid["key"].Value);
        }


        [TestMethod]
        public void TestAllSupportLanguages()
        {
            //There should be 93 languages
            var actual = GetLanguageList();
            Assert.AreEqual(actual.Count, 93);
        }

        [TestMethod]
        public void TestListLanguageNames()
        {
            var actual = GetLanguageNameList();
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestLanguageName()
        {
            var actual = GetLanguageName("ja");
            Assert.AreEqual("Japanese", actual);
        }

        [TestMethod]
        public void TestCodeList()
        {
            var actual = GetLanguageCodeList();
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestCode()
        {
            var actual = GetLanguageCode("Swedish");
            Assert.AreEqual("sv", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestFailCode()
        {
            GetLanguageCode("Simlish"); //A fictional language from the sims
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFailCode_Empty()
        {
            GetLanguageCode("");
        }

        [TestMethod]
        public async Task TestTranslate()
        {
            string actual = await yandex.Translate("你好！", "en");
            Assert.AreEqual("Hello!", actual);
        }

        [TestMethod]
        public async Task TestTranslateWithKey()
        {
            string actual = await Yandex.Translate(yandex.key, "你好！", "en");
            Assert.AreEqual("Hello!", actual);
        }

        [TestMethod]
        public void TestDetectLanguage()
        {
            var actual = sys.IdentifyLanguage("こんにちは");
            var expected = new List<string>() { "ja" };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDetectLanguage_with_random()
        {
            //Check to see what happens if I added another language
            var actual = sys.IdentifyLanguage("hej. I am good");
            var expected = new List<string>() { "da" };
            CollectionAssert.AreNotEqual(expected, actual);
        }
    }
}

