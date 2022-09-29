using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolManagement
{
    /// <summary>
    /// Класс для создания и работы с группами обучающихся (для групповых занятий)
    /// </summary>
    class Group
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
            set { if(value >= _level & value >=0 & value < 3) { _level = value; } }
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
            set { if (value >= 5 & value <= 10) { _intensity = value; } }
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
                foreach(string str in value)
                {
                    if(string.IsNullOrEmpty(str))
                    {
                        NoEmptyOrNull = false;
                        break;
                    }
                }
                if(NoEmptyOrNull)
                {
                    _studentNames = value;
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Добавление обучающегося в группу
        /// </summary>
        public void AddStudent(Application AcceptedApplication)
        {
            StudentNames.Add(AcceptedApplication.Surname);
            _amount++;
        }
        #endregion
    }
}
