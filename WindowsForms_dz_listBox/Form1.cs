using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_dz_listBox
{
    public partial class Form1 : Form
    {
        // создаем список пользователей
        List<User> list = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }

        // обработчик события кнопки Добавить пользователя
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // инициализируем пользователя данными из текстбоксов
            User user = new User(textBoxName.Text, textBoxSurname.Text, 
                textBoxEmail.Text, Convert.ToInt64(textBoxTel.Text));
            // добавляем пользователя в список
            list.Add(user);
            // инициализируем элемент Листбокс полученным выше списком
            listBox1.DataSource = null;
            listBox1.DataSource = list;
        }

        // обработчик события кнопки Удалить пользователя
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // находим индекс выделенного жлемента листбокса
            int index = listBox1.SelectedIndex;
            // если у элемента ЛистБокс ничего не выделено, свойство SelectedIndex вернет -1
            if (index != -1)                 // если какой-либо элемент листбокса выделен
            {
                list.RemoveAt(index);        // удаляем этот элемент по индексу из списка
                listBox1.DataSource = null;
                listBox1.DataSource = list;  // инициализируем листбокс обновленным списком
            }
        }

        // обработчик события Выделение элемента листбокса
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // инициализируем объект Пользователь выделенным элементом листбокса
            User obj = listBox1.SelectedItem as User;
            if (obj != null)  // если объект выделен - 
                              // инициализируем текстбоксы значениями полей объекта
            {
                textBoxName.Text = obj.Name.ToString();
                textBoxSurname.Text = obj.Surname.ToString();
                textBoxEmail.Text = obj.Email.ToString();
                textBoxTel.Text = obj.Telephone.ToString();
            }
        }

        // обработчик события кнопки Редактировать пользователя
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // инициализируем объект Пользователь выделенным элементом листбокса
            User obj = listBox1.SelectedItem as User;
            // инициализируем значение полей объекта данными из текстбоксов
            obj.Name = textBoxName.Text;
            obj.Surname = textBoxSurname.Text;
            obj.Email = textBoxEmail.Text;
            obj.Telephone =  Convert.ToInt64(textBoxTel.Text);
            // инициализируем листбокс обновленным списком
            listBox1.DataSource = null;
            listBox1.DataSource = list;
            
            // закомментированный вариант - с циклом и сравнением - 
            // - в процессе запуталась и не поняла, для чего сравнение,
            // но работает и вариант выше без цикла
            //foreach (var iten in list)
            //{
            //    if (obj.Equals(iten))
            //    {
            //        iten.Name = textBoxName.Text;
            //        iten.Surname = textBoxSurname.Text;
            //        iten.Email = textBoxEmail.Text;
            //        iten.Telephone = Convert.ToInt64(textBoxTel.Text);
            //        listBox1.DataSource = null;
            //        listBox1.DataSource = list;
            //        break;
            //    }
            //}
        }

        // обработчик события кнопки Сохранить (весь список)
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string filePath = "file1.txt";  // название файла для сохранения
            // открываем поток, создаем файл
            using(FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                // запись через объект StreamWriter
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    // цикл по списку объектов, записываем каждый объект в файл
                    foreach(User obj in listBox1.Items)
                    {
                        sw.WriteLine(obj.ToString());
                    }
                }
            }
        }
    }
}
