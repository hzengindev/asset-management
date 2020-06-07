using Core.Utilities.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Localizations
{
    public static class Localization
    {
        private static Dictionary<LanguageCode, Dictionary<TextCode, string>> TextDefinitions = new Dictionary<LanguageCode, Dictionary<TextCode, string>>();

        public static void Load()
        {
            var files = Directory.GetFiles($"{AppDomain.CurrentDomain.BaseDirectory}/Utilities/Localizations/");
            foreach (var fileDir in files)
            {
                var definition = JsonConvert.DeserializeObject<Dictionary<TextCode, string>>(File.ReadAllText(fileDir));
                LanguageCode langCode;
                Enum.TryParse(Path.GetFileNameWithoutExtension(fileDir), out langCode);
                TextDefinitions.Add(langCode, definition);
            }
        }

        public static string GetText(this TextCode textCode)
        {
            var defaultLang = LanguageCode.Turkish;
            LanguageCode languageCode = (LanguageCode)System.Threading.Thread.CurrentThread.CurrentCulture.LCID;
            if (!TextDefinitions.ContainsKey(languageCode))
                languageCode = defaultLang;

            var text = TextDefinitions[languageCode];
            if (text.ContainsKey(textCode))
                return text[textCode];

            return "Undocument code!";
        }

        public static string GetText(this TextCode textCode, LanguageCode languageCode)
        {
            var defaultLang = LanguageCode.Turkish;
            if (!TextDefinitions.ContainsKey(languageCode))
                languageCode = defaultLang;

            var text = TextDefinitions[languageCode];
            if (text.ContainsKey(textCode))
                return text[textCode];

            return "Undocument code!";
        }
    }
}
