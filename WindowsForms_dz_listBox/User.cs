using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_dz_listBox
{
    // пользовательский класс Пользователь
    internal class User
    {
        public string Name { get; set; }     // имя
        public string Surname { get; set; }  // фамилия
        public string Email { get; set; }    // эл.почта
        public long Telephone { get; set; }  // телефон
        public User() { }
        public User(string n, string s, string e, long t)   // конструктор
        {
            Name = n;
            Surname = s;
            Email = e;
            Telephone = t;
        }

        // перегруженный метод ToString()
        public override string ToString()
        {
            return $"{Name} {Surname} {Email} {Telephone}";
        }
    }
}
