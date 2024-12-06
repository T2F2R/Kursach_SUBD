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
    public partial class InsertFormContract1 : Form
    {
        public InsertFormContract1()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT employee_id, last_name || ' ' || first_name AS full_name FROM employees WHERE position = 'установщик оборудования';";
                    NpgsqlCommand command = new NpgsqlCommand(query, conn);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        checkedListBox1.Items.Add(new { Text = reader["full_name"].ToString(), Value = reader["employee_id"] });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки сотрудников: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    conn.Open();

                    // Создание клиента
                    using (var insertClientCommand = new NpgsqlCommand("INSERT INTO clients (address, account_number, representative_last_name, representative_first_name, representative_middle_name, phone_number, service_type) VALUES (:address, :account_number, :representative_last_name, :representative_first_name, :representative_middle_name, :phone_number, :service_type) RETURNING client_id", conn))
                    {
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("address", DbType.String) { Value = txtClientAddress.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("account_number", DbType.String) { Value = txtClientAccountNumber.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("representative_last_name", DbType.String) { Value = txtClientRepresentative.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("representative_first_name", DbType.String) { Value = txtClientRepresentative.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("representative_middle_name", DbType.String) { Value = textBox2.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("phone_number", DbType.String) { Value = txtClientPhoneNumber.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("service_type", DbType.String) { Value = txtServiceType.Text });

                        int clientId = Convert.ToInt32(insertClientCommand.ExecuteScalar());

                        // Создание заказа только один раз
                        using (var insertServiceCommand = new NpgsqlCommand("INSERT INTO m_services (service_type, cost, client_id, order_date, completion_date) VALUES (:service_type, :cost, :client_id, :order_date, :completion_date) RETURNING service_id", conn))
                        {
                            insertServiceCommand.Parameters.Add(new NpgsqlParameter("service_type", DbType.String) { Value = txtServiceType.Text });
                            insertServiceCommand.Parameters.Add(new NpgsqlParameter("cost", DbType.Decimal) { Value = Convert.ToDecimal(txtServiceCost.Text) });
                            insertServiceCommand.Parameters.Add(new NpgsqlParameter("client_id", DbType.Int32) { Value = clientId });
                            insertServiceCommand.Parameters.Add(new NpgsqlParameter("order_date", DbType.Date) { Value = dateTimePickerOrderDate.Value });
                            insertServiceCommand.Parameters.Add(new NpgsqlParameter("completion_date", DbType.Date) { Value = dateTimePicker1.Value });

                            int serviceId = Convert.ToInt32(insertServiceCommand.ExecuteScalar());

                            // Привязка выбранных сотрудников к одному созданному заказу
                            foreach (var item in checkedListBox1.CheckedItems)
                            {
                                int employeeId = (int)(item as dynamic).Value;
                                var insertEmployeeCommand = new NpgsqlCommand("INSERT INTO m_service_employee (service_id, employee_id) VALUES (:service_id, :employee_id)", conn);
                                insertEmployeeCommand.Parameters.AddWithValue("service_id", serviceId);
                                insertEmployeeCommand.Parameters.AddWithValue("employee_id", employeeId);
                                insertEmployeeCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Контракт успешно добавлен с выбранными сотрудниками.");
                        }
                    }
                }
                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ошибка: некорректный формат данных. Проверьте правильность введенных значений. " + ex.Message);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных или выполнения команды: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Ошибка при работе с базой данных: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка: " + ex.Message);
            }
        }
    }
}
