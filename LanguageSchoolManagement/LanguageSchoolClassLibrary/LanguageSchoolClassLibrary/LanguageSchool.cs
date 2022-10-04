using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolClassLibrary
{
    public class LanguageSchool
    {
        /// <summary>
        /// Существующие в языковой школе курсы
        /// </summary>
        private List<Course> _courses = new List<Course>();
        /// <summary>
        /// Список всех доступных для изучения языков
        /// </summary>
        private static List<string> _languageList = new List<string>(){ "English", "French", "German", "Chinese" };
        /// <summary>
        /// Список всех обучающихся курса
        /// </summary>
        private List<Student> _students = new List<Student>();

        #region Constructors

        #endregion

        #region Properties
        /// <summary>
        /// Список всех обучающихся курса
        /// </summary>
        public List<Student> Students
        {
            get { return _students; }            
        }
        /// <summary>
        /// Список всех доступных для изучения языков
        /// </summary>
        public List<string> Languages
        {
            get { return _languageList; }            
        }

        #endregion

        #region Methods
        /// <summary>
        /// Проверяет на существование 
        /// </summary>
        public bool CheckLanguageExist(string CheckedLanguageName)
        {
            bool ans = false;
            if (_languageList.Contains(CheckedLanguageName))
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
            if (!this.CheckLanguageExist(AddedLanguageName) & (!string.IsNullOrEmpty(AddedLanguageName)))
            {
                _languageList.Append(AddedLanguageName);
            }
        }

        /// <summary>
        /// Исключение обучающегося с курсов по его фамилии
        /// </summary>
        public void ExcludeStudent(string ExcludedStudentSurname)
        {
            foreach(Course c in this._courses)
            {
                c.ExcludeStudent(ExcludedStudentSurname);
            }
        }

        public void AddStudent(Student AddedStudent)
        {
            _students.Add(AddedStudent);
        }

        /// <summary>
        /// Переформирует курсы, содержащиеся в школе согласно поступившим заявкам
        /// </summary>
        public void ReformCourses(List<CourseApplication> NewApplications)
        {
            
        }
        #endregion
    }
}
