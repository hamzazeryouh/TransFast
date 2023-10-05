using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFast.LanguageService
{
    public interface ILanguageService
    {
        string CurrentLanguage { get; }
        void SetLanguage(string language);
    }
}
