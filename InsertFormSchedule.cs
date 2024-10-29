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
    public partial class InsertFormSchedule : Form
    {
        private int employeeId;
        public InsertFormSchedule(int selectedEmployeeId)
        {
            InitializeComponent();
            employeeId = selectedEmployeeId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime shiftStart = dateTimePickerShiftStart.Value;
            DateTime shiftEnd = dateTimePickerShiftEnd.Value;
            string location = textBoxLocation.Text;

            using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO schedules (employee_id, shift_start, shift_end, location) VALUES (@employee_id, @shift_start, @shift_end, @location)";
                    using (var command = new NpgsqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("employee_id", employeeId);
                        command.Parameters.AddWithValue("shift_start", shiftStart);
                        command.Parameters.AddWithValue("shift_end", shiftEnd);
                        command.Parameters.AddWithValue("location", location);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Расписание успешно добавлено.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении расписания: " + ex.Message);
                }
            }
        }
    }
}
