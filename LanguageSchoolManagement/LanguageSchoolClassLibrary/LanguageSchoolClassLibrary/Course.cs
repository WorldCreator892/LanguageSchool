using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolClassLibrary
{
    /// <summary>
    /// Класс для создания и работы с курсом по заданному языку
    /// </summary>
    public class Course
    {        
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
        /// Исключение обучающегося из всех групп курса по заданной фамилии
        /// </summary>
        public void ExcludeStudent(string ExcludedStudentSurname)
        {
            foreach(Group gr in _groups)
            {
                if(gr.CheckStudentExistence(ExcludedStudentSurname))
                {
                    gr.ExcludeStudent(ExcludedStudentSurname);
                }
            }
        }

        public void GroupReform(List<CourseApplication> NewApplications)
        {

        }
        #endregion
    }
}
