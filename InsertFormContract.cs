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
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();

            // Сначала добавляем информацию о заказчике
            NpgsqlCommand insertClientCommand = new NpgsqlCommand("INSERT INTO clients (client_type, address, account_number, representative_name, phone_number, service_type) VALUES (:client_type, :address, :account_number, :representative_name, :phone_number, :service_type) RETURNING client_id", conn);
            insertClientCommand.Parameters.Add(new NpgsqlParameter("client_type", DbType.String));
            insertClientCommand.Parameters.Add(new NpgsqlParameter("address", DbType.String));
            insertClientCommand.Parameters.Add(new NpgsqlParameter("account_number", DbType.String));
            insertClientCommand.Parameters.Add(new NpgsqlParameter("representative_name", DbType.String));
            insertClientCommand.Parameters.Add(new NpgsqlParameter("phone_number", DbType.String));
            insertClientCommand.Parameters.Add(new NpgsqlParameter("service_type", DbType.String));

            insertClientCommand.Parameters[0].Value = txtClientType.Text;
            insertClientCommand.Parameters[1].Value = txtClientAddress.Text;
            insertClientCommand.Parameters[2].Value = txtClientAccountNumber.Text;
            insertClientCommand.Parameters[3].Value = txtClientRepresentative.Text;
            insertClientCommand.Parameters[4].Value = txtClientPhoneNumber.Text;
            insertClientCommand.Parameters[5].Value = txtServiceType.Text;

            // Получаем сгенерированный идентификатор нового клиента
            int clientId = Convert.ToInt32(insertClientCommand.ExecuteScalar());

            // Далее добавляем информацию об услуге
            NpgsqlCommand insertServiceCommand = new NpgsqlCommand("INSERT INTO services (service_name, service_cost) VALUES (:service_name, :service_cost) RETURNING service_id", conn);
            insertServiceCommand.Parameters.Add(new NpgsqlParameter("service_name", DbType.String));
            insertServiceCommand.Parameters.Add(new NpgsqlParameter("service_cost", DbType.Decimal));

            insertServiceCommand.Parameters[0].Value = txtServiceName.Text;
            insertServiceCommand.Parameters[1].Value = Convert.ToDecimal(txtServiceCost.Text);

            // Получаем сгенерированный идентификатор новой услуги
            int serviceId = Convert.ToInt32(insertServiceCommand.ExecuteScalar());

            // Теперь создаем контракт, ссылаясь на нового клиента и услугу
            NpgsqlCommand insertContractCommand = new NpgsqlCommand("INSERT INTO contracts (client_id, service_id, employee_id, order_date, revenue) VALUES (:client_id, :service_id, :employee_id, :order_date, :revenue)", conn);
            insertContractCommand.Parameters.Add(new NpgsqlParameter("client_id", DbType.Int32));
            insertContractCommand.Parameters.Add(new NpgsqlParameter("service_id", DbType.Int32));
            insertContractCommand.Parameters.Add(new NpgsqlParameter("employee_id", DbType.Int32));
            insertContractCommand.Parameters.Add(new NpgsqlParameter("order_date", DbType.Date));
            insertContractCommand.Parameters.Add(new NpgsqlParameter("revenue", DbType.Decimal));

            insertContractCommand.Parameters[0].Value = clientId;
            insertContractCommand.Parameters[1].Value = serviceId;
            insertContractCommand.Parameters[2].Value = Convert.ToInt32(txtEmployeeId.Text);
            insertContractCommand.Parameters[3].Value = dateTimePickerOrderDate.Value;
            insertContractCommand.Parameters[4].Value = Convert.ToDecimal(txtRevenue.Text);

            insertContractCommand.ExecuteNonQuery();

            // Закрываем соединение
            conn.Close();

            // Закрываем форму после сохранения данных
            this.Close();
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
