using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TransFast.LanguageService;

namespace TransFast.TranslationService
{
    public class TranslationService : ITranslationService
    {
        private readonly string _translationsPath;
        private readonly ILanguageService _languageService;

        public TranslationService(string translationsPath, ILanguageService languageService)
        {
            _translationsPath = translationsPath;
            _languageService = languageService;

            // Ensure the directory for translations exists
            if (!Directory.Exists(_translationsPath))
            {
                Directory.CreateDirectory(_translationsPath);
            }
        }

        public string Translate(string key)
        {
            string culture = _languageService.CurrentLanguage;
            string filePath = Path.Combine(_translationsPath, $"{culture}.json");

            if (!File.Exists(filePath))
            {
                // The translation file doesn't exist; you can create it with some default content
                CreateDefaultTranslationFile(filePath);
            }

            // Read the JSON content from the file
            var jsonContent = File.ReadAllText(filePath);

            // Deserialize the JSON content to a Dictionary<string, string>
            var translationData = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);

            // Retrieve the translation for the specified key
            if (translationData.TryGetValue(key, out string translatedValue))
            {
                return translatedValue;
            }
            else
            {
                // Key not found; return a placeholder or the original key
                return $"TRANSLATION_MISSING: {key}";
            }
        }

        private void CreateDefaultTranslationFile(string filePath)
        {
            // Create a default translation JSON file with some initial content
            var defaultContent = new Dictionary<string, string>
        {
            { "greeting", "Hello, World!" },
            // Add more translations as needed
        };

            // Serialize and write the default content to the file
            File.WriteAllText(filePath, System.Text.Json.JsonSerializer.Serialize(defaultContent));
        }
    }
}
