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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void Login_Click(object sender, EventArgs e)
        {
            




         
            string Username = textBox1.Text;
            string Password = textBox2.Text;
            if (Username == "Admin" && Password == "Skills@123")
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login credentials,please check Username and password and try again", "Invalid login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure, Do you really want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

            else if (dialogResult == DialogResult.No)
            { }

        }

        private void Password_Click(object sender, EventArgs e)
        {

        }
    }
}
