// UB Image Processing Tool
//Final Year Project
//CPSC 597A-A/597B-A
//ADV Probs-CPSC
//By: Saroj Poudyal 
//ID: 0732761

using System;
using System.Windows.Forms;

namespace UBImageProcessing
{

    public partial class RGB_Input : Form
    {
        public int redval, greenval, blueval;
       
        public RGB_Input()
        {
            InitializeComponent();
           
        }

        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Get user input for RGB values from user
            //If the value falls out of range , adjust to get it into the range

            redval = Convert.ToInt32(txtRed.Text);
            greenval = Convert.ToInt32(txtGreen.Text);
            blueval = Convert.ToInt32(txtBlue.Text);

            if (redval > 255) redval = 255;
            if (redval < -255) redval = -255;
            if (greenval > 255) greenval = 255;
            if (greenval < -255) greenval = -255;
            if (blueval > 255) blueval = 255;
            if (blueval < -255) blueval = -255;
             

            btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
