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
    public partial class Rent_Form : Form
    {
        public Rent_Form()
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
            txt_daily_rent.Text = "";
            txt_weekly_rent.Text = "";
            txt_monthly_rent.Text = "";
            cmb_refresh_category.Text = "";

            dtp_start.Value = DateTime.Now;
            dtp_end.Value = DateTime.Now;
            txt_calculate.Text = "";
            rbtn_yes.Checked = false;
            rbtn_no.Checked = false;


        }

        public void display_data_grid_view()    //For the data grid view
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


        int day_rent;
        int week_rent;
        int month_rent;
        int driver_charge;
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
                day_rent = Convert.ToInt32(txt_daily_rent.Text = DR1.GetValue(5).ToString());           //should Covert to int, becz we calculate them when adding the bill
                week_rent = Convert.ToInt32(txt_weekly_rent.Text = DR1.GetValue(6).ToString());         //should Covert to int, becz we calculate them when adding the bill
                month_rent = Convert.ToInt32(txt_monthly_rent.Text = DR1.GetValue(7).ToString());       //should Covert to int, becz we calculate them when adding the bill
                driver_charge = Convert.ToInt32(txt_driver_rate.Text = DR1.GetValue(8).ToString());     //should Covert to int, becz we calculate them when adding the bill

            }
            DR1.Close();
            con.Close();
        }

        
        
        //********************************* CALCULATION PART **********************************************************************************************************************

        //CALCULATION PART

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            Boolean driverYES_checked = rbtn_yes.Checked;
            Boolean driverNO_checked = rbtn_no.Checked;

            DateTime date1 = dtp_start.Value.Date;
            DateTime date2 = dtp_end.Value.Date;

            TimeSpan date_dif = date2 - date1;

            int days = date_dif.Days;       //Convert date differences into intger



            int cal = 0;
            if (driverYES_checked)
            {
                if (Convert.ToInt32(days) <= 7)
                {
                    int Days_rent = Convert.ToInt32(txt_daily_rent.Text) * Convert.ToInt32(days);
                    int driver_charge = Convert.ToInt32(txt_driver_rate.Text) * Convert.ToInt32(days);


                    cal = driver_charge + Days_rent;

                    //display data
                    txt_calculate.Text = Convert.ToString(cal);
                    txt_charge_Days.Text = Convert.ToString(Days_rent);
                    txt_charge_Weeks.Text = Convert.ToString("0");
                    txt_charge_Months.Text = Convert.ToString("0");
                    txt_charge_Driver.Text = Convert.ToString(driver_charge);
                }
                else if (Convert.ToInt32(days) < 30)
                {
                    int Weeks = (int)Math.Floor(Convert.ToInt32(days) / 7.0);    //to get weeks --> ex: 17 //7 =2
                    int leftDays = Convert.ToInt32(days) % 7;                    //to get days after weeks --> ex : 17 % 7 = 3

                    int Weeks_rent = Weeks * Convert.ToInt32(txt_weekly_rent.Text);
                    int Days_rent = leftDays * Convert.ToInt32(txt_daily_rent.Text);
                    int driver_charge = Convert.ToInt32(txt_driver_rate.Text) * Convert.ToInt32(days);

                    cal = driver_charge + Weeks_rent + Days_rent;

                    //display data
                    txt_calculate.Text = Convert.ToString(cal);
                    txt_charge_Days.Text = Convert.ToString(Days_rent);
                    txt_charge_Weeks.Text = Convert.ToString(Weeks_rent);
                    txt_charge_Months.Text = Convert.ToString("0");
                    txt_charge_Driver.Text = Convert.ToString(driver_charge);

                }
                else if (Convert.ToInt32(days) >= 30)
                {
                    int Months = (int)Math.Floor(Convert.ToInt32(days) / 30.0);  //to get months --> ex: 59//30 = 1
                    int leftDaysMonth = Convert.ToInt32(days) % 30;              //to get days after months  --> ex 59%30 = 29

                    int Weeks = (int)Math.Floor(leftDaysMonth / 7.0);     //to get number of weeks --> ex 29//7 = 4
                    int leftDays = leftDaysMonth % 7;                    //to get days after weeks --> ex 29%7 = 1

                    int Months_rent = Months * Convert.ToInt32(txt_monthly_rent.Text);
                    int Weeks_rent = Weeks * Convert.ToInt32(txt_weekly_rent.Text);
                    int Days_rent = leftDays * Convert.ToInt32(txt_daily_rent.Text);
                    int driver_charge = Convert.ToInt32(txt_driver_rate.Text) * Convert.ToInt32(days);

                    cal = driver_charge + Months_rent + Weeks_rent + Days_rent;

                    //display data
                    txt_calculate.Text = Convert.ToString(cal);
                    txt_charge_Days.Text = Convert.ToString(Days_rent);
                    txt_charge_Weeks.Text = Convert.ToString(Weeks_rent);
                    txt_charge_Months.Text = Convert.ToString(Months_rent);
                    txt_charge_Driver.Text = Convert.ToString(driver_charge);

                }

            }
            else if (driverNO_checked)
            {
                if (Convert.ToInt32(days) <= 7)
                {
                    int Days_rent = Convert.ToInt32(txt_daily_rent.Text) * Convert.ToInt32(days);
                    


                    cal = Days_rent;

                    //display data
                    txt_calculate.Text = Convert.ToString(cal);
                    txt_charge_Days.Text = Convert.ToString(Days_rent);
                    txt_charge_Weeks.Text = Convert.ToString("0");
                    txt_charge_Months.Text = Convert.ToString("0");
                    txt_charge_Driver.Text = Convert.ToString("0");

                }
                else if (Convert.ToInt32(days) < 30)
                {
                    int Weeks = (int)Math.Floor(Convert.ToInt32(days) / 7.0);    //to get weeks --> ex: 17 //7 =2
                    int leftDays = Convert.ToInt32(days) % 7;                    //to get days after weeks --> ex : 17 % 7 = 3

                    int Weeks_rent = Weeks * Convert.ToInt32(txt_weekly_rent.Text);
                    int Days_rent = leftDays * Convert.ToInt32(txt_daily_rent.Text);
                    

                    cal = Weeks_rent + Days_rent;

                    //display data
                    txt_calculate.Text = Convert.ToString(cal);
                    txt_charge_Days.Text = Convert.ToString(Days_rent);
                    txt_charge_Weeks.Text = Convert.ToString(Weeks_rent);
                    txt_charge_Months.Text = Convert.ToString("0");
                    txt_charge_Driver.Text = Convert.ToString("0");


                }
                else if (Convert.ToInt32(days) >= 30)
                {
                    int Months = (int)Math.Floor(Convert.ToInt32(days) / 30.0);  //to get months --> ex: 59//30 = 1
                    int leftDaysMonth = Convert.ToInt32(days ) % 30;              //to get days after months  --> ex 59%30 = 29

                    int Weeks = (int)Math.Floor(leftDaysMonth / 7.0);     //to get number of weeks --> ex 29//7 = 4
                    int leftDays = leftDaysMonth % 7;                    //to get days after weeks --> ex 29%7 = 1

                    int Months_rent = Months * Convert.ToInt32(txt_monthly_rent.Text);
                    int Weeks_rent = Weeks * Convert.ToInt32(txt_weekly_rent.Text);
                    int Days_rent = leftDays * Convert.ToInt32(txt_daily_rent.Text);
                    

                    cal = Months_rent + Weeks_rent + Days_rent;

                    //display data
                    txt_calculate.Text = Convert.ToString(cal);
                    txt_charge_Days.Text = Convert.ToString(Days_rent);
                    txt_charge_Weeks.Text = Convert.ToString(Weeks_rent);
                    txt_charge_Months.Text = Convert.ToString(Months_rent);
                    txt_charge_Driver.Text = Convert.ToString("0");

                }

            }

        }


        //**************Add to Bill Button**************Add to Bill Button**************Add to Bill Button**************Add to Bill Button**************Add to Bill Button**************

        int finalTotal = 0;
        int n = 0;
        private void btn_AddToBill_Click(object sender, EventArgs e)
        {
            if (txt_type.Text == "" && txt_brand.Text == "" && txt_model.Text == "" && txt_colour.Text == "" && txt_daily_rent.Text == "" && txt_weekly_rent.Text == "" && txt_monthly_rent.Text == "" && txt_calculate.Text == "" || txt_driver_rate.Text == "")
            {
                MessageBox.Show("Enter Renting Details Please");
            }            
            else
            {               

                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgv_Current_Bill);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = txt_daily_rent.Text;
                newRow.Cells[2].Value = txt_weekly_rent.Text;
                newRow.Cells[3].Value = txt_monthly_rent.Text;
                newRow.Cells[4].Value = txt_driver_rate.Text;
                newRow.Cells[5].Value = txt_calculate.Text;                
                dgv_Current_Bill.Rows.Add(newRow);

                n++;    //ID Column value increament 1 by 1

                finalTotal = finalTotal + Convert.ToInt32(txt_calculate.Text);

                lbl_Amount.Text = "Rs " + finalTotal;                

            }
        }

        
        //*****************Bill Transaction Records*****************Bill Transaction Records*****************Bill Transaction Records*****************Bill Transaction Records*****************

        private void insert_bill()  //Create a new method to insert records into Bill table
        {

            try
            {

                con.Open();
                cmd = new SqlCommand("INSERT INTO Bill_Rent_Table(Driver_Name,Date,Bill_Amount) VALUES('" + lbl_driver.Text + "' , '" + DateTime.Today.Date + "' ," +
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
                adpt = new SqlDataAdapter("SELECT * FROM Bill_Rent_Table WHERE Driver_Name = '" + lbl_driver.Text + "'", con);
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
        int Rent_Package_ID;
        int Day_Rent;
        int Week_Rent;
        int Month_Rent;
        int Driver_Charge;
        int Total;
        int pos = 60;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Ayobo Drive", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID     Day Rent                Week Rent            Month Rent         Driver Charge           TOTAL ", new Font("Century Gothic", 5, FontStyle.Bold), Brushes.Red, new Point(26, 40));

            foreach (DataGridViewRow row in dgv_Current_Bill.Rows)
            {
                Rent_Package_ID = Convert.ToInt32(row.Cells["Column1"].Value);
                Day_Rent = Convert.ToInt32(row.Cells["Column2"].Value);
                Week_Rent = Convert.ToInt32(row.Cells["Column3"].Value);
                Month_Rent = Convert.ToInt32(row.Cells["Column4"].Value);
                Driver_Charge = Convert.ToInt32(row.Cells["Column5"].Value);
                Total = Convert.ToInt32(row.Cells["Column6"].Value);

                e.Graphics.DrawString("" + Rent_Package_ID, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + Day_Rent, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + Week_Rent, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + Month_Rent, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + Driver_Charge, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                e.Graphics.DrawString("" + Total, new Font("Century Gothic", 4, FontStyle.Bold), Brushes.Blue, new Point(295, pos));
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

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 350, 600);

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
            txt_daily_rent.Text = "";
            txt_weekly_rent.Text = "";
            txt_monthly_rent.Text = "";
            cmb_refresh_category.Text = "";

            dtp_start.Value = DateTime.Now;
            dtp_end.Value = DateTime.Now;
            txt_calculate.Text = "";
            rbtn_yes.Checked = false;
            rbtn_no.Checked = false;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Details_Renting_Table WHERE Veh_Type ='" + cmb_refresh_category.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgv_Renting_List.DataSource = dt;
        }

        
    }
}
