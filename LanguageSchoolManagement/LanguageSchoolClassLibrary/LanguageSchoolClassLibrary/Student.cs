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
        /// Индивидуальный идентификатор студента
        /// </summary>
        private int _id = 0;
        /// <summary>
        /// Список поданных заявок
        /// </summary>
        private List<CourseApplication> _applications = new List<CourseApplication>();
        /// <summary>
        /// Расписание студента, заполняемое идентификаторами групп, в которых он обучается
        /// </summary>
        private List<KeyValuePair<string, int>>[] _schedule = new List<KeyValuePair<string, int>>[7];

        #region Constructors
        /// <summary>
        /// Стандартный конструктор класса, создает экзепляр обучающегося по его фамилии
        /// </summary>
        public Student(string StudentName, int StudentID)
        {
            _surname = StudentName;
            _id = StudentID;
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
        public List<KeyValuePair<string, int>>[] Schedule
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
        /// <summary>
        /// Личный идентификатор обучающегося
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Актуализирует расписание согласно данным о принятых заявках
        /// </summary>
        public void SetSchedule()
        {
            _schedule = new List<KeyValuePair<string, int>>[7];
            for(int i = 0; i<7; i++)
            {
                _schedule[i] = new List<KeyValuePair<string, int>>();
            }
            foreach (CourseApplication c in this.Applications)
            {
                if(c.GroupID != -1)
                {
                    if(c.Intensity == 2)
                    {
                        for(int i = 0; i < 5; i++)
                        {
                            _schedule[i].Add(new KeyValuePair<string, int>(c.Language, c.GroupID));
                        }                        
                    } else
                    {
                        if(c.Intensity == 1)
                        {
                            for (int i = 4; i < 7; i++)
                            {
                                _schedule[i].Add(new KeyValuePair<string, int>(c.Language, c.GroupID));
                            }
                        } else
                        {
                            _schedule[0].Add(new KeyValuePair<string, int>(c.Language, c.GroupID));
                        }
                    }
                }
            }
        }
        #endregion

    }
}
