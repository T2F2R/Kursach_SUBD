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
            LoadSServiceData();
            LoadMServiceData();
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

        private void LoadSServiceData()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    DataSet dataset = new DataSet();
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM s_services", conn);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dataset, "s_service_table");
                    dataGridViewContracts.DataSource = dataset;
                    dataGridViewContracts.DataMember = "s_service_table";

                    if (dataGridViewContracts.Columns["service_id"] != null)
                    {
                        dataGridViewContracts.Columns["service_id"].Visible = false;
                    }
                    if (dataGridViewContracts.Columns["client_id"] != null)
                    {
                        dataGridViewContracts.Columns["client_id"].Visible = false;
                    }
                    if (dataGridViewContracts.Columns["service_type"] != null)
                    {
                        dataGridViewContracts.Columns["service_type"].HeaderText = "Тип заказа";
                    }
                    if (dataGridViewContracts.Columns["cost"] != null)
                    {
                        dataGridViewContracts.Columns["cost"].HeaderText = "Цена";
                    }
                    if (dataGridViewContracts.Columns["order_date"] != null)
                    {
                        dataGridViewContracts.Columns["order_date"].HeaderText = "Дата начала";
                    }
                    if (dataGridViewContracts.Columns["completion_date"] != null)
                    {
                        dataGridViewContracts.Columns["completion_date"].HeaderText = "Дата окончания";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных по договорам: " + ex.Message);
                }
            }
        }

        private void LoadMServiceData()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    DataSet dataset = new DataSet();
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM m_services", conn);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
                    da.Fill(dataset, "m_service_table");
                    dataGridViewContracts1.DataSource = dataset;
                    dataGridViewContracts1.DataMember = "m_service_table";

                    if (dataGridViewContracts1.Columns["service_id"] != null)
                    {
                        dataGridViewContracts1.Columns["service_id"].Visible = false;
                    }
                    if (dataGridViewContracts1.Columns["client_id"] != null)
                    {
                        dataGridViewContracts1.Columns["client_id"].Visible = false;
                    }
                    if (dataGridViewContracts1.Columns["service_type"] != null)
                    {
                        dataGridViewContracts1.Columns["service_type"].HeaderText = "Тип заказа";
                    }
                    if (dataGridViewContracts1.Columns["cost"] != null)
                    {
                        dataGridViewContracts1.Columns["cost"].HeaderText = "Цена";
                    }
                    if (dataGridViewContracts1.Columns["order_date"] != null)
                    {
                        dataGridViewContracts1.Columns["order_date"].HeaderText = "Дата начала";
                    }
                    if (dataGridViewContracts1.Columns["completion_date"] != null)
                    {
                        dataGridViewContracts1.Columns["completion_date"].HeaderText = "Дата окончания";
                    }
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

                    if (dataGridViewClients.Columns["client_id"] != null)
                    {
                        dataGridViewClients.Columns["client_id"].Visible = false;
                    }
                    if (dataGridViewClients.Columns["address"] != null)
                    {
                        dataGridViewClients.Columns["address"].HeaderText = "Адрес";
                    }
                    if (dataGridViewClients.Columns["account_number"] != null)
                    {
                        dataGridViewClients.Columns["account_number"].HeaderText = "Номер счета";
                    }
                    if (dataGridViewClients.Columns["representative_last_name"] != null)
                    {
                        dataGridViewClients.Columns["representative_last_name"].HeaderText = "Фамилия";
                    }
                    if (dataGridViewClients.Columns["representative_first_name"] != null)
                    {
                        dataGridViewClients.Columns["representative_first_name"].HeaderText = "Имя";
                    }
                    if (dataGridViewClients.Columns["representative_middle_name"] != null)
                    {
                        dataGridViewClients.Columns["representative_middle_name"].HeaderText = "Отчество";
                    }
                    if (dataGridViewClients.Columns["phone_number"] != null)
                    {
                        dataGridViewClients.Columns["phone_number"].HeaderText = "Номер телефона";
                    }
                    if (dataGridViewClients.Columns["service_type"] != null)
                    {
                        dataGridViewClients.Columns["service_type"].HeaderText = "Тип заказа";
                    }
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

                    if (dataGridViewServices.Columns["schedule_id"] != null)
                    {
                        dataGridViewServices.Columns["schedule_id"].Visible = false;
                    }
                    if (dataGridViewServices.Columns["employee_id"] != null)
                    {
                        dataGridViewServices.Columns["employee_id"].Visible = false;
                    }
                    if (dataGridViewServices.Columns["shift_start"] != null)
                    {
                        dataGridViewServices.Columns["shift_start"].HeaderText = "Дата начала";
                    }
                    if (dataGridViewServices.Columns["shift_end"] != null)
                    {
                        dataGridViewServices.Columns["shift_end"].HeaderText = "Дата окончания";
                    }
                    if (dataGridViewServices.Columns["location"] != null)
                    {
                        dataGridViewServices.Columns["location"].HeaderText = "Местоположение";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных расписания: " + ex.Message);
                }
            }
        }

        private void CheckLicenseExpiration()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    employee_id, 
                    last_name, 
                    first_name, 
                    middle_name, 
                    license_expiration 
                FROM employees 
                WHERE license_expiration BETWEEN CURRENT_DATE AND CURRENT_DATE + INTERVAL '7 days'";

                    NpgsqlCommand command = new NpgsqlCommand(query, conn);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    StringBuilder notificationBuilder = new StringBuilder();
                    notificationBuilder.AppendLine("Сотрудники с истекающими лицензиями (на следующей неделе):\n");

                    while (reader.Read())
                    {
                        string employeeInfo = $"{reader["last_name"]} {reader["first_name"]} {reader["middle_name"]}, срок действия лицензии: {((DateTime)reader["license_expiration"]).ToShortDateString()}";
                        notificationBuilder.AppendLine(employeeInfo);
                    }

                    richTextBoxNotifications.Text = notificationBuilder.ToString();

                    if (notificationBuilder.Length > 0)
                    {
                        MessageBox.Show("Обновлен список сотрудников с истекающими лицензиями.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при проверке лицензий сотрудников: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertFormContract form = new InsertFormContract();
            form.ShowDialog();
            LoadEmployeeData();
            LoadSServiceData();
            LoadMServiceData();
            LoadClients();
            LoadSchedules();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertFormEmployee form = new InsertFormEmployee();
            form.ShowDialog();
            LoadEmployeeData();
            LoadSServiceData();
            LoadMServiceData();
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
                    NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(service_id) AS total_services, SUM(cost) AS total_cost FROM (SELECT service_id, cost FROM s_services UNION ALL SELECT service_id, cost FROM m_services) AS combined_services;", conn);
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
                    NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) AS calls_count FROM s_services;", conn);
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
            LoadSServiceData();
            LoadMServiceData();
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridViewContracts.SelectedRows.Count > 0)
            {
                int selectedServiceId = Convert.ToInt32(dataGridViewContracts.SelectedRows[0].Cells["service_id"].Value);

                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    try
                    {
                        conn.Open();
                        string query = @"
                    SELECT e.employee_id, e.last_name, e.first_name, e.middle_name, e.position 
                    FROM employees e
                    INNER JOIN s_service_employee se ON e.employee_id = se.employee_id
                    WHERE se.service_id = @service_id";

                        NpgsqlCommand command = new NpgsqlCommand(query, conn);
                        command.Parameters.AddWithValue("@service_id", selectedServiceId);

                        DataTable employeeTable = new DataTable();
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(employeeTable);
                        }

                        StringBuilder employeeList = new StringBuilder("Сотрудники, связанные с заказом:\n\n");
                        foreach (DataRow row in employeeTable.Rows)
                        {
                            employeeList.AppendLine($"{row["last_name"]} {row["first_name"]} {row["middle_name"]}, {row["position"]}");
                        }

                        MessageBox.Show(employeeList.ToString(), "Список сотрудников");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при получении списка сотрудников: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для просмотра сотрудников.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            InsertFormContract1 form = new InsertFormContract1();
            form.ShowDialog();
            LoadEmployeeData();
            LoadSServiceData();
            LoadMServiceData();
            LoadClients();
            LoadSchedules();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridViewContracts1.SelectedRows.Count > 0)
            {
                int selectedServiceId = Convert.ToInt32(dataGridViewContracts1.SelectedRows[0].Cells["service_id"].Value);

                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    try
                    {
                        conn.Open();
                        string query = @"
                    SELECT e.employee_id, e.last_name, e.first_name, e.middle_name, e.position 
                    FROM employees e
                    INNER JOIN m_service_employee se ON e.employee_id = se.employee_id
                    WHERE se.service_id = @service_id";

                        NpgsqlCommand command = new NpgsqlCommand(query, conn);
                        command.Parameters.AddWithValue("@service_id", selectedServiceId);

                        DataTable employeeTable = new DataTable();
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(employeeTable);
                        }

                        StringBuilder employeeList = new StringBuilder("Сотрудники, связанные с заказом:\n\n");
                        foreach (DataRow row in employeeTable.Rows)
                        {
                            employeeList.AppendLine($"{row["last_name"]} {row["first_name"]} {row["middle_name"]}, {row["position"]}");
                        }

                        MessageBox.Show(employeeList.ToString(), "Список сотрудников");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при получении списка сотрудников: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для просмотра сотрудников.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckLicenseExpiration();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}