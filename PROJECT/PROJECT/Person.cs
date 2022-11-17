using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    [Serializable]
    abstract class Person
    {
        string name;
        string surname;
        int age;
        string mail;
        string birth_date;

        public Person(string name, string surname, int age, string mail, string birth_date)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Mail = mail;
            this.Birth_date = birth_date;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Birth_date { get => birth_date; set => birth_date = value; }

        public override string ToString()
        {
            return $"Name = {Name}\nSurname = {Surname}\nAge = {Age}\nMail = {Mail}\nBirth Date = {Birth_date}";
        }


     

    }
}
