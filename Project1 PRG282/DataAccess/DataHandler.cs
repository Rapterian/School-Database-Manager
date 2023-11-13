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
        static string connect = "Server = (local); Initial Catalog = PRG281Database; Integrated Security = SSPI";
        //connects to the database

        public static void createStudent(Student student)
        {
            String query = $"INSERT INTO Student VALUES ('{student.Name}', '{student.Surname}', '{student.StudentImage}', '{student.DOB1}', '{student.Gender}'," +
                $" '{student.Phone}', '{student.Address}' );";
            //the query to insert all the values into the table

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
                MessageBox.Show(e.Message);//displays if the student was not deleted
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
                       OR Address LIKE @Search";

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
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("InsertModule", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@ModuleCode", module.ModuleCode);
                        command.Parameters.AddWithValue("@ModuleName", module.ModuleName);
                        command.Parameters.AddWithValue("@ModuleDescription", module.ModuleDescription);
                        command.Parameters.AddWithValue("@Links", module.Links);

                        command.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Created Module");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void updateModule(Module module)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("UpdateModule", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@ModuleCode", module.ModuleCode);
                        command.Parameters.AddWithValue("@ModuleName", module.ModuleName);
                        command.Parameters.AddWithValue("@ModuleDescription", module.ModuleDescription);
                        command.Parameters.AddWithValue("@Links", module.Links);

                        command.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Module Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void deleteModule(int moduleNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("DeleteModule", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@ModuleNumber", moduleNumber);

                        command.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show($"Data for Module {moduleNumber} deleted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("ShowModuleData", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        return datatable;
                    }
                }
            }
        }


        public static List<string> GetModuleCodesForStudent(int studentNumber)
        {
            List<string> moduleCodes = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();

                    string query = "SELECT ModuleCode FROM StudentModules WHERE StudentNumber = @StudentNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StudentNumber", studentNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string moduleCode = reader["ModuleCode"].ToString();
                                moduleCodes.Add(moduleCode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or throw as needed
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return moduleCodes;
        }

        public static void addStudentModules(List<string> studentModules, int studentNumber)
        {
            foreach (string moduleCode in studentModules)
            {
                String query = $"INSERT INTO StudentModules VALUES ('{studentNumber}', '{moduleCode}')";
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
                    MessageBox.Show(ex.Message);//displays if the module was not created
                }
            }

        }

        public static int GetLastStudentNumber()
        {
            string query = "SELECT TOP 1 * FROM Student ORDER BY StudentNumber DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        // ExecuteScalar is used to retrieve the last inserted identity value
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            // Handle the case where no identity value was returned
                            return -1; // or throw an exception, return null, etc.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1; // or throw an exception, return null, etc.
            }
        }

        public static void deleteStudentModules(int studentNumber)
        {
            string query = $"Delete from StudentModules Where studentNumber = '{studentNumber}'";
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

                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);//displays if the module was not deleted
            }
        }
    }
}
