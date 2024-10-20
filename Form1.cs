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
            LoadContractData();
            LoadClients();
            LoadServices();
        }

        private void LoadEmployeeData()
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            DataSet dataset = new DataSet();
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM employees", conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(dataset, "employee_table");
            dataGridViewEmployees.DataSource = dataset;
            dataGridViewEmployees.DataMember = "employee_table";
            conn.Close();
        }

        private void LoadContractData()
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            DataSet dataset = new DataSet();
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM contracts", conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            da.Fill(dataset, "contract_table");
            dataGridViewContracts.DataSource = dataset;
            dataGridViewContracts.DataMember = "contract_table";
            conn.Close();
        }

        // Загрузка списка клиентов
        private void LoadClients()
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();

            // SQL-запрос для получения списка клиентов
            string query = "SELECT client_id, client_type, address representative_name, phone_number, account_number, service_type FROM clients ORDER BY representative_name";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            // Набор данных для отображения клиентов
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "clients");

            // Привязка данных к DataGridView
            dataGridViewClients.DataSource = dataSet;
            dataGridViewClients.DataMember = "clients";

            conn.Close();
        }

        // Загрузка списка услуг
        private void LoadServices()
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();

            // SQL-запрос для получения списка услуг
            string query = "SELECT service_id, service_name, service_cost FROM services ORDER BY service_name";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            // Набор данных для отображения услуг
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "services");

            // Привязка данных к DataGridView
            dataGridViewServices.DataSource = dataSet;
            dataGridViewServices.DataMember = "services";

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertFormContract form = new InsertFormContract();
            form.ShowDialog();
            LoadContractData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertFormEmployee form = new InsertFormEmployee();
            form.ShowDialog();
            LoadEmployeeData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Вывод статистики по договорам
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(contract_id), SUM(revenue) FROM contracts", conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show($"Всего договоров: {reader[0]}, Общая выручка: {reader[1]} руб.");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SecurityCallsStatisticsForm form = new SecurityCallsStatisticsForm();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                // Получение выбранного сотрудника
                int selectedEmployeeId = Convert.ToInt32(dataGridViewEmployees.SelectedRows[0].Cells["employee_id"].Value);

                // Подтверждение удаления
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить этого сотрудника?", "Подтверждение удаления", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
                    conn.Open();

                    // SQL-запрос для удаления сотрудника
                    string deleteQuery = "DELETE FROM employees WHERE employee_id = @employee_id";

                    NpgsqlCommand command = new NpgsqlCommand(deleteQuery, conn);
                    command.Parameters.AddWithValue("@employee_id", selectedEmployeeId);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Сотрудник успешно удален.");

                        // Обновление списка сотрудников после удаления
                        LoadEmployeeData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении сотрудника: " + ex.Message);
                    }

                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
            }
        }
    }
}
