using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LanguageSchoolClassLibrary
{
    public class RandomCourseEventsAndGeneration
    {
        /// <summary>
        /// Использующийся генератор псевдослучайных чисел
        /// </summary>
        private Random _rnd = new Random();

        #region Methods
        /// <summary>
        /// Генерация набора случайных заявок (от 0 до 1000) на основе данных о школе
        /// </summary>
        public List<CourseApplication> GenerateApplications( LanguageSchool School)
        {
            List<CourseApplication> returnedList = new List<CourseApplication>();
            List<string> possibleSurnames = new List<string>();
            foreach(Student st in School.Students)
            {
                possibleSurnames.Add(st.Surname);
            }
            for (int i = 0; i < _rnd.Next(0, 1000);)
            {
                returnedList.Add(this.GenerateRandomApplication(possibleSurnames, School.Languages));
            }
            return returnedList;
        }

        /// <summary>
        /// Генерация случайной заявки по заданному набору языков и фамилий обучающихся
        /// </summary>
        public CourseApplication GenerateRandomApplication(List<string> PossibleSurnames, List<string> AvailableLanguages)
        {
            CourseApplication generatedApplication = new CourseApplication("", "", 0, 0, 0);            
            generatedApplication.Surname = PossibleSurnames[_rnd.Next(0, PossibleSurnames.Count)];
            generatedApplication.Language = AvailableLanguages[_rnd.Next(0, AvailableLanguages.Count)];
            generatedApplication.Intensity = _rnd.Next(0, 3);
            generatedApplication.Level = _rnd.Next(0, 3);
            generatedApplication.PayedAmount = _rnd.Next(0, 10000);
            return generatedApplication;
        }

        /// <summary>
        /// Генерация случайного обучающегося (с количеством заявок от 0 до 10)
        /// </summary>
        public Student GenerateRandomStudent(List<string> PossibleSurnames)
        {
            Student newStudent = new Student(PossibleSurnames[_rnd.Next(0, PossibleSurnames.Count)]);
            for(int i = 0; i < _rnd.Next(0, 11);)
            {
                newStudent.Applications.Add(this.GenerateRandomApplication(new List<string>() { newStudent.Surname }, new List<string>() { "English", "French", "German", "Chinese" }));
            }            
            return newStudent;
        }

        /// <summary>
        /// Генерация языковой школы со случайным стартовым количеством обучающихся и заявок и базовым набором языков
        /// </summary>
        public LanguageSchool GenerateLanguageSchool(List<string> PossibleSurnames)
        {
            LanguageSchool newLanguageSchool = new LanguageSchool();
            for(int i = 0; i < _rnd.Next(0, 101);)
            {
                newLanguageSchool.AddStudent(this.GenerateRandomStudent(PossibleSurnames));
            }
            this.GenerateApplications(newLanguageSchool);
            return newLanguageSchool;
        }
        #endregion
    }
}
