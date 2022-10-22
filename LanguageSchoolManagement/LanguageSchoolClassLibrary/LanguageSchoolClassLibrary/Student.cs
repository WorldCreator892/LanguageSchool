using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolClassLibrary
{
    /// <summary>
    /// Класс для создания и работы с данными обучающегося
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Фамилия обучающегося
        /// </summary>
        private string _surname = "Not Stated";
        /// <summary>
        /// Список поданных заявок
        /// </summary>
        private List<CourseApplication> _applications = new List<CourseApplication>();
        /// <summary>
        /// Расписание студента, заполняемое идентификаторами групп, в которых он обучается
        /// </summary>
        private int[] _schedule = new int[7] { 0, 0, 0, 0, 0, 0, 0};

        #region Constructors
        /// <summary>
        /// Стандартный конструктор класса, создает экзепляр обучающегося по его фамилии
        /// </summary>
        public Student(string StudentName)
        {
            _surname = StudentName;
        }
        /// <summary>
        /// Конструктор для создания экземпляра класса со значениями полей по умолчанию
        /// </summary>
        public Student()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Фамилия обучающегося
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (!string.IsNullOrEmpty(value)) { _surname = value; foreach (CourseApplication app in _applications)
                    {
                        app.Surname = value;
                    }
                };
                
            }
        }

        /// <summary>
        /// Расписание студента, заполняемое идентификаторами групп, в которых он обучается
        /// </summary>
        public int[] Schedule
        {
            get { return _schedule; }
            set { if (value != null) { _schedule = value; } }
        }
        /// <summary>
        /// Список поданных заявок
        /// </summary>
        public List<CourseApplication> Applications
        {
            get { return _applications; }
            set { _applications = value; }
        }
        #endregion

        #region Methods

        #endregion

    }
}
