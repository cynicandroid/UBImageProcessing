using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UBImageProcessing
{
    public partial class Brightness : Form
    {
        public int brightval;
        public Brightness()
        {

            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Gets the Brightness (Contrast on seperate condition) Values from User and sets them
            brightval = Convert.ToInt32(txtValue.Text);

            if (brightval > 255) brightval = 255;
            if (brightval < -255) brightval = -255;

            btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}
