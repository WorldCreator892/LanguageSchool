using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolClassLibrary
{
    /// <summary>
    /// Класс для создания и работы с заявкой обучающегося
    /// </summary>
    public class CourseApplication
    {
        /// <summary>
        /// Фамилия обучающегося
        /// </summary>
        private string _surname = "Not stated";
        /// <summary>
        /// Выбранный обучающимся язык
        /// </summary>
        private string _language = "Not stated";
        /// <summary>
        /// Выбранная интенсивность обучения
        /// </summary>
        private int _intensity = 0;
        /// <summary>
        /// Выбранный уровень обучения
        /// </summary>
        private int _level = 0;
        /// <summary>
        /// Статус заявки (0 - не принята, 1 - индивидуальное обучение, 2 - групповое)
        /// </summary>
        private int _status = 0;
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        private int _groupID = -1;
        /// <summary>
        /// Количество внесенной за обучение предоплаты
        /// </summary>
        private int _payedAmount = 0;

        #region Constructors
        /// <summary>
        /// Стандартный конструктор для создания экземпляра заявки на обучение
        /// </summary>
        public CourseApplication(string AppliedSurname, string AppliedLanguage, int AppliedIntensity, int AppliedLevel, int AppliedPayment = 0)
        {
            Surname = AppliedSurname;
            Language = AppliedLanguage;
            Intensity = AppliedIntensity;
            Level = AppliedLevel;
            PayedAmount = AppliedPayment;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Фамилия обучающегося
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set { if (!string.IsNullOrEmpty(value)) { _surname = value; } }
        }
        /// <summary>
        /// Выбранный обучающимся язык
        /// </summary>
        public string Language
        {
            get { return _language; }
            set { if (!string.IsNullOrEmpty(value)) { _language = value; } }
        }
        /// <summary>
        /// Выбранная интенсивность обучения
        /// </summary>
        public int Intensity
        {
            get { return _intensity; }
            set { if (value >= 0 & value < 3) { _intensity = value; } }
        }
        /// <summary>
        /// Выбранный уровень обучения
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { if (value >= 0 & value < 3) { _level = value; } }
        }
        /// <summary>
        /// Количество внесенной за обучение предоплаты
        /// </summary>
        public int PayedAmount
        {
            get { return _payedAmount; }
            set { if (value >= 0) { _payedAmount = value; } else { _payedAmount = 0; } }
        }
        #endregion

        #region Methods
        

        public bool CompareApplicationPriorities(CourseApplication b)
        {
            bool res = true;
            if(this.PayedAmount == 0)
            {
                res = false;
            } else
            {

            }
            return res;
        }
        #endregion
    }
}
