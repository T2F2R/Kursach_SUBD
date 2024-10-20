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
    public partial class SecurityCallsStatisticsForm : Form
    {
        public SecurityCallsStatisticsForm()
        {
            InitializeComponent();
        }

        private void SecurityCallsStatisticsForm_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();

            // SQL-запрос для выборки всех вызовов охраны
            string query = "SELECT sc.call_id, c.representative_name, sc.call_date, sc.response_time " +
                           "FROM security_calls sc " +
                           "JOIN clients c ON sc.client_id = c.client_id " +
                           "ORDER BY sc.call_date DESC";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            // Набор данных для отображения вызовов охраны
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "security_calls");

            // Привязка данных к DataGridView
            dataGridViewSecurityCalls.DataSource = dataSet;
            dataGridViewSecurityCalls.DataMember = "security_calls";

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();

            // SQL-запрос с фильтрацией по диапазону дат
            string query = "SELECT sc.call_id, c.representative_name, sc.call_date, sc.response_time " +
                           "FROM security_calls sc " +
                           "JOIN clients c ON sc.client_id = c.client_id " +
                           "WHERE sc.call_date BETWEEN :start_date AND :end_date " +
                           "ORDER BY sc.call_date DESC";

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.Parameters.Add(new NpgsqlParameter("start_date", DbType.Date));
            command.Parameters.Add(new NpgsqlParameter("end_date", DbType.Date));
            command.Parameters[0].Value = startDate;
            command.Parameters[1].Value = endDate;

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "security_calls_filtered");

            // Привязка отфильтрованных данных к DataGridView
            dataGridViewSecurityCalls.DataSource = dataSet;
            dataGridViewSecurityCalls.DataMember = "security_calls_filtered";

            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
