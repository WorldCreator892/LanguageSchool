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
        /// Выбранный уровень обучения (0 - базовый, 1 - средний, 2 - высокий, 3 - продвинутый)
        /// </summary>
        private int _level = 0;
        /// <summary>
        /// Выбранная интенсивность обучения (0 - продолжительность 3 месяца, занятия раз в неделю, 1 - продолжительность 2 месяца, занятия 3 раза в неделю, 2 - продолжительность 2 недели, занятия 5 раз в неделю)
        /// </summary>
        private int _intensity = 0;
        /// <summary>
        /// Количество обучающихся в группе
        /// </summary>
        private int _amount = 0;
        /// <summary>
        /// Список обучающихся
        /// </summary>
        private List<int> _studentIDs = new List<int>();
        /// <summary>
        /// Уникальный идентификатор группы
        /// </summary>
        private int _groupID = -1;
        /// <summary>
        /// Флаг указывающий на индивидуальное обучение
        /// </summary>
        private bool _individualFlag = true;
        /// <summary>
        /// Оставшаяся продолжительность занятий
        /// </summary>
        private int _remaining_lessons = 0;



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
        /// Флаг, указывающий на индивидуальное обучение
        /// </summary>
        public bool Individual
        {
            get { return _individualFlag; }
            set { _individualFlag = value; }
        }
        /// <summary>
        /// Уникальный идентификатор группы
        /// </summary>
        public int ID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }
        /// <summary>
        /// Выбранный уровень обучения (0 - базовый, 1 - средний, 2 - высокий, 3 - продвинутый)
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { if (value >= _level & value >= 0 & value < 3) { _level = value; } }
        }
        /// <summary>
        /// Выбранная интенсивность обучения (0 - продолжительность 3 месяца, занятия раз в неделю, 1 - продолжительность 2 месяца, занятия 3 раза в неделю, 2 - продолжительность 2 недели, занятия 5 раз в неделю)
        /// </summary>
        public int Intensity
        {
            get { return _intensity; }
            set {
                if (value >= 0 & value < 3) 
                { 
                    _intensity = value; 
                    if(value == 0)
                    {
                        _remaining_lessons = 6;
                    } else
                    {
                        if(value == 1)
                        {
                            _remaining_lessons = 4;
                        } else
                        {
                            if(value == 2)
                            {
                                _remaining_lessons = 1;
                            }
                        }
                    }
                        } 
            }
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
        public List<int> StudentIDs
        {
            get { return _studentIDs; }
            set
            {                
                if (value != null)
                {
                    _studentIDs = value;
                }
            }
        }
        /// <summary>
        /// Оставшаяся продолжительность занятий
        /// </summary>
        public int RemainingLessons
        {
            get { return _remaining_lessons; }
            set { _remaining_lessons = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Добавление обучающегося в группу по заявке
        /// </summary>
        public void AddStudent(CourseApplication AcceptedApplication)
        {
            int StudentID = AcceptedApplication.ApplicationID / 100;
            StudentIDs.Add(StudentID);
            _amount++;
        }

        /// <summary>
        /// Добавление обучающегося в группу по ID
        /// </summary>
        public void AddStudentByID(int AcceptedStudentID)
        {
            StudentIDs.Add(AcceptedStudentID);
            _amount++;
        }

        /// <summary>
        /// Проверка наличия студента с данным ID в группе
        /// </summary>
        public bool CheckStudentExistence(int CheckedStudentID)
        {
            bool ans = false;
            if(this.StudentIDs.Contains(CheckedStudentID))
            {
                ans = true;
            }
            return ans;
        }
        /// <summary>
        /// Исключение студента с данным ID из группы
        /// </summary>
        public void ExcludeStudent(int ExcludedStudentID)
        {
            this.StudentIDs.Remove(ExcludedStudentID);            
            this._amount -= 1;
        }
        /// <summary>
        /// Перевод студента в другую группу
        /// </summary>
        public bool TransferStudent(Group DestinationGroup, int TransferredStudentID)
        {
            bool successTransfer = false;
            if(!DestinationGroup.CheckStudentExistence(TransferredStudentID))
            {
                DestinationGroup.AddStudentByID(TransferredStudentID);
                this.ExcludeStudent(TransferredStudentID);
            }
            return successTransfer;
        }
        /// <summary>
        /// Проверка заявки на то, подходит ли она группе
        /// </summary>
        public bool CheckIfApplicationFits(CourseApplication CheckApplication)
        {
            bool check = true;
            if(CheckApplication.Level != this.Level)
            {
                check = false;
                return check;
            }
            if(CheckApplication.Intensity != this.Intensity)
            {
                check = false;
                return check;
            }
            if(this.Amount == 10)
            {
                check = false;
                return check;
            }
            foreach(int ID in this.StudentIDs)
            {
                if(CheckApplication.ApplicationID / 100 == ID)
                {
                    check = false;
                    return check;
                }
            }
            return check;
        }
        /// <summary>
        /// Проверка групп на схожесть
        /// </summary>
        public bool CheckIfGroupsAreSimilar(Group b)
        {
            bool check = true;
            if(b.Level != this.Level)
            {
                check = false;
                return check;
            }
            if(b.Intensity != this.Intensity)
            {
                check = false;
                return check;
            }
            return check;
        }

        #endregion
    }
}
