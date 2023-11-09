using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project1_PRG282.LogicLayer;
using System.Windows.Forms;

namespace Project1_PRG282.DataAccess
{
    internal class DataHandler
    {
        string connect = "Server = (local); Initial Catalog = PRG281Databse; Integrated Security = SSPI";

        public void createStudent(Student student)
        {
            String query = $"INSERT INTO Student VALUES ('{student.Studentnumber}', '{student.Name}', '{student.Surname}', '{student.StudentImage}', '{student.DOB1}', '{student.Gender}'," +
                $" '{student.Phone}', '{student.Address}', '{student.ModuleCode}' )";

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    using(SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Created Student");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateStudent(Student student)
        {
            string query = $"UPDATE Student SET StudentNumber = {student.Studentnumber}', Name = '{student.Name}', Surname = '{student.Surname}', " +
                $"StudentImage = '{student.StudentImage}', DOB = '{student.DOB1}', Gender = '{student.Gender}'," +
                $" Phone = '{student.Phone}', Address = '{student.Address}', ModuleCode = '{student.ModuleCode}'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Student Updated");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void deleteStudent( int StudentNumber)
        {
            string query = $"Delete from Student Where StudentNumber = '{StudentNumber}'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show($"Data for student {StudentNumber} deleted successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void searchStudent()
        {

        }
    }
}
