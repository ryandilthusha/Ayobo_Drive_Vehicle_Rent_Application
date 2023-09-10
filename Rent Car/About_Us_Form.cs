using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_Car
{
    public partial class About_Us_Form : Form
    {
        public About_Us_Form()
        {
            InitializeComponent();

            lbl_driver.Text = Login_Form.user;   //Login user name display --> STEP 3 (Username Pass from Login Form to Billing Form)
        }

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

        private void btn_MyProfile_Click(object sender, EventArgs e)
        {
            My_Profile_Form obj = new My_Profile_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Login_Form obj = new Login_Form();
            obj.Show();
            this.Hide();
        }

        



    }
}
