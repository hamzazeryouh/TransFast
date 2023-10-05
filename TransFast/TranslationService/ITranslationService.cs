using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFast.TranslationService
{
    public interface ITranslationService
    {
        string Translate(string key);
    }
}
