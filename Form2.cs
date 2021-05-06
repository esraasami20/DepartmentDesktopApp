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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string getData = "select Dept_ID from Department";
            ////string getEmp = "select * from Employee";
            ////MessageBox.Show(getData);
            sqlCommand1.CommandText = getData;
            SqlDataReader dReader;
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            while (dReader.Read())
            {
                comboBox2.Items.Add(dReader["Dept_ID"]);
            }
            dReader.Close();
            sqlConnection1.Close();           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2.Items.Clear();
            string str = comboBox2.SelectedItem.ToString();
            string selectbyname = "select e.Emp_ID,e.Emp_Name,e.Emp_Salary,e.Dept_ID from Employee e inner join Department d on e.Dept_ID = d.Dept_ID and d.Dept_Name ='" + str + "'";
            //MessageBox.Show(selectbyname);
            DataTable datatable = new DataTable();
            sqlCommand1.CommandText = selectbyname;
            SqlDataReader dReader;
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            datatable.Load(dReader);
           
            dReader.Close();
            sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            string getData = "select Emp_ID from Employee";
            //string getEmp = "select * from Employee";
            //MessageBox.Show(getData);
            sqlCommand1.CommandText = getData;
            SqlDataReader dReader;
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            while (dReader.Read())
            {
                comboBox1.Items.Add(dReader["Emp_ID"]);
            }
            dReader.Close();
            sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Close();
        }

        private void btnins_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == null || comboBox2.Text == "" ||comboBox1.Text==null || comboBox1.Text == ""|| textBox2.Text == null || textBox2.Text == "" || textBox3.Text == null || textBox3.Text == "") { MessageBox.Show(" ^_^ please Enter a valid ID ^_^"); }
            else
            {
                string str = "insert into Employee (Emp_ID,Emp_Name,Emp_Salary,Dept_ID)values(" + comboBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + comboBox2.Text + ")";
                sqlCommand1.CommandText = str;
                //MessageBox.Show(str);
                sqlConnection1.Open();
                int rowss = sqlCommand1.ExecuteNonQuery();
                sqlConnection1.Close();
                comboBox1.Text = comboBox2.Text = textBox2.Text = textBox3.Text = string.Empty;
                MessageBox.Show("^_^ Successfully inserted ^_^");
            }

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == null || comboBox2.Text == "" || comboBox1.Text == null || comboBox1.Text == "" || textBox2.Text == null || textBox2.Text == "" || textBox3.Text == null || textBox3.Text == "") { MessageBox.Show(" ^_^ please Enter a valid ID ^_^"); }
            else
            {
                string delete = "delete from Employee where Emp_ID=" + comboBox1.Text + "";
                sqlCommand1.CommandText = delete;
                sqlConnection1.Open();
                int affected = sqlCommand1.ExecuteNonQuery();
                sqlConnection1.Close();
                comboBox1.Text = textBox3.Text = textBox2.Text = string.Empty;
                MessageBox.Show(affected.ToString() + "^_^ The Selected Employee Deleted ^_^");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == null || comboBox2.Text == "" || comboBox1.Text == null || comboBox1.Text == "" || textBox2.Text == null || textBox2.Text == "" || textBox3.Text == null || textBox3.Text == "") { MessageBox.Show(" ^_^ please Enter a valid ID ^_^"); }
            else
            {
                string str = "update Employee set Emp_Name='" + textBox2.Text + "'," + "Emp_Salary='" + textBox3.Text + "'where Emp_ID=" + comboBox1.Text + "";
                sqlCommand1.CommandText = str;
                sqlConnection1.Open();
                int affected = sqlCommand1.ExecuteNonQuery();
                sqlConnection1.Close();
                comboBox2.Text = textBox3.Text = textBox2.Text = string.Empty;
                MessageBox.Show(affected.ToString() + "^_^ The Selected Employee Has Updated ^_^");
            }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if ( comboBox1.Text == null || comboBox1.Text == "" ) { MessageBox.Show(" ^_^ please Enter a valid ID ^_^"); }
            else
            {
                string Id = comboBox1.Text.ToString();
                string selectedName = "select Emp_Name ,Emp_Salary,Dept_ID from Employee where Emp_ID='" + Id + "'";
                sqlCommand1.CommandText = selectedName;
                sqlConnection1.Open();
                SqlDataReader dReader = sqlCommand1.ExecuteReader();
                while (dReader.Read())
                {
                    textBox2.Text = dReader[0].ToString();
                    textBox3.Text = dReader[1].ToString();
                    //comboBox2.Items[0] = dReader[3].ToString();
                }
                dReader.Close();
                sqlConnection1.Close();

            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string id = comboBox2.SelectedItem.ToString();
            string selectID = "select distinct Emp_ID from Employee e,Department d where e.Dept_ID =" + id;               
            sqlCommand1.CommandText = selectID;
            SqlDataReader dReader;
            sqlConnection1.Open();
            dReader = sqlCommand1.ExecuteReader();
            while (dReader.Read())
            {
                comboBox1.Items.Add(dReader["Emp_ID"]);
            }
            dReader.Close();
            sqlConnection1.Close();
        }
    }
}
