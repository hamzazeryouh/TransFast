using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFast
{
    public class LanguageService:ILanguageService
    {
        private string _currentLanguage = "en-US"; // Default to English

        public string CurrentLanguage
        {
            get => _currentLanguage;
        }

        public void SetLanguage(string language)
        {
            // You can add validation here to ensure the language is supported.
            _currentLanguage = language;
        }
    }
}
