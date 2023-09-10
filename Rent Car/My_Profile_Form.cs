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
    public partial class My_Profile_Form : Form
    {
        public My_Profile_Form()
        {
            InitializeComponent();

            display_data_grid_view();

            lbl_driver.Text = Login_Form.user;   //Login user name display --> STEP 3 (Username Pass from Login Form to Billing Form)
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-44KSVRU;Initial Catalog=Rent_Car_Project;Integrated Security=True");
        SqlCommand cmd;


        //For data grid view
        SqlDataAdapter adpt;
        DataTable dt;


        //********************************* Quick Menu BUTTONS **********************************************************************************************************************

        private void btn_rent_Click(object sender, EventArgs e)
        {
            Rent_Form obj = new Rent_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_1D_Hire_Click(object sender, EventArgs e)
        {
            _1D_Hire_Form obj = new _1D_Hire_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_Tour_Hire_Click(object sender, EventArgs e)
        {
            Long_Hire_Form obj = new Long_Hire_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_About_Us_Click(object sender, EventArgs e)
        {
            About_Us_Form obj = new About_Us_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Login_Form obj = new Login_Form();
            obj.Show();
            this.Hide();
        }


        //********************************* OTHER METHODS **********************************************************************************************************************

        public void clear()
        {
            txt_driverID.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_email.Text = "";
            txt_phone.Text = "";
            dtp_DOB.Value = DateTime.Now;
        }

        public void display_data_grid_view()    //For the data grid view
        {
            try
            {
                lbl_driver.Text = Login_Form.user;      //Login user name display --> STEP 3 (Username Pass from Login Form to Billing Form)

                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("SELECT * FROM Details_Drivers_Table WHERE Driver_Username ='" + lbl_driver.Text + "'", con);
                adpt.Fill(dt);
                dgv_drivers.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void dgv_drivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            int ID;

            ID = int.Parse(dgv_drivers.Rows[e.RowIndex].Cells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Details_Drivers_Table WHERE Driver_ID = '" + ID + "' ";

            SqlDataReader DR1 = cmd.ExecuteReader();

            if (DR1.Read())
            {
                txt_driverID.Text = DR1.GetValue(0).ToString();
                txt_username.Text = DR1.GetValue(1).ToString();
                txt_password.Text = DR1.GetValue(2).ToString();
                txt_email.Text = DR1.GetValue(3).ToString();
                txt_phone.Text = DR1.GetValue(4).ToString();
                dtp_DOB.Value = DateTime.Parse(DR1.GetValue(5).ToString());

            }
            DR1.Close();
            con.Close();
        }


        //***********************************SAVE*************Edit***************Delete*****************************************************************************************

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || txt_password.Text == "" || txt_email.Text == "" || txt_phone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string date = Convert.ToString(dtp_DOB.Value);
                    date = date.Remove(date.Length - 12);

                    con.Open();
                    cmd = new SqlCommand("UPDATE Details_Drivers_Table SET Driver_Username = '" + txt_username.Text + "' ,  Driver_Password = '" + txt_password.Text + "', Driver_Email = '" + txt_email.Text + "', " +
                        "Driver_Phone = '" + txt_phone.Text + "', Driver_DOB = '" + date + "' WHERE Driver_ID = '" + txt_driverID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("You're details edited successfully!!!");

                    display_data_grid_view();   //data grid view method
                    clear();    //data clear method                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_driverID.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_email.Text = "";
            txt_phone.Text = "";
            dtp_DOB.Value = DateTime.Now;
        }

        
    }



}
