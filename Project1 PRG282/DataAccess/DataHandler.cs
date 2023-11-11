using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project1_PRG282.LogicLayer;
using System.Windows.Forms;
using System.Data;

namespace Project1_PRG282.DataAccess
{
    internal static class DataHandler
    {
        static string connect = "Server = (local); Initial Catalog = PRG281Databse; Integrated Security = SSPI";

        public static void createStudent(Student student)
        {
            String query = $"INSERT INTO Student VALUES ('{student.Name}', '{student.Surname}', '{student.StudentImage}', '{student.DOB1}', '{student.Gender}'," +
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
                MessageBox.Show(ex.Message);
            }
        }
        public static void updateStudent(Student student)
        {
            string query = $"UPDATE Student SET StudentNumber = '{student.Studentnumber}', Name = '{student.Name}', Surname = '{student.Surname}', " +
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
        public static void deleteStudent(int StudentNumber)
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
        public static void searchStudent()
        {
            //JJ
        }

        public static void createModule(Module module)
        {
            String query = $"INSERT INTO Module VALUES ('{module.ModuleCode}', '{module.ModuleName}', '{module.ModuleDescription}', '{module.Links}')";

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

                    MessageBox.Show("Created Module");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void updateModule(Module module)
        {
            string query = $"UPDATE Module SET ModuleCode = '{module.ModuleCode}', ModuleName = '{module.ModuleName}', ModuleDescription = '{module.ModuleDescription}'," +
                $" Links = '{module.Links}'";

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

                    MessageBox.Show("Module Updated");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void deleteModule(int moduleNumber)
        {
            string query = $"Delete from Module Where ModuleNumber = '{moduleNumber}'";

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

                    MessageBox.Show($"Data for Module {moduleNumber} deleted successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void searchModule()
        {
            //JJ
        }

        public static DataTable showStudentData()
        {
            string query = @"SELECT * FROM Student";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            return datatable;
        }

        public static DataTable showModuleData()
        {
            string query = @"SELECT * FROM Modules";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            return datatable;
        }
    }
}
