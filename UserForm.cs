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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            LoadEmployeeData();
            LoadSchedules();
            LoadOrders();
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

                    if (dataGridViewEmployees.Columns["employee_id"] != null)
                    {
                        dataGridViewEmployees.Columns["employee_id"].Visible = false;
                    }
                    if (dataGridViewEmployees.Columns["first_name"] != null)
                    {
                        dataGridViewEmployees.Columns["first_name"].HeaderText = "Имя";
                    }
                    if (dataGridViewEmployees.Columns["last_name"] != null)
                    {
                        dataGridViewEmployees.Columns["last_name"].HeaderText = "Фамилия";
                    }
                    if (dataGridViewEmployees.Columns["middle_name"] != null)
                    {
                        dataGridViewEmployees.Columns["middle_name"].HeaderText = "Отчество";
                    }
                    if (dataGridViewEmployees.Columns["position"] != null)
                    {
                        dataGridViewEmployees.Columns["position"].HeaderText = "Должность";
                    }
                    if (dataGridViewEmployees.Columns["hire_date"] != null)
                    {
                        dataGridViewEmployees.Columns["hire_date"].HeaderText = "Дата принятия на должность";
                    }
                    if (dataGridViewEmployees.Columns["education"] != null)
                    {
                        dataGridViewEmployees.Columns["education"].HeaderText = "Образование";
                    }
                    if (dataGridViewEmployees.Columns["license_expiration"] != null)
                    {
                        dataGridViewEmployees.Columns["license_expiration"].HeaderText = "Лицензия";
                    }
                    if (dataGridViewEmployees.Columns["photo"] != null)
                    {
                        dataGridViewEmployees.Columns["photo"].HeaderText = "Фото";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных сотрудников: " + ex.Message);
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
                    dataGridViewSchedules.DataSource = dataSet;
                    dataGridViewSchedules.DataMember = "schedules";

                    if (dataGridViewSchedules.Columns["schedule_id"] != null)
                    {
                        dataGridViewSchedules.Columns["schedule_id"].Visible = false;
                    }
                    if (dataGridViewSchedules.Columns["employee_id"] != null)
                    {
                        dataGridViewSchedules.Columns["employee_id"].Visible = false;
                    }
                    if (dataGridViewSchedules.Columns["shift_start"] != null)
                    {
                        dataGridViewSchedules.Columns["shift_start"].HeaderText = "Дата начала";
                    }
                    if (dataGridViewSchedules.Columns["shift_end"] != null)
                    {
                        dataGridViewSchedules.Columns["shift_end"].HeaderText = "Дата окончания";
                    }
                    if (dataGridViewSchedules.Columns["location"] != null)
                    {
                        dataGridViewSchedules.Columns["location"].HeaderText = "Местоположение";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных расписания: " + ex.Message);
                }
            }
        }

        private void LoadOrders()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM s_services UNION SELECT * FROM m_services", conn);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewOrders.DataSource = dataTable;

                    if (dataGridViewOrders.Columns["service_id"] != null)
                    {
                        dataGridViewOrders.Columns["service_id"].Visible = false;
                    }
                    if (dataGridViewOrders.Columns["client_id"] != null)
                    {
                        dataGridViewOrders.Columns["client_id"].Visible = false;
                    }
                    if (dataGridViewOrders.Columns["service_type"] != null)
                    {
                        dataGridViewOrders.Columns["service_type"].HeaderText = "Тип заказа";
                    }
                    if (dataGridViewOrders.Columns["cost"] != null)
                    {
                        dataGridViewOrders.Columns["cost"].HeaderText = "Цена";
                    }
                    if (dataGridViewOrders.Columns["order_date"] != null)
                    {
                        dataGridViewOrders.Columns["order_date"].HeaderText = "Дата начала";
                    }
                    if (dataGridViewOrders.Columns["completion_date"] != null)
                    {
                        dataGridViewOrders.Columns["completion_date"].HeaderText = "Дата окончания";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных заказов: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                int selectedEmployeeId = Convert.ToInt32(dataGridViewEmployees.SelectedRows[0].Cells["employee_id"].Value);

                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    try
                    {
                        conn.Open();

                        string query = @"SELECT shift_start, shift_end, location FROM schedules WHERE employee_id = @employee_id";

                        NpgsqlCommand command = new NpgsqlCommand(query, conn);
                        command.Parameters.AddWithValue("@employee_id", selectedEmployeeId);

                        DataTable scheduleTable = new DataTable();
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(scheduleTable);
                        }

                        if (scheduleTable.Rows.Count > 0)
                        {
                            dataGridViewSchedules.DataSource = scheduleTable;
                        }
                        else
                        {
                            MessageBox.Show("У выбранного сотрудника нет расписания.", "Информация");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при получении расписания: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для просмотра расписания.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
