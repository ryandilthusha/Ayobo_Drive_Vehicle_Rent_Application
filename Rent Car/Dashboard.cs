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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();



            //********************************* Filling Combo Boxes
            fill_combo_Rent();     //Filling combobox Rent
            fill_combo_OneD();      //Filling combobox OneD
            fill_combo_LongD();     //Filling combobox Tours


            //********************************* Summery Panel Details
            Get_Vehicle_Count();        //Vehicle count 
            Get_Rent_Count();           //Rent packages count
            Get_OneD_Count();           //One Day packages count
            Get_LongD_Count();          //Tour packages count
            Get_Drivers_Count();        //Drivers count


            //********************************* Financial Panel Details
            Get_Rent_Total();                               //Total Earn Amount by Renting 
            Get_Rent_Amount_By_Driver();                    //Drivers's Earn Amount by Renting 

            Get_OneD_Total();                               //Total Earn Amount by One Day Hires
            Get_OneD_Amount_By_Driver();                    //Drivers's Earn Amount by One Day Hiring

            Get_LongD_Total();                              //Total Earn Amount by Tour Hires
            Get_LongD_Amount_By_Driver();                   //Drivers's Earn Amount by Tour Hiring


            //********************************* Award Panel Details
            Best_Rent_Driver();         //Best Rent Driver Award
            Best_OneD_Driver();         //Best One Day Hire Driver Award
            Best_LongD_Driver();        //Best Tour Hire Driver Award
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-44KSVRU;Initial Catalog=Rent_Car_Project;Integrated Security=True");


        //********************************* Quick Menu BUTTONS **********************************************************************************************************************

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



        //********************************* Summery Panel Details **********************************************************************************************************************

        public void Get_Vehicle_Count()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(Veh_ID) FROM Details_Vehicle_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Vehicle_Count.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        public void Get_Rent_Count()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(Rent_ID) FROM Details_Renting_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Renting_Count.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        public void Get_OneD_Count()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(OneD_ID) FROM Details_OneD_Hire_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_OneD_Count.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        public void Get_LongD_Count()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(LongD_ID) FROM Details_LongD_Hire_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Tour_Count.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        public void Get_Drivers_Count()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(Driver_ID) FROM Details_Drivers_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Drivers_Count.Text = dt.Rows[0][0].ToString();
            con.Close();
        }



        //********************************* Dashboard Financial Panel Details for RENT **********************************************************************************************************************

        public void Get_Rent_Total()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Bill_Amount) FROM Bill_Rent_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Rent_Total.Text = dt.Rows[0][0].ToString();
            con.Close();
        }


        
        private void fill_combo_Rent()     //ComboBox fill with sellers name
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Driver_Username FROM Details_Drivers_Table", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("cmb_Renting", typeof(string));
            dt.Load(dr);
            cmb_Renting.ValueMember = "Driver_Username";
            cmb_Renting.DataSource = dt;
            con.Close();
        }

        public void Get_Rent_Amount_By_Driver()      //TextBox link with the Combo Box
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Bill_Amount) FROM Bill_Rent_Table WHERE Driver_Name = '"+ cmb_Renting.SelectedValue.ToString()  +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Rents_by_Driver.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void cmb_Renting_SelectionChangeCommitted(object sender, EventArgs e)   //According to ComboBox value change the TextBox value      (ComboBox Event"SelectionChangeCommitted")
        {
            Get_Rent_Amount_By_Driver();
        }



        //********************************* Dashboard Financial Panel Details for One Day Hires **********************************************************************************************************************

        public void Get_OneD_Total()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Bill_Amount) FROM Bill_OneD_Hire_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_OneD_Total.Text = dt.Rows[0][0].ToString();
            con.Close();
        }



        private void fill_combo_OneD()     //ComboBox fill with sellers name
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Driver_Username FROM Details_Drivers_Table", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("cmb_OneD", typeof(string));
            dt.Load(dr);
            cmb_OneD.ValueMember = "Driver_Username";
            cmb_OneD.DataSource = dt;
            con.Close();
        }

        public void Get_OneD_Amount_By_Driver()      //TextBox link with the Combo Box
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Bill_Amount) FROM Bill_OneD_Hire_Table WHERE Driver_Name = '" + cmb_OneD.SelectedValue.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_OneD_by_Driver.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void cmb_OneD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Get_OneD_Amount_By_Driver();
        }


        //********************************* Dashboard Financial Panel Details for Tour Hires **********************************************************************************************************************

        public void Get_LongD_Total()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Bill_Amount) FROM Bill_LongD_Hire_Table", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Tour_Total.Text = dt.Rows[0][0].ToString();
            con.Close();
        }



        private void fill_combo_LongD()     //ComboBox fill with sellers name
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Driver_Username FROM Details_Drivers_Table", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("cmb_Tour", typeof(string));
            dt.Load(dr);
            cmb_Tour.ValueMember = "Driver_Username";
            cmb_Tour.DataSource = dt;
            con.Close();
        }

        public void Get_LongD_Amount_By_Driver()      //TextBox link with the Combo Box
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(Bill_Amount) FROM Bill_LongD_Hire_Table WHERE Driver_Name = '" + cmb_Tour.SelectedValue.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbl_Tours_by_Driver.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void cmb_Tour_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Get_LongD_Amount_By_Driver();
        }




        //********************************* Award Panel Details **********************************************************************************************************************


        private void Best_Rent_Driver()
        {
            try
            {
                con.Open();
                string InnerQuery = "SELECT MAX(Bill_Amount) FROM Bill_Rent_Table";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, con);
                sda1.Fill(dt1);

                string Query = "SELECT Driver_Name FROM Bill_Rent_Table WHERE Bill_Amount = '" + dt1.Rows[0][0].ToString()+"'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lbl_Best_Rent.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void Best_OneD_Driver()
        {
            try
            {
                con.Open();
                string InnerQuery = "SELECT MAX(Bill_Amount) FROM Bill_OneD_Hire_Table";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, con);
                sda1.Fill(dt1);

                string Query = "SELECT Driver_Name FROM Bill_OneD_Hire_Table WHERE Bill_Amount = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lbl_Best_OneD.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }


        private void Best_LongD_Driver()
        {
            try
            {
                con.Open();
                string InnerQuery = "SELECT MAX(Bill_Amount) FROM Bill_LongD_Hire_Table";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, con);
                sda1.Fill(dt1);

                string Query = "SELECT Driver_Name FROM Bill_LongD_Hire_Table WHERE Bill_Amount = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                lbl_Best_LongD.Text = dt.Rows[0][0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }    
}
