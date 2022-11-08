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
        /// <summary>
        /// Список всех идентификаторов, доступных для присвоения группам
        /// </summary>
        private List<int> _free_group_ids = new List<int>(1000);
        #region Constructors
        /// <summary>
        /// Стандартный конструктор класса
        /// </summary>
        public Course()
        {
            for (int i = 0; i < 1000; i++)
            {
                _free_group_ids.Add(i);
            }
        }
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
            set { if (value >=0) { _studentAmount = value; } }
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
        public void ExcludeStudent(int ExcludedStudentID)
        {
            foreach(Group gr in _groups)
            {
                if(gr.CheckStudentExistence(ExcludedStudentID))
                {
                    gr.ExcludeStudent(ExcludedStudentID);
                }
            }
        }

        /// <summary>
        /// Переформирует группы в курсе в рамках поступивших заявок
        /// </summary>
        public void GroupReform(List<CourseApplication> ApplicationsToReform, LanguageSchool sch)
        {
            CourseApplicationBasicComparer comp = new CourseApplicationBasicComparer();
            ApplicationsToReform.Sort(comp);
            foreach (Group gr in this.Groups)
            {
                _free_group_ids.Add(gr.ID);
            }
            this._groups.Clear();
            this._studentAmount = 0;
            int counter = -1;
            List<CourseApplication> PossibleToSeparate = new List<CourseApplication>();
            foreach(CourseApplication NewApplication in ApplicationsToReform) //отделение заявок без оплаты
            {
                if(NewApplication.PayedAmount < this.StandartPayment)
                {
                    NewApplication.Status = 0;
                    ApplicationsToReform.Remove(NewApplication);
                } else
                {
                    NewApplication.Status = 1;
                    if(NewApplication.PayedAmount >= this.StandartPayment * IndividualCoefficient)
                    {
                        PossibleToSeparate.Add(NewApplication);
                    }
                }
            }
            Random _rnd = new Random();
            while(ApplicationsToReform.Count > 0 & this.StudentAmount <=30) //распределение заявок по группам <=7 человек пока не кончатся или не станет 30 студентов на курсе
            {
                bool check = false;
                foreach(Group g in this.Groups)
                {
                    if (g.CheckIfApplicationFits(ApplicationsToReform[0]) & g.Amount < 7)
                    {
                        check = true;
                        ApplicationsToReform[0].GroupID = g.ID;
                        ApplicationsToReform[0].Status = 3;
                        g.AddStudent(ApplicationsToReform[0]);
                        ApplicationsToReform.RemoveAt(0);
                        this.StudentAmount++;
                        break;
                    }
                }
                if(!check)
                {
                    int freeid = _rnd.Next(0, _free_group_ids.Count);
                    this.Groups.Add(new Group(_free_group_ids[freeid], this.Language, ApplicationsToReform[0].Level, ApplicationsToReform[0].Intensity));
                    _free_group_ids.RemoveAt(freeid);
                    ApplicationsToReform[0].Status = 3;
                    ApplicationsToReform[0].GroupID = this.Groups[this.Groups.Count - 1].ID;
                    this.Groups[this.Groups.Count - 1].AddStudent(ApplicationsToReform[0]);
                    ApplicationsToReform.RemoveAt(0);
                    this.StudentAmount++;
                }                
            }

            bool merge = true;
            List<int> EmptyGroups = new List<int>();
            while(merge) //совмещение малых групп с большими если возможно
            {
                merge = false;
                for (int i = 0; i < this.Groups.Count; i++)
                {
                    if (this.Groups[i].Amount <= 4)
                    {
                        for (int j = 0; j < this.Groups.Count; j++)
                        {
                            if (this.Groups[i].CheckIfGroupsAreSimilar(this.Groups[j]))
                            {
                                if (this.Groups[j].ID != this.Groups[i].ID)
                                {
                                    for (int k = 0; k < this.Groups[j].Amount; k++)
                                    {
                                        Groups[j].TransferStudent(Groups[i], Groups[j].StudentIDs[0]);
                                        if (this.Groups[i].Amount == 10 & this.Groups[j].Amount == 0)
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                
                for(int i = 0; i < this.Groups.Count; i++)
                {
                    if(this.Groups[i].Amount == 0)
                    {
                        EmptyGroups.Add(i);
                        merge = true;
                    }
                }
                for(int i = EmptyGroups.Count - 1; i >=0; i--)
                {
                    this._free_group_ids.Add(this.Groups[EmptyGroups[i]].ID);
                    this.Groups.RemoveAt(EmptyGroups[i]);
                }
            }
            EmptyGroups.Clear();
            int count = this.Groups.Count;
            for (int i = 0; i < count; i++) //для оставшихся малых групп попытка заменить на индивидуальное обучение
            {
                if(this.Groups[i].Amount <= 4)
                {
                    EmptyGroups.Add(i);
                    StudentAmount -= this.Groups[i].Amount;
                    foreach(int ID in this.Groups[i].StudentIDs)
                    {
                        foreach(Student s in sch.Students)
                        {
                            foreach(CourseApplication c in s.Applications)
                            {
                                if(c.GroupID == this.Groups[i].ID )
                                {
                                    if(c.PayedAmount >= this.StandartPayment * this.IndividualCoefficient)
                                    {
                                        int freeid = _rnd.Next(0, _free_group_ids.Count);
                                        this.Groups.Add(new Group(_free_group_ids[freeid], this.Groups[i].Language, this.Groups[i].Level, this.Groups[i].Intensity));
                                        _free_group_ids.RemoveAt(freeid);
                                        c.GroupID = this.Groups[this.Groups.Count - 1].ID;
                                        c.Status = 2;
                                        this.Groups[this.Groups.Count - 1].AddStudentByID(ID);
                                        StudentAmount++;
                                    }                                    
                                }
                            }
                        }
                        
                    }

                }
            }
            for (int i = EmptyGroups.Count - 1; i >= 0; i--)
            {
                this._free_group_ids.Add(this.Groups[EmptyGroups[i]].ID);
                this.Groups.RemoveAt(EmptyGroups[i]);
            }
            while(ApplicationsToReform.Count > 0 & this.StudentAmount <= 30)
            {
                ApplicationsToReform[0].Status = 1;
                if (PossibleToSeparate.Contains(ApplicationsToReform[0]))
                {
                    int freeid = _rnd.Next(0, _free_group_ids.Count);
                    this.Groups.Add(new Group(_free_group_ids[freeid], ApplicationsToReform[0].Language, ApplicationsToReform[0].Level, ApplicationsToReform[0].Intensity));
                    _free_group_ids.RemoveAt(freeid);
                    ApplicationsToReform[0].GroupID = this.Groups[this.Groups.Count - 1].ID;
                    ApplicationsToReform[0].Status = 2;
                    this.Groups[this.Groups.Count - 1].AddStudent(ApplicationsToReform[0]);                    
                    StudentAmount++;
                }
                ApplicationsToReform.RemoveAt(0);
            }
            for(int i = 0; i < ApplicationsToReform.Count; i++)
            {
                ApplicationsToReform[i].Status = 1;
            }


            //while(ApplicationsToReform.Count > 0 & this._studentAmount <=30) //цикл распределяет все заявки по соответствующим группам с числом не более 7 человек
            //{
            //    this._groups.Add(new Group(0, this._language, ApplicationsToReform[0].Level, ApplicationsToReform[0].Intensity));                
            //    counter++;
            //    this._groups[counter].AddStudent(ApplicationsToReform[0]);
            //    ApplicationsToReform.RemoveAt(0);
            //    for(int i = 0; i < ApplicationsToReform.Count;)
            //    {
            //        if(ApplicationsToReform[i].Level == this._groups[counter].Level & ApplicationsToReform[i].Intensity == this._groups[counter].Intensity & this._groups[counter].Amount < 7 & !this._groups[counter].CheckStudentExistence(ApplicationsToReform[i].Surname))
            //        {
            //            this._groups[counter].AddStudent(ApplicationsToReform[i]);
            //            ApplicationsToReform.RemoveAt(i);
            //        } else
            //        {
            //            i++;
            //        }
            //    }
            //}
            //for(int i = 0; i < this._groups.Count;) //присоединяет группы из 4 и менее человек к большим если таковые есть
            //{
            //    if(this._groups[i].Amount <= 4)
            //    {
            //        for(int j = 0; j < i;)
            //        {
            //            if(this._groups[j].Intensity == this._groups[i].Intensity & this._groups[j].Level == this._groups[i].Level & this._groups[j].Amount < 10)
            //            {
            //                for(int k = 0; k < this._groups[i].Amount;)
            //                {
            //                    if(this._groups[j].Amount < 10)
            //                    {
            //                        if(this._groups[i].TransferStudent(this._groups[j], this._groups[i].StudentNames[k]))
            //                        {

            //                        } else
            //                        {
            //                            k++;
            //                        }
            //                    }
            //                }
            //            }
            //            j++;
            //        }
            //    }
            //    i++;
            //}
        }
        #endregion
    }
}
