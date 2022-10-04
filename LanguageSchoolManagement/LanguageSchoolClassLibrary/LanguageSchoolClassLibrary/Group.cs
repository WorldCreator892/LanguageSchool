using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolClassLibrary
{
    /// <summary>
    /// Класс для создания и работы с группами обучающихся (для групповых занятий)
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Выбранный язык обучения
        /// </summary>
        private string _language = "Not stated";
        /// <summary>
        /// Выбранный уровень обучения
        /// </summary>
        private int _level = 0;
        /// <summary>
        /// Выбранная интенсивность обучения
        /// </summary>
        private int _intensity = 0;
        /// <summary>
        /// Количество обучающихся в группе
        /// </summary>
        private int _amount = 0;
        /// <summary>
        /// Список обучающихся
        /// </summary>
        private List<string> _studentNames = new List<string>();
        /// <summary>
        /// Уникальный идентификатор группы
        /// </summary>
        private int _groupID = -1;
        /// <summary>
        /// Флаг указывающий на необходимость доукомплектования группы
        /// </summary>
        private bool _reformingFlag = true;

        #region Constructors
        /// <summary>
        /// Стандартный конструктор группы
        /// </summary>
        public Group(int GroupID, string GroupLanguage = "Not stated", int GroupLevel = 0, int GroupIntensity = 0)
        {
            _groupID = GroupID;
            _language = GroupLanguage;
            Level = GroupLevel;
            Intensity = GroupIntensity;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Выбранный язык обучения
        /// </summary>
        public string Language
        {
            get { return _language; }
            set { if (!string.IsNullOrEmpty(value)) { _language = value; } }
        }
        /// <summary>
        /// Выбранный уровень обучения
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { if (value >= _level & value >= 0 & value < 3) { _level = value; } }
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
        /// Количество обучающихся в группе
        /// </summary>
        public int Amount
        {
            get { return _amount; }            
        }
        /// <summary>
        /// Список обучающихся 
        /// </summary>
        public List<string> StudentNames
        {
            get { return _studentNames; }
            set
            {
                bool NoEmptyOrNull = true;
                foreach (string str in value)
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        NoEmptyOrNull = false;
                        break;
                    }
                }
                if (NoEmptyOrNull)
                {
                    _studentNames = value;
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Добавление обучающегося в группу по заявке
        /// </summary>
        public void AddStudent(CourseApplication AcceptedApplication)
        {
            StudentNames.Add(AcceptedApplication.Surname);
            _amount++;
        }

        /// <summary>
        /// Проверка наличия студента с данной фамилией в группе
        /// </summary>
        public bool CheckStudentExistence(string CheckedStudentName)
        {
            bool ans = false;
            if(this.StudentNames.Contains(CheckedStudentName))
            {
                ans = true;
            }
            return ans;
        }

        public void ExcludeStudent(string ExcludedStudentName)
        {
            this.StudentNames.Remove(ExcludedStudentName);
            this._amount -= 1;
        }
        #endregion
    }
}
