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
using System.Xml.Linq;

namespace Kursach_SUBD
{
    public partial class InsertFormEmployee : Form
    {
        public InsertFormEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO employees (full_name, position, hire_date, salary, education) VALUES (:name, :position, :hire_date, :salary, :education)", conn);
            command.Parameters.Add(new NpgsqlParameter("name", DbType.String));
            command.Parameters.Add(new NpgsqlParameter("position", DbType.String));
            command.Parameters.Add(new NpgsqlParameter("hire_date", DbType.Date));
            command.Parameters.Add(new NpgsqlParameter("salary", DbType.Decimal));
            command.Parameters.Add(new NpgsqlParameter("education", DbType.String));

            command.Parameters[0].Value = txtName.Text;
            command.Parameters[1].Value = txtPosition.Text;
            command.Parameters[2].Value = dateTimePickerHireDate.Value;
            command.Parameters[3].Value = Convert.ToDecimal(txtSalary.Text);
            command.Parameters[4].Value = txtEducation.Text;

            command.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
