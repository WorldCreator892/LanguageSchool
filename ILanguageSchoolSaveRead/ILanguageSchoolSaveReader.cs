using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchoolClassLibrary;

namespace ILanguageSchoolSaveRead
{
    public interface ILanguageSchoolSaveReader
    {
        void WriteLanguageSchoolToExcel(LanguageSchool languageSchool, string saveAs);
        LanguageSchool Read(string readFrom);
    }
}
