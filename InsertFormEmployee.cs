using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            try
            {
                using (var conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234"))
                {
                    conn.Open();

                    using (var command = new NpgsqlCommand("INSERT INTO employees (last_name, first_name, middle_name, position, hire_date, salary, education, license_expiration, photo) VALUES (:last_name, :first_name, :middle_name, :position, :hire_date, :salary, :education, :license_expiration, :photo)", conn))
                    {
                        command.Parameters.Add(new NpgsqlParameter("last_name", DbType.String) { Value = txtName.Text });
                        command.Parameters.Add(new NpgsqlParameter("first_name", DbType.String) { Value = textBox1.Text });
                        command.Parameters.Add(new NpgsqlParameter("middle_name", DbType.String) { Value = textBox2.Text });
                        command.Parameters.Add(new NpgsqlParameter("position", DbType.String) { Value = txtPosition.Text });
                        command.Parameters.Add(new NpgsqlParameter("hire_date", DbType.Date) { Value = dateTimePickerHireDate.Value });
                        command.Parameters.Add(new NpgsqlParameter("salary", DbType.Decimal) { Value = Convert.ToDecimal(txtSalary.Text) });
                        command.Parameters.Add(new NpgsqlParameter("education", DbType.String) { Value = txtEducation.Text });
                        command.Parameters.Add(new NpgsqlParameter("license_expiration", DbType.Date) { Value = dateTimePicker1.Value });

                        if (pictureBox1.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                                command.Parameters.Add(new NpgsqlParameter("photo", DbType.Binary) { Value = ms.ToArray() });
                            }
                        }
                        else
                        {
                            command.Parameters.Add(new NpgsqlParameter("photo", DbType.Binary) { Value = DBNull.Value });
                        }

                        command.ExecuteNonQuery();
                        MessageBox.Show("Сотрудник успешно добавлен.");
                    }
                }

                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ошибка в формате данных: " + ex.Message);
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Filter = "All EmbroideryFiles | *.bmp; *.gif; *.jpeg; *.jpg; " +
                                         "*.fif;*.fiff;*.png;*.wmf;*.emf" +
                                         "|Windows Bitmap (*.bmp)|*.bmp" +
                                         "|JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg" +
                                         "|Graphics Interchange Format (*.gif)|*.gif" +
                                         "|Portable Network Graphics (*.png)|*.png" +
                                         "|Tag Embroidery File Format (*.tif)|*.tif;*.tiff";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = image;
                }
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Ошибка: выбранный файл не является допустимым изображением. " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void InsertFormEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
