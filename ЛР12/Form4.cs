using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ЛР12
{
    public partial class Form4 : Form
    {
        public static DataRow row;
        private bool isUpdate;
        //SqlConnection conn = new SqlConnection("Data Source=EDU-MSSQL2008R2;Initial Catalog=Ip521_SegaAndGera;Integrated Security=True");

        public Form4()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем выбранный код абитуриента из комбо-бокса
            string кодАбитуриента = comboBox1.SelectedItem.ToString();

            // Получаем новую фамилию и имя из текстовых полей
            string новаяФамилия = textBox1.Text;
            string новоеИмя = textBox2.Text;
            string новоеОтчество = textBox3.Text;

            // Создаем подключение к базе данных
            using (SqlConnection connection = new SqlConnection("Data Source = EDU - MSSQL2008R2; Initial Catalog = _ip521-11_Иваквов Антонов; Integrated Security = True"))
            {
                // Открываем подключение
                connection.Open();

                // Создаем SQL-запрос на обновление данных
                string sqlQuery = "UPDATE Абитуриенты SET Фамилия = @новаяФамилия, Имя = @новоеИмя, Отчество = @новоеОтчество WHERE Код_абитуриента = @кодАбитуриента";

                // Создаем команду с параметрами
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@новаяФамилия", новаяФамилия);
                    command.Parameters.AddWithValue("@новоеИмя", новоеИмя);
                    command.Parameters.AddWithValue("@новоеОтчество", новоеОтчество);
                    command.Parameters.AddWithValue("@кодАбитуриента", кодАбитуриента);

                    // Выполняем запрос
                    command.ExecuteNonQuery();
                }

                // Закрываем подключение
                connection.Close();
            }

            // Очищаем текстовые поля
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            // Выводим сообщение об успешном обновлении
            MessageBox.Show("Данные успешно обновлены!");
            Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ip521_SegaAndGeraDataSet.Абитуриенты". При необходимости она может быть перемещена или удалена.
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
