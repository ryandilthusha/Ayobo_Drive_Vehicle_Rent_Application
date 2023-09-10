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
    public partial class Vehicles_Register_Form : Form
    {
        public Vehicles_Register_Form()
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

        private void btn_drivers_Click(object sender, EventArgs e)
        {
            Drivers_Register_Form obj = new Drivers_Register_Form();
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
            txt_vehID.Text = "";
            cmb_type.Text = "";
            txt_regno.Text = "";
            cmb_brand.Text = "";
            txt_model.Text = "";
            cmb_colour.Text = "";
            txt_own_name.Text = "";
            txt_own_id.Text = "";
            txt_own_phone.Text = "";

        }

        public void display_data_grid_view()    //For the data grid view
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("SELECT * FROM Details_Vehicle_Table", con);
                adpt.Fill(dt);
                dgv_Vehicles_List.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        private void dgv_Vehicles_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            int ID;

            ID = int.Parse(dgv_Vehicles_List.Rows[e.RowIndex].Cells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Details_Vehicle_Table WHERE Veh_ID = '" + ID + "' ";

            SqlDataReader DR1 = cmd.ExecuteReader();

            if (DR1.Read())
            {
                txt_vehID.Text = DR1.GetValue(0).ToString();
                cmb_type.Text = DR1.GetValue(1).ToString();
                txt_regno.Text = DR1.GetValue(2).ToString();
                cmb_brand.Text = DR1.GetValue(3).ToString();
                txt_model.Text = DR1.GetValue(4).ToString();
                cmb_colour.Text = DR1.GetValue(5).ToString();
                txt_own_name.Text = DR1.GetValue(6).ToString();
                txt_own_id.Text = DR1.GetValue(7).ToString();
                txt_own_phone.Text = DR1.GetValue(8).ToString();

            }
            DR1.Close();
            con.Close();
        }



        //***********************************SAVE*************Edit***************Delete*****************************************************************************************

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cmb_type.Text == "" || txt_regno.Text == "" || cmb_brand.Text == "" || cmb_colour.Text == "" || txt_own_name.Text == "" || txt_own_id.Text == "" || txt_own_phone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Details_Vehicle_Table(Veh_Type,Veh_RegNo,Veh_Brand,Veh_Model,Veh_Colour,Own_Name,Own_ID,Own_Phone) VALUES('" + cmb_type.Text + "' , '" + txt_regno.Text + "' , " +
                        "'" + cmb_brand.Text + "' , '" + txt_model.Text + "' , '" + cmb_colour.Text + "'  , '" + txt_own_name.Text + "' , '" + txt_own_id.Text + "'  , '" + txt_own_phone.Text + "'  )", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Vehicle added successfully!!!");

                    display_data_grid_view();    //data grid view method
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
            if (cmb_type.Text == "" || txt_regno.Text == "" || cmb_brand.Text == "" || cmb_colour.Text == "" || txt_own_name.Text == "" || txt_own_id.Text == "" || txt_own_phone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE Details_Vehicle_Table SET Veh_Type = '" + cmb_type.Text + "' , Veh_RegNo = '" + txt_regno.Text + "', Veh_Brand = '" + cmb_brand.Text + "', Veh_Model = '" + txt_model.Text + "', " +
                        "Veh_Colour = '" + cmb_colour.Text + "', Own_Name = '" + txt_own_name.Text + "', Own_ID = '" + txt_own_id.Text + "', Own_Phone = '" + txt_own_phone.Text + "' WHERE Veh_ID = '" + txt_vehID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Vehicle edit successfully!!!");

                    display_data_grid_view();    //data grid view method
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
            if (cmb_type.Text == "")
            {
                MessageBox.Show("Select Vehicle to Delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM Details_Vehicle_Table WHERE Veh_ID = '" + txt_vehID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Vehicle delete successfully!!!");

                    display_data_grid_view();    //data grid view method
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
            txt_vehID.Text = "";
            cmb_type.Text = "";
            txt_regno.Text = "";
            cmb_brand.Text = "";
            txt_model.Text = "";
            cmb_colour.Text = "";
            txt_own_name.Text = "";
            txt_own_id.Text = "";
            txt_own_phone.Text = "";
        }
    }


}
