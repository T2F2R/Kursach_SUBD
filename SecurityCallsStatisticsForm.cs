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
            try
            {
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    conn.Open();

                    string query = "SELECT sc.call_id, c.representative_name, sc.call_date, sc.response_time " +
                                   "FROM security_calls sc " +
                                   "JOIN clients c ON sc.client_id = c.client_id " +
                                   "ORDER BY sc.call_date DESC";

                    using (var command = new NpgsqlCommand(query, conn))
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "security_calls");

                        dataGridViewSecurityCalls.DataSource = dataSet;
                        dataGridViewSecurityCalls.DataMember = "security_calls";
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных или выполнения SQL-запроса: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePickerStart.Value;
                DateTime endDate = dateTimePickerEnd.Value;

                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    conn.Open();

                    string query = "SELECT sc.call_id, c.representative_name, sc.call_date, sc.response_time " +
                                   "FROM security_calls sc " +
                                   "JOIN clients c ON sc.client_id = c.client_id " +
                                   "WHERE sc.call_date BETWEEN :start_date AND :end_date " +
                                   "ORDER BY sc.call_date DESC";

                    using (var command = new NpgsqlCommand(query, conn))
                    {
                        command.Parameters.Add(new NpgsqlParameter("start_date", DbType.Date) { Value = startDate });
                        command.Parameters.Add(new NpgsqlParameter("end_date", DbType.Date) { Value = endDate });

                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "security_calls_filtered");

                            dataGridViewSecurityCalls.DataSource = dataSet;
                            dataGridViewSecurityCalls.DataMember = "security_calls_filtered";
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных или выполнения SQL-запроса: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ошибка формата данных. Проверьте введенные значения: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
