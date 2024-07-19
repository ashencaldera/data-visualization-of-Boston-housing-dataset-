using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        private string gender;


        public Form2()
         
        {
            InitializeComponent();
        }
        //String cmd;
        //string gender;
        //string conn;
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure,Do you really want to Delete this Record ...?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes) ;
            {

                con.Open();
                cmd = new SqlCommand("DELETE FROM Registration_1 WHERE regNo = @Valuel", con);

                cmd.Parameters.AddWithValue("@Value1", comboBox1.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully");
                con.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit app", "Do you really want to Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //Nothing
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e, SqlConnection con)
        {

            {

                



              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PA04GK7\\SQLEXPRESS;Initial Catalog=\"Student 2\";Integrated Security=True;");
                //con.Open();

                String gend = " ";
                bool isChecked1 = radioButton1.Checked;
                bool isChecked2 = radioButton2.Checked;
                if (isChecked1)
                    gend = "male";
                else if (isChecked2)
                    gend = "female";
                else
                    gend = "ND";

                //SqlCommand cmd = new SqlCommand("UPDATE Registration SET regNo = @Value1, FirstName = @Value2, LastName = @Value3, dateOfBirth = @Value4, gender = @Value5, address = @Value6, email = @Value7, mobilePhone = @Value8, homePhone = @Value9, ParentName = @Value10, nic=@Value11, contactNo=@Value12 WHERE regNo = @Value1", con);

                //cmd.Parameters.AddWithValue("@Value1", comboBox1.Text);
                //cmd.Parameters.AddWithValue("@Value2", textBox1.Text);
                //cmd.Parameters.AddWithValue("@Value3", textBox2.Text);
                //cmd.Parameters.AddWithValue("@Value4", dateTimePicker1.Value);
                //cmd.Parameters.AddWithValue("@Value5", gend);
                //cmd.Parameters.AddWithValue("@Value6", textBox3.Text);
                //cmd.Parameters.AddWithValue("@Value7", textBox4.Text);
                //cmd.Parameters.AddWithValue("@Value8", textBox5.Text);
                //cmd.Parameters.AddWithValue("@Value9", textBox6.Text);
                //cmd.Parameters.AddWithValue("@Value10", textBox7.Text);
                //cmd.Parameters.AddWithValue("@Value11", textBox8.Text);
                //cmd.Parameters.AddWithValue("@Value12", textBox9.Text);

                //int rowsAffected = cmd.ExecuteNonQuery();

                con.Open();

                // Define the UPDATE query
                string updateQuery = "UPDATE Registration SET firstName = @firstName, lastName = @lastName, dateOfBirth = @dateOfBirth, gender = @gender, address = @address, email = @email, mobilePhone = @mobilePhone, homePhone = @homePhone, parentName = @parentName, nic = @nic, contactNo = @contactNo WHERE firstName = @firstName";

                // Create a SqlCommand object with the UPDATE query and connection
                SqlCommand cmd = new SqlCommand(updateQuery, con);

                // Set parameters for the UPDATE query
                cmd.Parameters.AddWithValue("@regNo", comboBox1.Text);
                cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value.ToString("yyyy-MM-dd")); // Assuming dateOfBirth is of type DATE in the database
                cmd.Parameters.AddWithValue("@gender", gend); // Assuming you have already defined 'gender' variable
                cmd.Parameters.AddWithValue("@address", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@mobilePhone", textBox5.Text);
                cmd.Parameters.AddWithValue("@homePhone", textBox6.Text);
                cmd.Parameters.AddWithValue("@parentName", textBox7.Text);
                cmd.Parameters.AddWithValue("@nic", textBox8.Text);
                cmd.Parameters.AddWithValue("@contactNo", textBox9.Text);

                // Execute the UPDATE query
                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show(rowsAffected + " Record(s) updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                    
                    con.Close();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            {
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }


                SqlConnection con = new SqlConnection("Data Source=DESKTOP-PA04GK7\\SQLEXPRESS;Initial Catalog=\"Student 2\";Integrated Security=True;");


                con.Open();
                string insertQuery = "INSERT INTO Registration VALUES (@regNo,@firstName,@lastName,@dateOfBirth,@gender,@address,@email,@mobilePhone,@homePhone,@parentName,@nic,@contactNo)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@regNo", comboBox1.Text);
                cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@address", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@mobilePhone", textBox5.Text);
                cmd.Parameters.AddWithValue("@homePhone", textBox6.Text);
                cmd.Parameters.AddWithValue("@parentName", textBox7.Text);
                cmd.Parameters.AddWithValue("@nic", textBox8.Text);
                cmd.Parameters.AddWithValue("@contactNo", textBox9.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();





            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
