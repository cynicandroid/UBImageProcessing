// UB Image Processing Tool
//Final Year Project
//CPSC 597A-A/597B-A
//ADV Probs-CPSC
//By: Saroj Poudyal 
//ID: 0732761


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UBImageProcessing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
