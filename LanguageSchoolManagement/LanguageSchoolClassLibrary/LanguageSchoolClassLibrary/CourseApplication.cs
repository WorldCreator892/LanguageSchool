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
    public class CourseApplication : IComparable<CourseApplication>
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
        /// Выбранная интенсивность обучения (0 - продолжительность 3 месяца, занятия раз в неделю, 1 - продолжительность 2 месяца, занятия 3 раза в неделю, 2 - продолжительность 2 недели, занятия 5 раз в неделю)
        /// </summary>
        private int _intensity = 0;
        /// <summary>
        /// Выбранный уровень обучения (0 - базовый, 1 - средний, 2 - высокий, 3 - продвинутый)
        /// </summary>
        private int _level = 0;
        /// <summary>
        /// Статус заявки (0 - на рассмотрении, 1 - ожидает распределения, 2 - индивидуальное обучение, 3 - групповое)
        /// </summary>
        private int _status = 0;
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        private int _applicationID = -1;
        /// <summary>
        /// Количество внесенной за обучение предоплаты
        /// </summary>
        private int _payedAmount = 0;
        /// <summary>
        /// Время, которое заявка уже находится на рассмотрении
        /// </summary>
        private int _waitingTime = 0;
        /// <summary>
        /// Идентификатор приписанной группы
        /// </summary>
        private int _groupID = -1;

        #region Constructors
        /// <summary>
        /// Пустой конструктор для создания экземпляра заявки на обучение
        /// </summary>
        public CourseApplication()
        {
        }
        /// <summary>
        /// Стандартный конструктор для создания экземпляра заявки на обучение
        /// </summary>
        public CourseApplication(string AppliedSurname, string AppliedLanguage, int AppliedIntensity, int AppliedLevel, int AppliedID, int AppliedPayment = 0)
        {
            Surname = AppliedSurname;
            Language = AppliedLanguage;
            Intensity = AppliedIntensity;
            Level = AppliedLevel;
            PayedAmount = AppliedPayment;
            ApplicationID = AppliedID;
        }
        /// <summary>
        /// Конструктор для создания копии экземпляра заявки на обучение
        /// </summary>
        public CourseApplication(CourseApplication CopiedApplication)
        {
            Surname = CopiedApplication.Surname;
            Language = CopiedApplication.Language;
            Intensity = CopiedApplication.Intensity;
            Level = CopiedApplication.Level;
            Status = CopiedApplication.Status;
            PayedAmount = CopiedApplication.PayedAmount;
            ApplicationID = CopiedApplication.ApplicationID;
            WaitingTime = CopiedApplication.WaitingTime;
            GroupID = CopiedApplication.GroupID;
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
        /// Выбранная интенсивность обучения (0 - продолжительность 3 месяца, занятия раз в неделю, 1 - продолжительность 2 месяца, занятия 3 раза в неделю, 2 - продолжительность 2 недели, занятия 5 раз в неделю)
        /// </summary>
        public int Intensity
        {
            get { return _intensity; }
            set { if (value >= 0 & value < 3) { _intensity = value; } }
        }
        /// <summary>
        /// Выбранный уровень обучения (0 - базовый, 1 - средний, 2 - высокий, 3 - продвинутый)
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
        /// <summary>
        /// Статус заявки (0 - на рассмотрении, 1 - ожидает распределения, 2 - индивидуальное обучение, 3 - групповое)
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { if (value < 4 & value > -1) { _status = value; } }
        }
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        public int ApplicationID
        {
            get { return _applicationID; }
            set { if (value >=0) { _applicationID = value; } }
        }
        /// <summary>
        /// Время, которое зыявка уже находится на рассмотрении
        /// </summary>
        public int WaitingTime
        {
            get { return _waitingTime; }
            set { if (value >= 0) { _waitingTime = value; } }
        }
        /// <summary>
        /// Идентификатор приписанной группы
        /// </summary>
        public int GroupID
        {
            get { return _groupID; }
            set { if (value >= 0) { _groupID = value; } }
        }
        #endregion

        #region Methods     



        public int CompareTo(CourseApplication other)
        {
            int res = 0;

            if(other.Status * other.WaitingTime > this.Status * this.WaitingTime)
            {
                res = 1;
            } else
            {
                if(other.Status * other.WaitingTime < this.Status * this.WaitingTime)
                {
                    res = -1;
                } else
                {
                    if (other.Status > this.Status)
                    {
                        res = 1;
                    }
                    else
                    {
                        if (other.Status < this.Status)
                        {
                            res = -1;
                        }
                        else
                        {
                            if (other._waitingTime > this._waitingTime)
                            {
                                res = 1;
                            }
                            else
                            {
                                if (other._waitingTime < this._waitingTime)
                                {
                                    res = -1;
                                }
                            }
                        }
                    }
                }
            }
            
            
            return res;
        }


        #endregion
    }

    public class CourseApplicationBasicComparer : IComparer<CourseApplication>
    {
        public int Compare(CourseApplication x, CourseApplication y)
        {
            return x.CompareTo(y);
        }
    }
}
