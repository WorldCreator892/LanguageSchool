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
        /// Генерация набора случайных заявок на основе данных о школе
        /// </summary>
        public static List<CourseApplication> GenerateApplications( LanguageSchool School)
        {
            List<CourseApplication> returnedList = new List<CourseApplication>();
            foreach(Student st in School.Students)
            {
                foreach(CourseApplication c in st.Applications)
                {
                    returnedList.Add(new CourseApplication(c));
                }
            }
            int ExcludedStudentCount = _rnd.Next(0, School.Students.Count / 100);
            for(int i = 0; i < ExcludedStudentCount; i++)
            {
                School.ExcludeStudent(School.Students[_rnd.Next(0, School.Students.Count)].ID);
            }
            int NewStudentCount = _rnd.Next(0, School.Students.Count / 50);
            for (int i = 0; i < NewStudentCount; i++)
            {
                Student generatedStudent = RandomCourseEventsAndGeneration.GenerateRandomStudent(School.Surnames, School.Languages, School.FreeStudentIDs);
                School.AddStudent(generatedStudent);
            }
            for(int i = 0; i < School.Students.Count; i++)
            {
                int GeneratedApplicationCount = _rnd.Next(0, 3);
                for(int j = 0; j < GeneratedApplicationCount; j++)
                {
                    returnedList.Add(RandomCourseEventsAndGeneration.GenerateRandomApplication(School.Languages, School.Students[i]));
                }
            }
            return returnedList;
        }

        /// <summary>
        /// Генерация случайной заявки по заданному набору языков и обучающемуся
        /// </summary>
        public static CourseApplication GenerateRandomApplication(List<string> PossibleLanguages, Student ApplyingStudent)
        {
            Dictionary<string, int> possibleApplications = new Dictionary<string, int>();
            for (int i = 0; i < PossibleLanguages.Count; i++)
            {
                possibleApplications.Add(PossibleLanguages[i], 0);
            }
            for (int i = 0; i < ApplyingStudent.Applications.Count; i++)
            {
                if (possibleApplications[ApplyingStudent.Applications[i].Language] < ApplyingStudent.Applications[i].Level)
                {
                    
                        possibleApplications[ApplyingStudent.Applications[i].Language] = ApplyingStudent.Applications[i].Level;
                                       
                }

            }
            string randomLanguage = PossibleLanguages[_rnd.Next(0, PossibleLanguages.Count)];
            CourseApplication newApplication = new CourseApplication();
            newApplication.Surname = ApplyingStudent.Surname;
            newApplication.Language = randomLanguage;
            newApplication.Level = _rnd.Next(possibleApplications[randomLanguage], 4);
            newApplication.Intensity = _rnd.Next(0, 3);
            newApplication.PayedAmount = _rnd.Next(0, 10000);
            newApplication.ApplicationID = ApplyingStudent.ID * 100 + ApplyingStudent.Applications.Count;
            ApplyingStudent.Applications.Add(newApplication);
            return newApplication;            
        }

        /// <summary>
        /// Генерация случайной заявки по заданному набору фамилий и заданному языку
        /// </summary>
        //public static CourseApplication GenerateRandomApplicationRandomSurnames(List<string> PossibleSurnames, string AvailableLanguage)
        //{
        //    CourseApplication generatedApplication = new CourseApplication("", "", 0, 0, 0);
        //    generatedApplication.Surname = PossibleSurnames[_rnd.Next(0, PossibleSurnames.Count)];
        //    generatedApplication.Language = AvailableLanguage;
        //    generatedApplication.Intensity = _rnd.Next(0, 3);
        //    generatedApplication.Level = _rnd.Next(0, 3);
        //    generatedApplication.PayedAmount = _rnd.Next(0, 10000);
        //    return generatedApplication;
        //}

        /// <summary>
        /// Генерация случайного обучающегося (с количеством заявок от 0 до 10)
        /// </summary>
        public static Student GenerateRandomStudent(List<string> PossibleSurnames, List<string> PossibleLanguages, List<int> PossibleIDs)
        {
            int randomID = _rnd.Next(0, PossibleIDs.Count);
            Student newStudent = new Student(PossibleSurnames[_rnd.Next(0, PossibleSurnames.Count)], PossibleIDs[randomID]);
            PossibleIDs.RemoveAt(randomID);
            int count = _rnd.Next(0, 4);
            for(int i = 0; i < count; i++)
            {
                RandomCourseEventsAndGeneration.GenerateRandomApplication(PossibleLanguages, newStudent);
            }
            return newStudent;
        }

        /// <summary>
        /// Генерация языковой школы со случайным стартовым количеством обучающихся, заявок и языков
        /// </summary>
        public static LanguageSchool GenerateLanguageSchool(List<string> PossibleSurnames, List<string> PossibleLanguages)
        {
            LanguageSchool newLanguageSchool = new LanguageSchool();
            List<string> ProbableLanguages = new List<string>();
            List<string> UsedLanguages = new List<string>();
            for (int i = 0; i < PossibleLanguages.Count; i++)
            {
                ProbableLanguages.Add(PossibleLanguages[i]);                
            }
            int languageAmount = _rnd.Next(1, ProbableLanguages.Count);          
            for(int i = 0; i < languageAmount; i++)                                 
            {
                int usedLanguage = _rnd.Next(0, PossibleLanguages.Count - i);
                UsedLanguages.Add(ProbableLanguages[usedLanguage]);
                ProbableLanguages.RemoveAt(usedLanguage);
            }
            for(int i = 0; i < UsedLanguages.Count; i++)
            {
                Course generatedCourse = new Course();
                generatedCourse.Language = UsedLanguages[i];
                generatedCourse.IndividualCoefficient = _rnd.Next(0, 11);
                generatedCourse.StandartPayment = _rnd.Next(0, 3000);
                newLanguageSchool.Courses.Add(generatedCourse);
            }
            int studentAmount = _rnd.Next(15, UsedLanguages.Count * 150);
            for(int i = 0; i < studentAmount; i++)
            {
                Student generatedStudent = RandomCourseEventsAndGeneration.GenerateRandomStudent(PossibleSurnames, PossibleLanguages, newLanguageSchool.FreeStudentIDs);                
                newLanguageSchool.AddStudent(generatedStudent);
            }
            return newLanguageSchool;
        }

        /// <summary>
        /// Генерация курса языковой школы с заданным языком для изучения
        /// </summary>
        public static Course GenerateCourse(string Language)
        {
            Course generatedCourse = new Course();
            generatedCourse.Language = Language;
            generatedCourse.IndividualCoefficient = _rnd.Next(0, 11);
            generatedCourse.StandartPayment = _rnd.Next(0, 3000);
            return generatedCourse;
        }
        #endregion
    }
}
