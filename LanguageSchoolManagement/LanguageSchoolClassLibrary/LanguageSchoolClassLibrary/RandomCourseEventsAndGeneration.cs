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
        private static Random _rnd = new Random();

        #region Methods
        /// <summary>
        /// Генерация набора случайных заявок (от 0 до 1000) на основе данных о школе
        /// </summary>
        public static List<CourseApplication> GenerateApplications( LanguageSchool School)
        {
            List<CourseApplication> returnedList = new List<CourseApplication>();
            List<string> possibleSurnames = new List<string>();
            foreach(Student st in School.Students)
            {
                if(st.Applications.Count <= 7)
                {                    
                    possibleSurnames.Add(st.Surname);
                }                
            }
            foreach(string PossibleLanguage in School.Languages)
            {
                int step = _rnd.Next(14, Math.Max(14, possibleSurnames.Count));
                for (int i = 0; i < step; i++)
                {
                    returnedList.Add(GenerateRandomApplicationRandomSurnames(possibleSurnames, PossibleLanguage));
                }                
            }
            
            return returnedList;
        }

        /// <summary>
        /// Генерация случайной заявки по заданному набору языков и фамилий обучающихся
        /// </summary>
        public static CourseApplication GenerateRandomApplication(List<string> PossibleSurnames, List<string> AvailableLanguages)
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
        /// Генерация случайной заявки по заданному набору фамилий и заданному языку
        /// </summary>
        public static CourseApplication GenerateRandomApplicationRandomSurnames(List<string> PossibleSurnames, string AvailableLanguage)
        {
            CourseApplication generatedApplication = new CourseApplication("", "", 0, 0, 0);
            generatedApplication.Surname = PossibleSurnames[_rnd.Next(0, PossibleSurnames.Count)];
            generatedApplication.Language = AvailableLanguage;
            generatedApplication.Intensity = _rnd.Next(0, 3);
            generatedApplication.Level = _rnd.Next(0, 3);
            generatedApplication.PayedAmount = _rnd.Next(0, 10000);
            return generatedApplication;
        }

        /// <summary>
        /// Генерация случайного обучающегося (с количеством заявок от 0 до 10) Надо переписать чтобы зависел от школы!!
        /// </summary>
        public static Student GenerateRandomStudent(string PossibleSurname)
        {
            Student newStudent = new Student(PossibleSurname);
            //for(int i = 0; i < _rnd.Next(0, 11);)
            //{                
            //    newStudent.Applications.Add(GenerateRandomApplication(new List<string>() { newStudent.Surname }, new List<string>() { "English", "French", "German", "Chinese" }));
            //    i++;
            //}            
            return newStudent;
        }

        /// <summary>
        /// Генерация языковой школы со случайным стартовым количеством обучающихся и заявок и базовым набором языков
        /// </summary>
        public static LanguageSchool GenerateLanguageSchool(List<string> PossibleSurnames)
        {
            LanguageSchool newLanguageSchool = new LanguageSchool();
            for (int i = 0; i < PossibleSurnames.Count;)
            {                
                newLanguageSchool.AddStudent(GenerateRandomStudent(PossibleSurnames[i]));
                i++;
            }
            GenerateApplications(newLanguageSchool);
            foreach(string lang in newLanguageSchool.Languages)
            {
                newLanguageSchool.Courses.Add(GenerateCourse(lang));
            }
            return newLanguageSchool;
        }

        /// <summary>
        /// Генерация курса языковой школы с заданным языком для изучения
        /// </summary>
        public static Course GenerateCourse(string PossibleLanguage)
        {
            Course generatedCourse = new Course();
            generatedCourse.Language = PossibleLanguage;
            generatedCourse.IndividualCoefficient = _rnd.Next(0, 11);
            generatedCourse.StandartPayment = _rnd.Next(0, 3000);
            return generatedCourse;
        }
        #endregion
    }
}
