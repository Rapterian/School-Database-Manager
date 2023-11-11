using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PRG282.LogicLayer
{
    internal class Student
    {
        int studentnumber;
        string name, surname, studentImage;
        DateTime DOB;
        string gender, phone, address, moduleCode;

        public Student(int studentnumber, string name, string surname, string studentImage, DateTime dOB, string gender, string phone, string address, string moduleCode)
        {
            this.Studentnumber = studentnumber;
            this.Name = name;
            this.Surname = surname;
            this.StudentImage = studentImage;
            DOB1 = dOB;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.ModuleCode = moduleCode;
        }
        public Student( string name, string surname, string studentImage, DateTime dOB, string gender, string phone, string address, string moduleCode)
        {
            
            this.Name = name;
            this.Surname = surname;
            this.StudentImage = studentImage;
            DOB1 = dOB;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.ModuleCode = moduleCode;
        }

        public Student()
        {

        }

        public int Studentnumber { get => studentnumber; set => studentnumber = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string StudentImage { get => studentImage; set => studentImage = value; }
        public DateTime DOB1 { get => DOB; set => DOB = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
    }
}
