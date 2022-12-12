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
        /// Список всех возможных фамилий студентов
        /// </summary>
        private static List<string> _surnameList = new List<string>() { "Петров", "Иванов", "Попов", "Ильин",
                    "Федоров","Белов","Серов","Игнатов","Чернов","Свиридов","Яров","Шишкин","Котов" };
        /// <summary>
        /// Список всех обучающихся курса
        /// </summary>
        private List<Student> _students = new List<Student>();
        /// <summary>
        /// Список всех идентификаторов, доступных для присвоения студентам
        /// </summary>
        private List<int> _free_student_ids = new List<int>(10000);
        /// <summary>
        /// Максимальный идентификатор, доступный для присвоения студентам
        /// </summary>
        private int _maxID = 9999;

        #region Constructors
        /// <summary>
        /// Стандартный конструктор класса для создания экземпляра языковой школы, автоматически генерирует начальное стостояние случайным образом
        /// </summary>
        public LanguageSchool()
        {
            
            for (int i = 0; i < 1000; i++)
            {
                _free_student_ids.Add(i);
            }
        }
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
        /// <summary>
        /// Список всех возможных фамилий учеников
        /// </summary>
        public List<string> Surnames
        {
            get { return _surnameList; }
        }
        /// <summary>
        /// Существующие в языковой школе курсы
        /// </summary>
        public List<Course> Courses
        {
            get { return _courses; }
            set
            {
                if(value.Count != 0)
                {
                    _courses = value;
                }
            }
        }
        /// <summary>
        /// Свободные ID обучающихся
        /// </summary>
        public List<int> FreeStudentIDs
        {
            get { return _free_student_ids; }
            set { if(value != null) { FreeStudentIDs = value; } }
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
                _courses.Add(RandomCourseEventsAndGeneration.GenerateCourse(AddedLanguageName));
            }
        }

        /// <summary>
        /// Исключение обучающегося с курсов по его ID
        /// </summary>
        public void ExcludeStudent(int ExcludedStudentID)
        {
            foreach(Course c in this._courses)
            {
                c.ExcludeStudent(ExcludedStudentID);
            }
            _free_student_ids.Add(ExcludedStudentID);
        }

        public void AddStudent(Student AddedStudent)
        {
            _students.Add(AddedStudent);
        }

        /// <summary>
        /// Переформирует курсы, содержащиеся в школе согласно сгенерированным заявкам
        /// </summary>
        public void ReformCourses()
        {
            List<CourseApplication> NewApplications = new List<CourseApplication>();
            NewApplications = RandomCourseEventsAndGeneration.GenerateApplications(this);

            foreach (Course ExistingCourse in this.Courses) //поиск групп с окончившимся обучением и перевод на следующий уровень
            {
                foreach(Group gr in ExistingCourse.Groups)
                {
                    gr.RemainingLessons = gr.RemainingLessons - 1;
                    if(gr.RemainingLessons == 0)
                    {
                        foreach(int StudentID in gr.StudentIDs)
                        {
                            foreach(Student GraduatedStudent in this.Students)
                            {
                                if(GraduatedStudent.ID == StudentID)
                                {
                                    bool hasNewApplication = false;
                                    foreach(CourseApplication c in GraduatedStudent.Applications)
                                    {
                                        if(c.GroupID == -1)
                                        {
                                            if(c.Language == gr.Language)
                                            {
                                                hasNewApplication = true;
                                                break;
                                            }
                                        }
                                    }
                                    if(!hasNewApplication)
                                    {
                                        foreach (CourseApplication c in GraduatedStudent.Applications)
                                        {
                                            if (c.GroupID == gr.ID)
                                            {
                                                if (gr.Level != 3)
                                                {
                                                    c.Level = c.Level + 1;
                                                }
                                            }
                                            break;
                                        }
                                    }                                    
                                }
                                break;
                            }
                        }
                    }
                }
            }
            foreach (Student st in this._students)
            {
                Random _rnd = new Random();
                foreach (CourseApplication oldApplication in st.Applications)
                {
                    oldApplication.WaitingTime = oldApplication.WaitingTime + 1;
                    oldApplication.GroupID = -1;                    
                    oldApplication.PayedAmount = _rnd.Next(0, 10000);                    
                }
            }
            

            foreach(CourseApplication NewApplication in NewApplications)
            {
                bool CourseExists = false;
                foreach(Course c in this.Courses)
                {
                    if(c.Language == NewApplication.Language)
                    {
                        CourseExists = true;
                        break;
                    }
                }
                if(!CourseExists)
                {
                    this.Courses.Add(RandomCourseEventsAndGeneration.GenerateCourse(NewApplication.Language));
                }
            }

            List<Course> Deleted = new List<Course>();
            foreach (Course ExistingCourse in this._courses)
            {
                List<CourseApplication> LanguageSortedApplications = new List<CourseApplication>();
                for (int i = 0; i < NewApplications.Count;)
                {
                    if(NewApplications[i].Language == ExistingCourse.Language)
                    {
                        if(NewApplications[i].PayedAmount >= ExistingCourse.StandartPayment)
                        {
                            LanguageSortedApplications.Add(NewApplications[i]);                            
                        }
                        NewApplications.RemoveAt(i);
                    } else
                    {
                        i++;
                    }
                }
                if(LanguageSortedApplications.Count >= 15)
                {
                    ExistingCourse.GroupReform(LanguageSortedApplications, this);
                } else
                {
                    Deleted.Add(ExistingCourse);
                }               
            }
            foreach(Course c in Deleted)
            {
                this.Courses.Remove(c);
            }

            foreach(Student s in this.Students)
            {
                s.SetSchedule();
            }

        }

        /// <summary>
        /// Увеличивает число доступных идентификаторов студентов
        /// </summary>
        public void ExpandIdRange(int difference)
        {
            if(difference > 0)
            {                
                for(int i = _maxID; i < _maxID + difference; i++)
                {
                    _free_student_ids.Add(i + 1);
                }
                _maxID = _maxID + difference;
            }
        }
        #endregion
    }
}
