using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Класс для создания и работы с курсом по заданному языку
    /// </summary>
    public class Course
    {        
        /// <summary>
        /// Список всех доступных для изучения языков
        /// </summary>
        private static string[] _languageList = { "English", "French", "German", "Chinese" };
        /// <summary>
        /// Изучаемый на курсе язык
        /// </summary>
        private string _language = "Not stated";
        /// <summary>
        /// Количество студентов, обучающихся на курсе
        /// </summary>
        private int _studentAmount = 0;
        /// <summary>
        /// Список составленных в рамках курса групп
        /// </summary>
        private List<Group> _groups = new List<Group>();
        /// <summary>
        /// Стандартная стоимость курса
        /// </summary>
        private int _standartPayment = 0;
        /// <summary>
        /// Коэффициент повышения цены курса при выборе индивидуального обучения
        /// </summary>
        private int _individualCoefficient = 1;

        #region Constructors

        #endregion

        #region Properties

        /// <summary>
        /// Изучаемый на курсе язык
        /// </summary>
        public string Language
        {
            get { return _language; }
            set { if(string.IsNullOrEmpty(value)) { _language = value; } }
        }

        /// <summary>
        /// Количество студентов, обучающихся на курсе
        /// </summary>
        public int StudentAmount
        {
            get { return _studentAmount; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Проверяет на существование 
        /// </summary>
        public bool CheckLanguageExist(string CheckedLanguageName)
        {
            bool ans = false;
            if(_languageList.Contains(CheckedLanguageName))
            {
                ans = true;
            }
            return ans;
        }

        /// <summary>
        /// Добавление нового языка в список существующих
        /// </summary>
        public void AddNewLanguage(string AddedLanguageName)
        {
            if(!this.CheckLanguageExist(AddedLanguageName) & (!string.IsNullOrEmpty(AddedLanguageName)))
            {
                _languageList.Append(AddedLanguageName);
            }
        }
        #endregion
    }
}
