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
    public partial class InsertFormContract : Form
    {
        public InsertFormContract()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    conn.Open();

                    using (var insertClientCommand = new NpgsqlCommand("INSERT INTO clients (client_type, address, account_number, representative_name, phone_number, service_type) VALUES (:client_type, :address, :account_number, :representative_name, :phone_number, :service_type) RETURNING client_id", conn))
                    {
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("client_type", DbType.String) { Value = txtClientType.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("address", DbType.String) { Value = txtClientAddress.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("account_number", DbType.String) { Value = txtClientAccountNumber.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("representative_name", DbType.String) { Value = txtClientRepresentative.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("phone_number", DbType.String) { Value = txtClientPhoneNumber.Text });
                        insertClientCommand.Parameters.Add(new NpgsqlParameter("service_type", DbType.String) { Value = txtServiceType.Text });

                        int clientId = Convert.ToInt32(insertClientCommand.ExecuteScalar());

                        using (var insertServiceCommand = new NpgsqlCommand("INSERT INTO services (service_name, service_cost) VALUES (:service_name, :service_cost) RETURNING service_id", conn))
                        {
                            insertServiceCommand.Parameters.Add(new NpgsqlParameter("service_name", DbType.String) { Value = txtServiceName.Text });
                            insertServiceCommand.Parameters.Add(new NpgsqlParameter("service_cost", DbType.Decimal) { Value = Convert.ToDecimal(txtServiceCost.Text) });

                            int serviceId = Convert.ToInt32(insertServiceCommand.ExecuteScalar());

                            using (var insertContractCommand = new NpgsqlCommand("INSERT INTO contracts (client_id, service_id, employee_id, order_date, revenue) VALUES (:client_id, :service_id, :employee_id, :order_date, :revenue)", conn))
                            {
                                insertContractCommand.Parameters.Add(new NpgsqlParameter("client_id", DbType.Int32) { Value = clientId });
                                insertContractCommand.Parameters.Add(new NpgsqlParameter("service_id", DbType.Int32) { Value = serviceId });
                                insertContractCommand.Parameters.Add(new NpgsqlParameter("employee_id", DbType.Int32) { Value = Convert.ToInt32(txtEmployeeId.Text) });
                                insertContractCommand.Parameters.Add(new NpgsqlParameter("order_date", DbType.Date) { Value = dateTimePickerOrderDate.Value });
                                insertContractCommand.Parameters.Add(new NpgsqlParameter("revenue", DbType.Decimal) { Value = Convert.ToDecimal(txtRevenue.Text) });

                                insertContractCommand.ExecuteNonQuery();
                                MessageBox.Show("Контракт успешно добавлен.");
                            }
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InsertFormContract_Load(object sender, EventArgs e)
        {

        }
    }
}
