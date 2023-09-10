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
    public partial class Splash_Start_Form : Form
    {
        int startpoint = 0;

        public Splash_Start_Form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Value = startpoint;
            startpoint += 5;

            if (bunifuCircleProgressbar1.Value == 100)
            {
                timer1.Stop();

                Login_Form obj = new Login_Form();
                this.Hide();
                obj.Show();
            }
        }

        private void Splash_Start_Form_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
