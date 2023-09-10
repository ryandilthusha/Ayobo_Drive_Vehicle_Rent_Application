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
    public partial class Give_Renting_Form : Form
    {
        public Give_Renting_Form()
        {
            InitializeComponent();

            display_data_grid_view_Vehicle_List();
            display_data_grid_view_Rent_List();
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
            txt_rentID.Text = "";
            txt_type.Text = "";
            txt_brand.Text = "";
            txt_model.Text = "";
            txt_colour.Text = "";
            txt_dayRent.Text = "";
            txt_weekRent.Text = "";
            txt_monthRent.Text = "";
            cmb_driverRate.Text = "";

        }

        //FOR 1st DATA GRID VIEW
        public void display_data_grid_view_Vehicle_List()    //For the data grid view
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
                txt_type.Text = DR1.GetValue(1).ToString();                
                txt_brand.Text = DR1.GetValue(3).ToString();
                txt_model.Text = DR1.GetValue(4).ToString();
                txt_colour.Text = DR1.GetValue(5).ToString();               

            }
            DR1.Close();
            con.Close();
        }


        //FOR 2nd DATA GRID VIEW
        public void display_data_grid_view_Rent_List()    //For the data grid view
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("SELECT * FROM Details_Renting_Table", con);
                adpt.Fill(dt);
                dgv_Renting_List.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void dgv_Renting_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            int ID;

            ID = int.Parse(dgv_Renting_List.Rows[e.RowIndex].Cells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Details_Renting_Table WHERE Rent_ID = '" + ID + "' ";

            SqlDataReader DR1 = cmd.ExecuteReader();

            if (DR1.Read())
            {
                txt_rentID.Text = DR1.GetValue(0).ToString();
                txt_type.Text = DR1.GetValue(1).ToString();
                txt_brand.Text = DR1.GetValue(2).ToString();
                txt_model.Text = DR1.GetValue(3).ToString();
                txt_colour.Text = DR1.GetValue(4).ToString();
                txt_dayRent.Text = DR1.GetValue(5).ToString();
                txt_weekRent.Text = DR1.GetValue(6).ToString();
                txt_monthRent.Text = DR1.GetValue(7).ToString();
                cmb_driverRate.Text = DR1.GetValue(8).ToString();

            }
            DR1.Close();
            con.Close();
        }





        //***********************************SAVE*************Edit***************Delete*****************************************************************************************

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_type.Text == "" || txt_brand.Text == "" || txt_model.Text == "" || txt_colour.Text == "" || txt_dayRent.Text == "" || txt_weekRent.Text == "" || txt_monthRent.Text == "" || cmb_driverRate.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Details_Renting_Table(Veh_Type,Veh_Brand,Veh_Model,Veh_Colour,Rent_Daily,Rent_Weekly,Rent_Monthly,Rent_DriverRate) VALUES('" + txt_type.Text + "' , '" + txt_brand.Text + "' , " +
                        "'" + txt_model.Text + "' , '" + txt_colour.Text + "' , '" + txt_dayRent.Text + "' , '" + txt_weekRent.Text + "'  , '" + txt_monthRent.Text + "' , '" + cmb_driverRate.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Rent added successfully!!!");

                    display_data_grid_view_Vehicle_List();
                    display_data_grid_view_Rent_List();    //data grid view method
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
            if (txt_type.Text == "" || txt_brand.Text == "" || txt_model.Text == "" || txt_colour.Text == "" || txt_dayRent.Text == "" || txt_weekRent.Text == "" || txt_monthRent.Text == "" || cmb_driverRate.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE Details_Renting_Table SET Veh_Type = '" + txt_type.Text + "' ,  Veh_Brand = '" + txt_brand.Text + "', Veh_Model = '" + txt_model.Text + "', " +
                        "Veh_Colour = '" + txt_colour.Text + "', Rent_Daily = '" + txt_dayRent.Text + "', Rent_Weekly = '" + txt_weekRent.Text + "', Rent_Monthly = '" + txt_monthRent.Text + "' , Rent_DriverRate = '" + cmb_driverRate.Text + "' WHERE Rent_ID = '" + txt_rentID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Rent edit successfully!!!");

                    display_data_grid_view_Vehicle_List();
                    display_data_grid_view_Rent_List();    //data grid view method
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
            if (txt_dayRent.Text == "")
            {
                MessageBox.Show("Select Rent to Delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM Details_Renting_Table WHERE Rent_ID = '" + txt_rentID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Rent delete successfully!!!");

                    display_data_grid_view_Vehicle_List();
                    display_data_grid_view_Rent_List();    //data grid view method
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
            txt_rentID.Text = "";
            txt_type.Text = "";
            txt_brand.Text = "";
            txt_model.Text = "";
            txt_colour.Text = "";
            txt_dayRent.Text = "";
            txt_weekRent.Text = "";
            txt_monthRent.Text = "";
            cmb_driverRate.Text = "";
        }
    }
}
