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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-44KSVRU;Initial Catalog=Rent_Car_Project;Integrated Security=True");


        public static string user;      //Newly Created Variable --> To pass the username to bill form constructer to show in a label --> STEP 1 (Username Pass to Login Form to Billing Form)




        private void Login_Form_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }




        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (cmb_role.Text == "Select a Role" && txt_username.Text == "" && txt_password.Text == "")
            {
                MessageBox.Show("Select a Role then enter username and password");
            }
            else if (cmb_role.Text == "Select a Role" && txt_username.Text == "" && txt_password.Text != "")
            {
                MessageBox.Show("Select a Role then enter username");
            }
            else if (cmb_role.Text == "Select a Role" && txt_username.Text != "" && txt_password.Text == "")
            {
                MessageBox.Show("Select a Role then enter password");
            }
            else if (cmb_role.Text == "Select a Role" && txt_username.Text != "" && txt_password.Text != "")
            {
                MessageBox.Show("Select a Role");
            }           

            else
            {
                // ADMIN LOGIN CODE with defined Username and Password

                if (cmb_role.SelectedIndex > -1)
                {
                    if (cmb_role.SelectedItem.ToString() == "ADMIN")
                    {
                        if (txt_username.Text == "Admin" && txt_password.Text == "Admin")
                        {
                            user = txt_username.Text;         //Catching username to pass to bill form constructer to show in a label   --> STEP 2 (Username Pass to Login Form to Billing Form)
                            Dashboard obj = new Dashboard();
                            this.Hide();
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("If you are ADMIN, please enter correct Username and Password");
                        }
                    }                    
                    else
                    {
                        // DRIVER LOGIN CODE with defined Username and Password in the DATABASE

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT COUNT(*) FROM Details_Drivers_Table WHERE Driver_Username = '" + txt_username.Text + "' AND Driver_Password = '" + txt_password.Text + "'";

                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (cmb_role.SelectedItem.ToString() == "DRIVER")
                        {
                            if (count > 0)
                            {
                                user = txt_username.Text;         //Catching username to pass to bill form constructer to show in a label   --> STEP 2 (Username Pass to Login Form to Billing Form)
                                Rent_Form obj = new Rent_Form();
                                this.Hide();
                                obj.Show();
                            }
                            else
                            {
                                MessageBox.Show("If you are DRIVER, please enter correct Username and Password");
                            }
                        }
                    }
                }
            }
        }

        private void lbl_clear_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txt_password.Text = "";
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            Driver_Signup_Form obj = new Driver_Signup_Form();
            this.Hide();
            obj.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
