using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string getData = "select Dept_Name from Department";
            //string getEmp = "select * from Employee";
            //MessageBox.Show(getData);
            sqlCommand1.CommandText = getData;
            SqlDataReader dReader;
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            while(dReader.Read())
            {
                comboBox1.Items.Add(dReader["Dept_Name"]);
            }            
            dReader.Close();
            sqlConnection1.Close();


        }

        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = comboBox1.SelectedItem.ToString();
            string selectbyname = "select e.Emp_ID,e.Emp_Name,e.Emp_Salary,e.Dept_ID from Employee e inner join Department d on e.Dept_ID = d.Dept_ID and d.Dept_Name ='" + str + "'";
            //MessageBox.Show(selectbyname);
            DataTable datatable = new DataTable();
            sqlCommand1.CommandText = selectbyname;
            SqlDataReader dReader;
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            datatable.Load(dReader);            
            dataGridView1.DataSource = datatable;
            dReader.Close();
            sqlConnection1.Close();           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string DeptName = comboBox1.SelectedItem.ToString();
            string delete = "delete e from Employee e inner join Department d on e.Dept_ID = d.Dept_ID and d.Dept_Name = '" + DeptName + "' delete from Department where Dept_Name = '" + DeptName + "'";
            sqlCommand1.CommandText = delete;
            sqlCommand1 = new SqlCommand(delete, sqlConnection1);
            sqlConnection1.Open();
            SqlDataReader dReader;
            int AffectedRows = sqlCommand1.ExecuteNonQuery();
            dReader = sqlCommand1.ExecuteReader();
            dReader.Close();
            MessageBox.Show(AffectedRows.ToString() + "Rows Deleted");
            comboBox1.Text = string.Empty;
        }
    }
}




