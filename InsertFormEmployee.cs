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
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; database=Kursach_SUBD; user Id=postgres; password=1234");
            conn.Open();

            // SQL-запрос для вставки данных, включая изображение (photo)
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO employees (full_name, position, hire_date, salary, education, photo) VALUES (:name, :position, :hire_date, :salary, :education, :photo)", conn);

            // Добавляем параметры с их типами
            command.Parameters.Add(new NpgsqlParameter("name", DbType.String));
            command.Parameters.Add(new NpgsqlParameter("position", DbType.String));
            command.Parameters.Add(new NpgsqlParameter("hire_date", DbType.Date));
            command.Parameters.Add(new NpgsqlParameter("salary", DbType.Decimal));
            command.Parameters.Add(new NpgsqlParameter("education", DbType.String));
            command.Parameters.Add(new NpgsqlParameter("photo", DbType.Binary)); 

            command.Parameters[0].Value = txtName.Text;
            command.Parameters[1].Value = txtPosition.Text;
            command.Parameters[2].Value = dateTimePickerHireDate.Value;
            command.Parameters[3].Value = Convert.ToDecimal(txtSalary.Text);
            command.Parameters[4].Value = txtEducation.Text;

            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    command.Parameters[5].Value = ms.ToArray();
                }
            }
            else
            {
                command.Parameters[5].Value = DBNull.Value;
            }
            
            command.ExecuteNonQuery();

            conn.Close();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "All EmbroideryFiles | *.bmp; *.gif; *.jpeg; *.jpg; " + "*.fif;*.fiff;*.png;*.wmf;*.emf" + "|Windows Bitmap (*.bmp)|*.bmp" + "|JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg" + "|Graphics Interchange Format (*.gif)|*.gif" + "|Portable Network Graphics (*.png)|*.png" + "|Tag Embroidery File Format (*.tif)|*.tif;*.tiff";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog1.FileName);
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                pictureBox1.Image = image;
            }
        }

        private void InsertFormEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
