using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchoolManagement
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
        private List<Application> _applications = new List<Application>();
        #region Constructors

        #endregion

        #region Properties
        /// <summary>
        /// Фамилия обучающегося
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set { 
                if(!string.IsNullOrEmpty(value)) { _surname = value; };
                foreach(Application app in _applications)
                {
                    app.Surname = value;
                }
            }
        }
        /// <summary>
        /// Список поданных заявок
        /// </summary>
        public List<Application> Applications
        {
            get { return _applications; }
        }
        #endregion

        #region Methods
        
        #endregion

    }
}
