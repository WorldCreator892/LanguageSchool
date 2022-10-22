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
            set { if (!string.IsNullOrEmpty(value)) { _language = value; } }
        }

        /// <summary>
        /// Количество студентов, обучающихся на курсе
        /// </summary>
        public int StudentAmount
        {
            get { return _studentAmount; }
        }
        /// <summary>
        /// Стандартная стоимость курса
        /// </summary>
        public int StandartPayment
        {
            get { return _standartPayment; }
            set { if(value > 0) { _standartPayment = value; } }
        }
        /// <summary>
        /// Коэффициент повышения цены курса при выборе индивидуального обучения
        /// </summary>
        public int IndividualCoefficient
        {
            get { return _individualCoefficient; } 
            set { if(value > 0) { _individualCoefficient = value; } }
        }

        public List<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
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

        /// <summary>
        /// Переформирует группы в курсе в рамках поступивших заявок
        /// </summary>
        public void GroupReform(List<CourseApplication> ApplicationsToReform)
        {
            CourseApplicationBasicComparer comp = new CourseApplicationBasicComparer();
            ApplicationsToReform.Sort(comp);
            this._groups.Clear();
            this._studentAmount = 0;
            int counter = -1;
            while(ApplicationsToReform.Count > 0 & this._studentAmount <=30) //цикл распределяет все заявки по соответствующим группам с числом не более 7 человек
            {
                this._groups.Add(new Group(0, this._language, ApplicationsToReform[0].Level, ApplicationsToReform[0].Intensity));                
                counter++;
                this._groups[counter].AddStudent(ApplicationsToReform[0]);
                ApplicationsToReform.RemoveAt(0);
                for(int i = 0; i < ApplicationsToReform.Count;)
                {
                    if(ApplicationsToReform[i].Level == this._groups[counter].Level & ApplicationsToReform[i].Intensity == this._groups[counter].Intensity & this._groups[counter].Amount < 7 & !this._groups[counter].CheckStudentExistence(ApplicationsToReform[i].Surname))
                    {
                        this._groups[counter].AddStudent(ApplicationsToReform[i]);
                        ApplicationsToReform.RemoveAt(i);
                    } else
                    {
                        i++;
                    }
                }
            }
            for(int i = 0; i < this._groups.Count;) //присоединяет группы из 4 и менее человек к большим если таковые есть
            {
                if(this._groups[i].Amount <= 4)
                {
                    for(int j = 0; j < i;)
                    {
                        if(this._groups[j].Intensity == this._groups[i].Intensity & this._groups[j].Level == this._groups[i].Level & this._groups[j].Amount < 10)
                        {
                            for(int k = 0; k < this._groups[i].Amount;)
                            {
                                if(this._groups[j].Amount < 10)
                                {
                                    if(this._groups[i].TransferStudent(this._groups[j], this._groups[i].StudentNames[k]))
                                    {

                                    } else
                                    {
                                        k++;
                                    }
                                }
                            }
                        }
                        j++;
                    }
                }
                i++;
            }
        }
        #endregion
    }
}
