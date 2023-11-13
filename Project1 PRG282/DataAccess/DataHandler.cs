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
        //connects to the database

        public static void createStudent(Student student)
        {
            String query = $"INSERT INTO Student VALUES ('{student.Name}', '{student.Surname}', '{student.StudentImage}', '{student.DOB1}', '{student.Gender}'," +
                $" '{student.Phone}', '{student.Address}', '{student.ModuleCode}' )";
            //the query to insert all the values into the table

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))//connects to the string connect
                {
                    conn.Open();//opens the connection

                    using(SqlCommand command = new SqlCommand(query, conn))//connects the query to the sqlconnection
                    {
                        command.ExecuteNonQuery();//executes the query
                        conn.Close();//closes the connection
                    }

                    MessageBox.Show("Created Student");//dislpays if the student was created
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//displays if the student was not created
            }
        }
        public static void updateStudent(Student student)
        {
            string query = $"UPDATE Student SET Name = '{student.Name}', Surname = '{student.Surname}', " +
                $"StudentImage = '{student.StudentImage}', DOB = '{student.DOB1}', Gender = '{student.Gender}'," +
                $" Phone = '{student.Phone}', Address = '{student.Address}' WHERE StudentNumber = '{student.Studentnumber}'";
            //the query to update all the values 

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))//connects to the string connect
                {
                    conn.Open();//opens the connection

                    using (SqlCommand command = new SqlCommand(query, conn))//connects the query to the sqlconnection
                    {
                        command.ExecuteNonQuery();//executes the query
                        conn.Close();//closes the connection
                    }

                    MessageBox.Show("Student Updated");//dislpays if the student was updated
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);//displays if the student was not updated
            }
        }
        public static void deleteStudent(int StudentNumber)
        {
            string query = $"Delete from Student Where StudentNumber = '{StudentNumber}'";
            //the query to delete all the values

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))//connects to the string connect
                {
                    conn.Open();//opens the connection

                    using (SqlCommand command = new SqlCommand(query, conn))//connects the query to the sqlconnection
                    {
                        command.ExecuteNonQuery();//executes the query
                        conn.Close();//closes the connection
                    }

                    MessageBox.Show($"Data for student {StudentNumber} deleted successfully");//dislpays if the student was deleted
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);//displays if the student was not deleted
            }
        }
        public static DataTable searchStudent(string search)
        {
            string query = @"SELECT *
                    FROM Student
                    WHERE Name LIKE @Search
                       OR Surname LIKE @Search
                       OR StudentImage LIKE @Search
                       OR CONVERT(VARCHAR, DOB, 23) LIKE @Search
                       OR Gender LIKE @Search
                       OR Phone LIKE @Search
                       OR Address LIKE @Search
                       OR ModuleCode LIKE @Search";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Use SqlParameter to safely handle the search parameter
                    command.Parameters.AddWithValue("@Search", "%" + search + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static void createModule(Module module)
        {
            String query = $"INSERT INTO Module VALUES ('{module.ModuleCode}', '{module.ModuleName}', '{module.ModuleDescription}', '{module.Links}')";
            //the query to insert all the values

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))//connects to the string connect
                {
                    conn.Open();//opens the connection

                    using (SqlCommand command = new SqlCommand(query, conn))//connects the query to the sqlconnection
                    {
                        command.ExecuteNonQuery();//executes the query
                        conn.Close();//closes the connection
                    }

                    MessageBox.Show("Created Module");//dislpays if the module was created
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//displays if the module was not created
            }
        }

        public static void updateModule(Module module)
        {
            string query = $"UPDATE Module SET ModuleCode = '{module.ModuleCode}', ModuleName = '{module.ModuleName}', ModuleDescription = '{module.ModuleDescription}'," +
                $" Links = '{module.Links}'";
            //the query to update all the values

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))//connects to the string connect
                {
                    conn.Open();//opens the connection

                    using (SqlCommand command = new SqlCommand(query, conn))//connects the query to the sqlconnection
                    {
                        command.ExecuteNonQuery();//executes the query
                        conn.Close();//closes the connection
                    }

                    MessageBox.Show("Module Updated");//dislpays if the module was updated
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);//displays if the module was not updated
            }
        }

        public static void deleteModule(int moduleNumber)
        {
            string query = $"Delete from Module Where ModuleNumber = '{moduleNumber}'";
            //the query to delete all the values

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))//connects to the string connect
                {
                    conn.Open();//opens the connection

                    using (SqlCommand command = new SqlCommand(query, conn))//connects the query to the sqlconnection
                    {
                        command.ExecuteNonQuery();//executes the query
                        conn.Close();//closes the connection
                    }

                    MessageBox.Show($"Data for Module {moduleNumber} deleted successfully");//dislpays if the module was deleted
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);//displays if the module was not deleted
            }
        }

        public static DataTable searchModule(string search)
        {
            string query = @"SELECT *
                     FROM Modules
                     WHERE ModuleCode LIKE @Search
                        OR ModuleName LIKE @Search
                        OR ModuleDescription LIKE @Search
                        OR Links LIKE @Search";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Use SqlParameter to safely handle the search parameter
                    command.Parameters.AddWithValue("@Search", "%" + search + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static DataTable showStudentData()
        {
            string query = @"SELECT * FROM Student";//Selects all the values from the student table using datatable
            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);//connects the query to the sqldataadapter
            DataTable datatable = new DataTable();//creates a new datatable
            adapter.Fill(datatable);//fills the datatable using the adapter
            return datatable;//returns the datatable
        }

        public static DataTable showModuleData()
        {
            string query = @"SELECT * FROM Modules";//Selects all the values from the Modules table using datatable
            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);//connects the query to the sqldataadapter
            DataTable datatable = new DataTable();//creates a new datatable
            adapter.Fill(datatable);//fills the datatable using the adapter
            return datatable;//returns the datatable
        }
    }
}
