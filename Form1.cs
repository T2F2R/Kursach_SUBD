using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_SUBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            LoadServiceData();
            LoadClients();
            LoadSchedules();
        }

        private void LoadEmployeeData()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    DataSet dataset = new DataSet();
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM employees", conn);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dataset, "employee_table");
                    dataGridViewEmployees.DataSource = dataset;
                    dataGridViewEmployees.DataMember = "employee_table";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных сотрудников: " + ex.Message);
                }
            }
        }

        private void LoadServiceData()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    DataSet dataset = new DataSet();
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM services", conn);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dataset, "service_table");
                    dataGridViewContracts.DataSource = dataset;
                    dataGridViewContracts.DataMember = "service_table";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных по договорам: " + ex.Message);
                }
            }
        }

        private void LoadClients()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM clients";
                    NpgsqlCommand command = new NpgsqlCommand(query, conn);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "clients");
                    dataGridViewClients.DataSource = dataSet;
                    dataGridViewClients.DataMember = "clients";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных клиентов: " + ex.Message);
                }
            }
        }

        private void LoadSchedules()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM schedules";
                    NpgsqlCommand command = new NpgsqlCommand(query, conn);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "schedules");
                    dataGridViewServices.DataSource = dataSet;
                    dataGridViewServices.DataMember = "schedules";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных расписания: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertFormContract form = new InsertFormContract();
            form.ShowDialog();
            LoadEmployeeData();
            LoadServiceData();
            LoadClients();
            LoadSchedules();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertFormEmployee form = new InsertFormEmployee();
            form.ShowDialog();
            LoadEmployeeData();
            LoadServiceData();
            LoadClients();
            LoadSchedules();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(service_id), SUM(cost) FROM services", conn);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show($"Всего договоров: {reader[0]}, Общая выручка: {reader[1]} руб.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении статистики по договорам: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) AS calls_count FROM services WHERE service_type = 'охрана объекта';", conn);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show($"Всего вызовов охраны: {reader[0]}.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении статистики вызовов охраны: " + ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridViewEmployees.SelectedRows.Count > 0)
            {
                int selectedEmployeeId = Convert.ToInt32(dataGridViewEmployees.SelectedRows[0].Cells["employee_id"].Value);
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить этого сотрудника?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                    {
                        try
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM employees WHERE employee_id = @employee_id";
                            NpgsqlCommand command = new NpgsqlCommand(deleteQuery, conn);
                            command.Parameters.AddWithValue("@employee_id", selectedEmployeeId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Сотрудник успешно удален.");
                            LoadEmployeeData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при удалении сотрудника: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
            }

            LoadEmployeeData();
            LoadServiceData();
            LoadClients();
            LoadSchedules();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) AS employee_count FROM employees;", conn);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show($"Всего сотрудников: {reader[0]}.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении статистики по договорам: " + ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                int selectedEmployeeId = Convert.ToInt32(dataGridViewEmployees.SelectedRows[0].Cells["employee_id"].Value);
                InsertFormSchedule form = new InsertFormSchedule(selectedEmployeeId);
                form.ShowDialog();
                LoadSchedules();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для добавления расписания.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                int selectedScheduleId = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["schedule_id"].Value);
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить это расписание?", "Подтверждение удаления", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                    {
                        try
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM schedules WHERE schedule_id = @schedule_id";
                            NpgsqlCommand command = new NpgsqlCommand(deleteQuery, conn);
                            command.Parameters.AddWithValue("schedule_id", selectedScheduleId);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Расписание успешно удалено.");
                            LoadSchedules();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при удалении расписания: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите расписание для удаления.");
            }
        }
    }
}
