using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_4_practice
{
    public struct Student
    {
        //Конструкторы
        //
        public Student(string Lastname) : this(Lastname, "")
        {}
        public Student(string Lastname, string FIO) : this(Lastname, FIO, 0)
        { }
        public Student(string Lastname, string FIO, int groupNumber)
            : this(Lastname, FIO,groupNumber,new int[5])
        { }
        public Student(string Lastname, string FIO, int groupNumber, int[] Grade)
        {
            this.Lastname = Lastname;
            this.FIO = FIO;
            _grade = Grade;
            this.groupNumber = groupNumber;
        }
        //
        //


        //Поля, геттеры и сеттеры
        //
        public string Lastname{get; set;}
        public string FIO { get; set; }
        public int groupNumber {get; set;}
        private int[] _grade;

        public int[] Grade
        {
            get
            {
                return _grade;
            }
            set
            {
                if (value.Length != 5)
                {
                    throw new ArgumentException("Массив оценок должен иметь длину 5");
                }
                _grade = new int[5];
                for (int i = 0; i < value.Length; i++)
                {
                    _grade[i] = value[i];
                }
            }
        }
        //
        //

        //Методы
        //
        public double Average()
        {
            int[] arr = this.Grade;
            double sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            sum /= arr.Length;
            return sum;
        }

        public bool isGoodStudent()
        {
            foreach (int grade in Grade)
            {
                if(grade < 4)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
