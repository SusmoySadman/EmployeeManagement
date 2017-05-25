using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class Form1 : Form
    {
        EmployeeDAO employeeDao = new EmployeeDAO();

        public Form1()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            employeeInfo.DataSource = employeeDao.getCustomers().Tables[0];
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            int age = Convert.ToInt32(ageBox.Text);
            int salary = Convert.ToInt32(salaryBox.Text);
            string name = nameBox.Text;

            employeeDao.createEmployee(new EmployeeDTO(id, age, salary, name));
            LoadEmployees();
        }

        private void employeeInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (employeeInfo.SelectedRows.Count == 1)
            {
                int idx = employeeInfo.SelectedRows[0].Index;

                idBox.Text = employeeInfo.Rows[idx].Cells[0].Value.ToString();
                nameBox.Text = employeeInfo.Rows[idx].Cells[1].Value.ToString();
                ageBox.Text = employeeInfo.Rows[idx].Cells[2].Value.ToString();
                salaryBox.Text = employeeInfo.Rows[idx].Cells[3].Value.ToString();
            }
        }


        private void deleteEmployee()
        {
            employeeDao.DeleteEmployee(Convert.ToInt32(idBox.Text));

            LoadEmployees();
            idBox.Text = "";
            nameBox.Text = "";
            ageBox.Text = "";
            salaryBox.Text = "";

        }


        private void UpdateEmployee()
        {
            int id = Convert.ToInt32(idBox.Text);
            int age = Convert.ToInt32(ageBox.Text);
            int salary = Convert.ToInt32(salaryBox.Text);
            string name = nameBox.Text;

            employeeDao.UpdateEmployee(new EmployeeDTO(id,age,salary,name));

            LoadEmployees();



        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteEmployee();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }

    }
}
