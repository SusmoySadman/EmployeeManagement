using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeManagement
{
    class EmployeeDAO
    {
        private string connectionString = @"Data Source=DESKTOP-0I0GCCB\SQLEXPRESS;Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private DataSet dataSet;

        public EmployeeDAO()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public DataSet getCustomers()
        {
            sqlConnection.Open();
            string query = "select * from employee";

            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlAdapter = new SqlDataAdapter(sqlCommand);

            dataSet = new DataSet();
            sqlAdapter.Fill(dataSet);

            sqlConnection.Close();
            return dataSet;
        }

        public void createEmployee(EmployeeDTO employeeDto)
        {
            sqlConnection.Open();
            string query = "insert into employee values('" + employeeDto.ID + "','"
                                                           + employeeDto.NAME + "','"
                                                           + employeeDto.AGE + "','"
                                                           + employeeDto.SALARY + "')";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Create successfully");
        }

        public void DeleteEmployee(int id)
        {
            sqlConnection.Open();
            string sqlQuery = "delete from employee where Id=" + id;
            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();


            sqlConnection.Close();
            MessageBox.Show("Delete successfully");

        }


        public void UpdateEmployee(EmployeeDTO employeeDto)
        {
            sqlConnection.Open();

        
            string sqlQuery = "update employee set Name='" + employeeDto.NAME + "',Age='" + employeeDto.AGE + "',Salary='" + employeeDto.SALARY + "' Where Id='" + employeeDto.ID + "'";
          
            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();


            sqlConnection.Close();



            MessageBox.Show("Update successfully");



        }

    }
}
