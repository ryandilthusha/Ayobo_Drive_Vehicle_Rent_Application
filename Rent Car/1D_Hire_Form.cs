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
    public partial class _1D_Hire_Form : Form
    {
        public _1D_Hire_Form()
        {
            InitializeComponent();

            display_data_grid_view();
            display_data_grid_view_BILL();

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

        private void btn_Tour_Hire_Click(object sender, EventArgs e)
        {
            Long_Hire_Form obj = new Long_Hire_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_MyProfile_Click(object sender, EventArgs e)
        {
            My_Profile_Form obj = new My_Profile_Form();
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
            txt_type.Text = "";
            txt_brand.Text = "";
            txt_model.Text = "";
            txt_colour.Text = "";
            txt_Per_km_charge.Text = "";
            txt_Max_km_limit.Text = "";
            txt_Extra_km_charge.Text = "";
            txt_Max_km_limit.Text = "";
            txt_Extra_km_charge.Text = "";
            cmb_refresh_category.Text = "";

            txt_reading_start.Text = "";
            txt_reading_end.Text = "";
            txt_distance.Text = "";
            txt_StartTime_H.Text = "";
            txt_StartTime_M.Text = "";
            txt_EndTime_H.Text = "";
            txt_EndTime_M.Text = "";
            txt_duration.Text = "";

            txt_total_km_charge.Text = "";
            txt_total_Extra_km_charge.Text = "";
            txt_total_Extra_hour_charge.Text = "";
            txt_total_hire_charge.Text = "";

        }

        public void display_data_grid_view()    //For the data grid view
        {
            try
            {
                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("SELECT * FROM Details_OneD_Hire_Table", con);
                adpt.Fill(dt);
                dgv_Hiring_List.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        int Per_km_charge;
        int Max_km_limit;
        int Extra_km_charge;
        int Max_hour_limit;
        int Extra_hour_charge;
        private void dgv_Hiring_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            int ID;

            ID = int.Parse(dgv_Hiring_List.Rows[e.RowIndex].Cells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Details_OneD_Hire_Table WHERE OneD_ID = '" + ID + "' ";

            SqlDataReader DR1 = cmd.ExecuteReader();

            if (DR1.Read())
            {
                txt_HireID.Text = DR1.GetValue(0).ToString();
                txt_type.Text = DR1.GetValue(1).ToString();
                txt_brand.Text = DR1.GetValue(2).ToString();
                txt_model.Text = DR1.GetValue(3).ToString();
                txt_colour.Text = DR1.GetValue(4).ToString();
                txt_package.Text = DR1.GetValue(5).ToString();
                Per_km_charge = Convert.ToInt32(txt_Per_km_charge.Text = DR1.GetValue(6).ToString());               //should Covert to int, becz we calculate them when adding the bill
                Max_km_limit = Convert.ToInt32(txt_Max_km_limit.Text = DR1.GetValue(7).ToString());                //should Covert to int, becz we calculate them when adding the bill
                Extra_km_charge = Convert.ToInt32(txt_Extra_km_charge.Text = DR1.GetValue(8).ToString());           //should Covert to int, becz we calculate them when adding the bill
                Max_hour_limit = Convert.ToInt32(txt_Max_hour_limit.Text = DR1.GetValue(9).ToString());             //should Covert to int, becz we calculate them when adding the bill
                Extra_hour_charge = Convert.ToInt32(txt_Extra_hour_charge.Text = DR1.GetValue(10).ToString());       //should Covert to int, becz we calculate them when adding the bill

            }
            DR1.Close();
            con.Close();
        }


        //********************************* CALCULATION PART **********************************************************************************************************************

        //CALCULATION PART

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            //Distance Calculation
            int distance = Convert.ToInt32(txt_reading_end.Text) - Convert.ToInt32(txt_reading_start.Text);

            //Duration Calculation
            int duration_gap_in_Min = (Convert.ToInt32(txt_EndTime_H.Text) * 60 + Convert.ToInt32(txt_EndTime_M.Text)) - (Convert.ToInt32(txt_StartTime_H.Text)* 60 + Convert.ToInt32(txt_StartTime_M.Text));
            int duration_in_Hours = (int)Math.Floor((duration_gap_in_Min) / 60.0);


            //display data
            txt_distance.Text = Convert.ToString(distance);
            txt_duration.Text = Convert.ToString(duration_in_Hours);

            if (Convert.ToInt32(txt_distance.Text) <= Convert.ToInt32(txt_Max_km_limit.Text) && Convert.ToInt32(txt_duration.Text) <= Convert.ToInt32(txt_Max_hour_limit.Text))     //***distance and duration are less than limit
            {
                //FOR DISTANCE
                int Total_km_charge = Convert.ToInt32(txt_Per_km_charge.Text) * Convert.ToInt32(txt_distance.Text);

                //display data
                txt_total_km_charge.Text = Convert.ToString(Total_km_charge);


                //FOR DURATION

                //display data
                txt_total_Extra_hour_charge.Text = Convert.ToString("0");                                                                                       


                //diplay other data
                txt_total_Extra_km_charge.Text = Convert.ToString("0");
                txt_total_hire_charge.Text = txt_total_km_charge.Text;

            }
            else if (Convert.ToInt32(txt_distance.Text) > Convert.ToInt32(txt_Max_km_limit.Text) && Convert.ToInt32(txt_duration.Text) <= Convert.ToInt32(txt_Max_hour_limit.Text))    //***distance over the limit but duration less than limit
            {
                //FOR DISTANCE
                int Total_km_charge = Convert.ToInt32(txt_Per_km_charge.Text) * Convert.ToInt32(txt_Max_km_limit.Text);     
                int Total_Extra_km_charge = (Convert.ToInt32(txt_distance.Text) - Convert.ToInt32(txt_Max_km_limit.Text)) * Convert.ToInt32(txt_Extra_km_charge.Text);      //Taking extra distance * Extra per km price

                int total_dis_charge = Total_km_charge + Total_km_charge;

                //display data
                txt_total_km_charge.Text = Convert.ToString(Total_km_charge);
                txt_total_Extra_km_charge.Text = Convert.ToString(Total_Extra_km_charge);

                //FOR DURATION

                //display data
                txt_total_Extra_hour_charge.Text = Convert.ToString("0");


                //diplay other data
                int TOTAL = Convert.ToInt32(txt_total_km_charge.Text) + Convert.ToInt32(txt_total_Extra_km_charge.Text);
                txt_total_hire_charge.Text = Convert.ToString(TOTAL);
                

            }
            else if (Convert.ToInt32(txt_distance.Text) > Convert.ToInt32(txt_Max_km_limit.Text) && Convert.ToInt32(txt_duration.Text) > Convert.ToInt32(txt_Max_hour_limit.Text))     //***distance and duration are over the limit
            {
                //FOR DISTANCE
                int Total_km_charge = Convert.ToInt32(txt_Per_km_charge.Text) * Convert.ToInt32(txt_Max_km_limit.Text);
                int Total_Extra_km_charge = (Convert.ToInt32(txt_distance.Text) - Convert.ToInt32(txt_Max_km_limit.Text)) * Convert.ToInt32(txt_Extra_km_charge.Text);      //Taking extra distance * Extra per km price

                int total_dis_charge = Total_km_charge + Total_km_charge;

                //display data
                txt_total_km_charge.Text = Convert.ToString(Total_km_charge);
                txt_total_Extra_km_charge.Text = Convert.ToString(Total_Extra_km_charge);


                //FOR DURATION
                int Extra_hour_charge = (Convert.ToInt32(txt_duration.Text) - Convert.ToInt32(txt_Max_hour_limit.Text)) * Convert.ToInt32(txt_Extra_hour_charge.Text);

                //display data
                txt_total_Extra_hour_charge.Text = Convert.ToString(Extra_hour_charge);

                //diplay other data
                int TOTAL = Convert.ToInt32(txt_total_km_charge.Text) + Convert.ToInt32(txt_total_Extra_km_charge.Text) + Convert.ToInt32(txt_total_Extra_hour_charge.Text);
                txt_total_hire_charge.Text = Convert.ToString(TOTAL);

            }
            else if (Convert.ToInt32(txt_distance.Text) <= Convert.ToInt32(txt_Max_km_limit.Text) && Convert.ToInt32(txt_duration.Text) > Convert.ToInt32(txt_Max_hour_limit.Text))    //***distance less than limit but duration over the limit
            {
                //FOR DISTANCE
                int Total_km_charge = Convert.ToInt32(txt_Per_km_charge.Text) * Convert.ToInt32(txt_distance.Text);

                //display data
                txt_total_km_charge.Text = Convert.ToString(Total_km_charge);


                //FOR DURATION
                int Extra_hour_charge = (Convert.ToInt32(txt_duration.Text) - Convert.ToInt32(txt_Max_hour_limit.Text)) * Convert.ToInt32(txt_Extra_hour_charge.Text);

                //display data
                txt_total_Extra_hour_charge.Text = Convert.ToString(Extra_hour_charge);


                //diplay other data
                int TOTAL = Convert.ToInt32(txt_total_km_charge.Text) + Convert.ToInt32(txt_total_Extra_hour_charge.Text);
                txt_total_hire_charge.Text = Convert.ToString(TOTAL);

                txt_total_Extra_km_charge.Text = Convert.ToString("0");

            }

        }

        //**************Add to Bill Button**************Add to Bill Button**************Add to Bill Button**************Add to Bill Button**************Add to Bill Button**************

        int finalTotal = 0;
        int n = 0;
        private void btn_AddToBill_Click(object sender, EventArgs e)
        {
            if (txt_type.Text == "" && txt_brand.Text == "" && txt_model.Text == "" && txt_colour.Text == "" && txt_package.Text == "" && txt_Per_km_charge.Text == "" && txt_Max_km_limit.Text == "" && txt_Extra_km_charge.Text == "" && txt_Max_hour_limit.Text == "" && txt_Extra_hour_charge.Text == "")
            {
                MessageBox.Show("Enter Package Details Please");
            }
            else
            {

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgv_Current_Bill);
                newRow.Cells[0].Value = n + 1;                
                newRow.Cells[1].Value = txt_Per_km_charge.Text;
                newRow.Cells[2].Value = txt_Max_km_limit.Text;
                newRow.Cells[3].Value = txt_Extra_km_charge.Text;
                newRow.Cells[4].Value = txt_Max_hour_limit.Text;
                newRow.Cells[5].Value = txt_Extra_hour_charge.Text;
                newRow.Cells[6].Value = txt_total_hire_charge.Text;
                dgv_Current_Bill.Rows.Add(newRow);

                n++;    //ID Column value increament 1 by 1

                finalTotal = finalTotal + Convert.ToInt32(txt_total_hire_charge.Text);

                lbl_Amount.Text = "Rs " + finalTotal;

            }
        }

        //*****************Bill Transaction Records*****************Bill Transaction Records*****************Bill Transaction Records*****************Bill Transaction Records*****************

        private void insert_bill()  //Create a new method to insert records into Bill table
        {

            try
            {

                con.Open();
                cmd = new SqlCommand("INSERT INTO Bill_OneD_Hire_Table(Driver_Name,Date,Bill_Amount) VALUES('" + lbl_driver.Text + "' , '" + DateTime.Today.Date + "' ," +
                    " '" + finalTotal + "' )", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Bill added successfully!!!");

                display_data_grid_view_BILL();    //data grid view method



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        public void display_data_grid_view_BILL()    //For the Bill Table data grid view
        {
            try
            {
                lbl_driver.Text = Login_Form.user;   //Login user name display --> STEP 3 (Username Pass from Login Form to Billing Form)

                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("SELECT * FROM Bill_OneD_Hire_Table WHERE Driver_Name = '" + lbl_driver.Text + "'", con);
                adpt.Fill(dt);
                dgv_Bill_Trnsaction.DataSource = dt;
                con.Close();

                //This function will be passed to printing button. --> After printing a bill, this transaction record will be passed to Bill table.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        //**************For Bill Printing**************For Bill Printing**************For Bill Printing**************For Bill Printing**************For Bill Printing**************For Bill Printing**************

        //Print Document Tool double click and configuration
        int Hire_Package_ID;        
        int Per_km_value;
        int Max_km_limitation;
        int Extra_km_value;
        int Max_hour_limitation;
        int Extra_hour_value;
        int Total;
        int pos = 60;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Ayobo Drive", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID     Per_km_charge             Max_km_limit           Extra_km_charge           Max_hour_limit         Extra_hour_charge         TOTAL ", new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Red, new Point(26, 40));

            foreach (DataGridViewRow row in dgv_Current_Bill.Rows)
            {
                Hire_Package_ID = Convert.ToInt32(row.Cells["Column1"].Value);
                Per_km_value = Convert.ToInt32(row.Cells["Column2"].Value);
                Max_km_limitation = Convert.ToInt32(row.Cells["Column3"].Value);
                Extra_km_value = Convert.ToInt32(row.Cells["Column4"].Value);
                Max_hour_limitation = Convert.ToInt32(row.Cells["Column5"].Value);
                Extra_hour_value = Convert.ToInt32(row.Cells["Column6"].Value);
                Total = Convert.ToInt32(row.Cells["Column7"].Value);

                e.Graphics.DrawString("" + Hire_Package_ID, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + Per_km_value, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + Max_km_limitation, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + Extra_km_value, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + Max_hour_limitation, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                e.Graphics.DrawString("" + Extra_hour_value, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(295, pos));
                e.Graphics.DrawString("" + Total, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(345, pos));
                pos = pos + 20;
            }


            e.Graphics.DrawString("Final Total: " + lbl_Amount.Text, new Font("Century Gothic", 10, FontStyle.Italic), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("******************Ayubo Drive*******************", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(10, pos + 85));
            dgv_Current_Bill.Rows.Clear();
            dgv_Current_Bill.Refresh();
            pos = 100;
            lbl_Amount.Text = "0";
            n = 0;
        }

        //print button configuration
        private void btn_Print_Click(object sender, EventArgs e)
        {
            insert_bill();

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 400, 600);

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }


            display_data_grid_view_BILL();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_type.Text = "";
            txt_brand.Text = "";
            txt_model.Text = "";
            txt_colour.Text = "";
            txt_Per_km_charge.Text = "";
            txt_Max_km_limit.Text = "";
            txt_Extra_km_charge.Text = "";
            txt_Max_km_limit.Text = "";
            txt_Extra_km_charge.Text = "";
            cmb_refresh_category.Text = "";

            txt_reading_start.Text = "";
            txt_reading_end.Text = "";
            txt_distance.Text = "";
            txt_StartTime_H.Text = "";
            txt_StartTime_M.Text = "";
            txt_EndTime_H.Text = "";
            txt_EndTime_M.Text = "";
            txt_duration.Text = "";

            txt_total_km_charge.Text = "";
            txt_total_Extra_km_charge.Text = "";
            txt_total_Extra_hour_charge.Text = "";
            txt_total_hire_charge.Text = "";
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Details_OneD_Hire_Table WHERE OneD_Packages ='" + cmb_refresh_category.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv_Hiring_List.DataSource = dt;
        }

        
    }
}
