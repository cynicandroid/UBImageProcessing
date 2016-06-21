using System;
using System.Windows.Forms;

namespace UBImageProcessing
{
    public partial class Gamma_Input : Form
    {
        public double redval, greenval, blueval;
        public Gamma_Input()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //get the user input value for RGB gamma values
            //if the value falls out of range, bring it to the range 

            redval = Convert.ToDouble(txtRed.Text);
            greenval = Convert.ToDouble(txtGreen.Text);
            blueval = Convert.ToDouble(txtBlue.Text);

            if (redval > 5.0) redval = 5.0;
            if (redval < 0.2) redval = 0.2;
            if (greenval > 5.0) greenval = 5.0;
            if (greenval < 0.2) greenval = 0.2;
            if (blueval > 5.0) blueval = 5.0;
            if (blueval < 0.2) blueval = 0.2;


            btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
