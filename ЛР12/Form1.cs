using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=EDU-MSSQL2008R2;Initial Catalog=&quot;ip521-11_Иваквов Антонов&quot;;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn_f = new SqlConnection(Properties.Settings.Default.ConString);
            SqlCommand cmd_f = new SqlCommand();
            cmd_f.Connection = conn_f;
            cmd_f.CommandType = CommandType.StoredProcedure;
            cmd_f.CommandText = "faculty_select1";
            conn_f.Open();
            SqlDataReader rdrf = cmd_f.ExecuteReader();
            DataTable dtf = new DataTable();
            for (int i = 0; i < rdrf.FieldCount; i++)
            {
                dtf.Columns.Add(new DataColumn(rdrf.GetName(i), rdrf.GetFieldType(i)));
            }
            while (rdrf.Read())
            {
                DataRow r = dtf.NewRow();
                for (int i = 0; i < rdrf.FieldCount; i++)
                {
                    r[i] = rdrf.GetValue(i);
                }
                dtf.Rows.Add(r);
            }
            comboBox1.DataSource = dtf;
            comboBox1.ValueMember = "Код_абитуриента";
            comboBox1.DisplayMember = "Фамилия";
            comboBox1.SelectedValue = -1;
            conn_f.Close();




            LoadData();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.ConString;
            SqlCommand cmdApplications = new SqlCommand();
            cmdApplications.Connection = conn;
            cmdApplications.CommandText = "SELECT * FROM Заявления";

            conn.Open();
            SqlDataReader rdrApplications = cmdApplications.ExecuteReader();
            DataTable dtApplications = new DataTable();
            for (int i = 0; i < rdrApplications.FieldCount; i++)
            {
                dtApplications.Columns.Add(new DataColumn(rdrApplications.GetName(i), rdrApplications.GetFieldType(i)));
            }
            while (rdrApplications.Read())
            {
                DataRow row = dtApplications.NewRow();
                for (int i = 0; i < rdrApplications.FieldCount; i++)
                {
                    row[i] = rdrApplications.GetValue(i);
                }
                dtApplications.Rows.Add(row);
            }
            conn.Close();

            dataGridView2.DataSource = dtApplications;
            lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dtApplications.Rows.Count);



            SqlConnection conn1 = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.ConString;

            // Загрузка данных из таблицы "Экзамены"
            SqlCommand cmdExams = new SqlCommand();
            cmdExams.Connection = conn;
            cmdExams.CommandText = "SELECT * FROM Экзамены";

            conn.Open();
            SqlDataReader rdrExams = cmdExams.ExecuteReader();
            DataTable dtExams = new DataTable();
            for (int i = 0; i < rdrExams.FieldCount; i++)
            {
                dtExams.Columns.Add(new DataColumn(rdrExams.GetName(i), rdrExams.GetFieldType(i)));
            }
            while (rdrExams.Read())
            {
                DataRow row = dtExams.NewRow();
                for (int i = 0; i < rdrExams.FieldCount; i++)
                {
                    row[i] = rdrExams.GetValue(i);
                }
                dtExams.Rows.Add(row);
            }
            conn.Close();

            dataGridView3.DataSource = dtExams;
            lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dtExams.Rows.Count);

            // Загрузка данных из таблицы "Специальности"
            SqlCommand cmdSpecialties = new SqlCommand();
            cmdSpecialties.Connection = conn;
            cmdSpecialties.CommandText = "SELECT * FROM Специальности";

            conn.Open();
            SqlDataReader rdrSpecialties = cmdSpecialties.ExecuteReader();
            DataTable dtSpecialties = new DataTable();
            for (int i = 0; i < rdrSpecialties.FieldCount; i++)
            {
                dtSpecialties.Columns.Add(new DataColumn(rdrSpecialties.GetName(i), rdrSpecialties.GetFieldType(i)));
            }
            while (rdrSpecialties.Read())
            {
                DataRow row = dtSpecialties.NewRow();
                for (int i = 0; i < rdrSpecialties.FieldCount; i++)
                {
                    row[i] = rdrSpecialties.GetValue(i);
                }
                dtSpecialties.Rows.Add(row);
            }
            conn.Close();

            dataGridView4.DataSource = dtSpecialties;
            lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dtSpecialties.Rows.Count);

            // Загрузка данных из таблицы "Оценки"
            SqlCommand cmdGrades = new SqlCommand();
            cmdGrades.Connection = conn;
            cmdGrades.CommandText = "SELECT * FROM Оценки";

            conn.Open();
            SqlDataReader rdrGrades = cmdGrades.ExecuteReader();
            DataTable dtGrades = new DataTable();
            for (int i = 0; i < rdrGrades.FieldCount; i++)
            {
                dtGrades.Columns.Add(new DataColumn(rdrGrades.GetName(i), rdrGrades.GetFieldType(i)));
            }
            while (rdrGrades.Read())
            {
                DataRow row = dtGrades.NewRow();
                for (int i = 0; i < rdrGrades.FieldCount; i++)
                {
                    row[i] = rdrGrades.GetValue(i);
                }
                dtGrades.Rows.Add(row);
            }
            conn.Close();

            dataGridView5.DataSource = dtGrades;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void абитуриентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.ConString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn; cmd.CommandText = "Select * from Абитуриенты";
            conn.Open(); SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); for (int i = 0; i < rdr.FieldCount; i++)
            {
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));
            } while (rdr.Read())
            {
                DataRow row = dt.NewRow(); for (int i = 0; i < rdr.FieldCount; i++)
                {
                    row[i] = rdr.GetValue(i);
                }
                dt.Rows.Add(row);
            }
            conn.Close(); dataGridView1.DataSource = dt; lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dt.Rows.Count);


        }

        private void заявленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(); conn.ConnectionString = Properties.Settings.Default.ConString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn; cmd.CommandText = "Select * from Заявления";
            conn.Open(); SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); for (int i = 0; i < rdr.FieldCount; i++)
            {
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));
            } while (rdr.Read())
            {
                DataRow row = dt.NewRow(); for (int i = 0; i < rdr.FieldCount; i++)
                {
                    row[i] = rdr.GetValue(i);
                }
                dt.Rows.Add(row);
            }
            conn.Close(); dataGridView1.DataSource = dt; lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dt.Rows.Count);
        }

        private void специальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(); conn.ConnectionString = Properties.Settings.Default.ConString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn; cmd.CommandText = "Select * from Специальности";
            conn.Open(); SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); for (int i = 0; i < rdr.FieldCount; i++)
            {
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));
            } while (rdr.Read())
            {
                DataRow row = dt.NewRow(); for (int i = 0; i < rdr.FieldCount; i++)
                {
                    row[i] = rdr.GetValue(i);
                }
                dt.Rows.Add(row);
            }
            conn.Close(); dataGridView1.DataSource = dt; lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dt.Rows.Count);
        }

        private void экзаменыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(); conn.ConnectionString = Properties.Settings.Default.ConString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn; cmd.CommandText = "Select * from Экзамены";
            conn.Open(); SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); for (int i = 0; i < rdr.FieldCount; i++)
            {
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));
            } while (rdr.Read())
            {
                DataRow row = dt.NewRow(); for (int i = 0; i < rdr.FieldCount; i++)
                {
                    row[i] = rdr.GetValue(i);
                }
                dt.Rows.Add(row);
            }
            conn.Close(); dataGridView1.DataSource = dt; lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dt.Rows.Count);
        }

        private void оценкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.ConString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn; cmd.CommandText = "Select * from Оценки";
            conn.Open(); SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); for (int i = 0; i < rdr.FieldCount; i++)
            {
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i)));
            } while (rdr.Read())
            {
                DataRow row = dt.NewRow(); for (int i = 0; i < rdr.FieldCount; i++)
                {
                    row[i] = rdr.GetValue(i);
                }
                dt.Rows.Add(row);
            }
            conn.Close(); dataGridView1.DataSource = dt; lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dt.Rows.Count);
        }
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(); 
            conn.ConnectionString = Properties.Settings.Default.ConString; 
            SqlCommand cmd = new SqlCommand(); 
            cmd.Connection = conn; cmd.CommandText = "Select * from абитуриенты"; 
            conn.Open(); SqlDataReader rdr = cmd.ExecuteReader(); 
            DataTable dt = new DataTable(); 
            for (int i = 0; i < rdr.FieldCount; i++) 
            { 
                dt.Columns.Add(new DataColumn(rdr.GetName(i), rdr.GetFieldType(i))); 
            } 
            while (rdr.Read()) 
            { DataRow row = dt.NewRow(); 
                for (int i = 0; i < rdr.FieldCount; i++)
                { 
                    row[i] = rdr.GetValue(i); 
                } 
                dt.Rows.Add(row); 
            }
            conn.Close(); dataGridView1.DataSource = dt; lbRecordCount1.Text = "Количество записей: " + String.Format("{0}", dt.Rows.Count);
        }
        private void sb_insert_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(((DataTable)dataGridView1.DataSource).NewRow(), false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection("Data Source=EDU-MSSQL2008R2;Initial Catalog=Ip521_SegaAndGera;Integrated Security=True");
                SqlCommand com = new SqlCommand();
                com.Connection = conn;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "Абитуриент_Insert";
                com.Parameters.Add(new SqlParameter("@Фамилия", SqlDbType.VarChar));
                com.Parameters["@Фамилия"].Value = Form2.row["Фамилия"];
                com.Parameters.Add(new SqlParameter("@Имя", SqlDbType.VarChar));
                com.Parameters["@Имя"].Value = Form2.row["Имя"];
                com.Parameters.Add(new SqlParameter("@Отчество", SqlDbType.VarChar));
                com.Parameters["@Отчество"].Value = Form2.row["Отчество"]; 
                com.Parameters.Add(new SqlParameter("@Статус", SqlDbType.VarChar)); 
                com.Parameters["@Статус"].Value = Form2.row["Статус"];
                com.Parameters.Add(new SqlParameter("@Город", SqlDbType.VarChar));
                com.Parameters["@Город"].Value = Form2.row["Город"];
                conn.Open();
                if (com.ExecuteNonQuery() > 0) { MessageBox.Show("Студент успешно добавлен"); }
                conn.Close(); LoadData(); 
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранного студента?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    int studentId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["Код_абитуриента"].Value);

                    SqlConnection conn = new SqlConnection("Data Source=EDU-MSSQL2008R2;Initial Catalog=Ip521_SegaAndGera;Integrated Security=True");
                    SqlCommand com = new SqlCommand();
                    com.Connection = conn;
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = "Абитуриент_Delete";
                    com.Parameters.Add(new SqlParameter("@Код_абитуриента", SqlDbType.Int));
                    com.Parameters["@Код_абитуриента"].Value = studentId;

                    conn.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Студент успешно удален ");
                    }
                    conn.Close();

                    LoadData();

                    if (dataGridView1.Rows.Count > 0)
                    {
                        if (selectedIndex >= dataGridView1.Rows.Count)
                        {
                            selectedIndex = dataGridView1.Rows.Count - 1;
                        }
                        dataGridView1.Rows[selectedIndex].Selected = true;
                    }
                }
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConString))
            {
                using (SqlCommand cmd = new SqlCommand("Student_Select_faculty", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FacultyId", SqlDbType.Int));
                    cmd.Parameters["@FacultyId"].Value = comboBox1.SelectedValue;

                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(rdr);

                        dataGridView1.DataSource = dt;
                        lbRecordCount1.Text = "Количество записей: " + String.Format("{0} записей", dt.Rows.Count);
                    }
                }
            }




        }
        private void LoadDataComboBox()
        {
            
        }


    }

}
