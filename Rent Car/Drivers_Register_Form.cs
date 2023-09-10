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
    public partial class Drivers_Register_Form : Form
    {
        public Drivers_Register_Form()
        {
            InitializeComponent();

            display_data_grid_view();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-44KSVRU;Initial Catalog=Rent_Car_Project;Integrated Security=True");
        SqlCommand cmd;


        //For data grid view
        SqlDataAdapter adpt;
        DataTable dt;


        //********************************* Quick Menu BUTTONS **********************************************************************************************************************

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void btn_vehicles_Click(object sender, EventArgs e)
        {
            Vehicles_Register_Form obj = new Vehicles_Register_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_renting_Click(object sender, EventArgs e)
        {
            Give_Renting_Form obj = new Give_Renting_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_1D_Hire_Click(object sender, EventArgs e)
        {
            Give_1D_Hiring_Form obj = new Give_1D_Hiring_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_Tour_Hire_Click(object sender, EventArgs e)
        {
            Give_Long_Hiring_Form obj = new Give_Long_Hiring_Form();
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
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("SELECT * FROM Details_Drivers_Table", con);
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || txt_password.Text == "" || txt_email.Text == "" || txt_phone.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string date = Convert.ToString(dtp_DOB.Value);
                    date = date.Remove(date.Length - 11);

                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Details_Drivers_Table(Driver_Username,Driver_Password,Driver_Email,Driver_Phone,Driver_DOB) VALUES('" + txt_username.Text + "' , '" + txt_password.Text + "' , " +
                        "'" + txt_email.Text + "' , '" + txt_phone.Text + "' , '" + dtp_DOB.Value.ToString("yyyy-MM-dd") + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Driver added successfully!!!");

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

                    con.Open();
                    cmd = new SqlCommand("UPDATE Details_Drivers_Table SET Driver_Username = '" + txt_username.Text + "' ,  Driver_Password = '" + txt_password.Text + "', Driver_Email = '" + txt_email.Text + "', " +
                        "Driver_Phone = '" + txt_phone.Text + "', Driver_DOB = '" + dtp_DOB.Value.ToString("yyyy-MM-dd") + "' WHERE Driver_ID = '" + txt_driverID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Driver edit successfully!!!");

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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_driverID.Text == "")
            {
                MessageBox.Show("Select driver to Delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM Details_Drivers_Table WHERE Driver_ID = '" + txt_driverID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Driver delete successfully!!!");

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
