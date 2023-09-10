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

namespace Rent_Car
{
    public partial class Driver_Signup_Form : Form
    {
        public Driver_Signup_Form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-44KSVRU;Initial Catalog=Rent_Car_Project;Integrated Security=True");


        private void Driver_Signup_Form_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }


        private void btn_register_Click(object sender, EventArgs e)
        {
            

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT (*) FROM Details_Drivers_Table WHERE Driver_Username = '" + txt_username.Text + "'";

            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Username is already taken");
            }
            else
            {              

                cmd.CommandText = "INSERT INTO Details_Drivers_Table (Driver_Username,Driver_Password,Driver_Email,Driver_Phone,Driver_DOB) VALUES ('" + txt_username.Text + "'," +
                    "'" + txt_password.Text + "','" + txt_email.Text + "','" + txt_phoneNum.Text + "','" + dtp_birthday.Value.ToString("yyyy-MM-dd") + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("You detials saved success!!!");
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Login_Form obj = new Login_Form();
            this.Hide();
            obj.Show();
        }

        private void lbl_clear1_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txt_password.Text = "";
        }

        private void lbl_clear2_Click(object sender, EventArgs e)
        {
            txt_email.Text = "";
            txt_phoneNum.Text = "";
            dtp_birthday.Value = DateTime.Now;
        }
    }
}
