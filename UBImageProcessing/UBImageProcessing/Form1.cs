// UB Image Processing Tool
//Final Year Project
//CPSC 597A-A/597B-A
//ADV Probs-CPSC
//By: Saroj Poudyal 
//ID: 0732761


using System;
using System.Drawing;
using System.Windows.Forms;

namespace UBImageProcessing
{
    public partial class Form1 : Form
    {
        //Process all images as Bitmap
        Bitmap bitmapImage;
        double Zoom = 1.0;
        OpenFileDialog openDlg;

        public Form1()
        {
            InitializeComponent();
            bitmapImage = new Bitmap(2, 2);
        }

        private void subMenuOpen_Click(object sender, EventArgs e)
        {
            //Initiate open Dialogue Box
            openDlg = new OpenFileDialog();
         //   openDlg.InitialDirectory = "C:\\Documents and Settings\\saroj\\My Documents\\My Pictures";
            openDlg.InitialDirectory = "C:\\";
            //put filter on only select Image files
            openDlg.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            openDlg.FilterIndex = 2;
            openDlg.RestoreDirectory = true;

            if (DialogResult.OK == openDlg.ShowDialog())
            {
                bitmapImage = (Bitmap)Bitmap.FromFile(openDlg.FileName, false);
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size((int)(bitmapImage.Width * Zoom), (int)(bitmapImage.Height * Zoom));
                this.Invalidate();
            }

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //On paint Event , called everytime a change is done to the form/Image
            Graphics g = e.Graphics;
            g.DrawImage(bitmapImage, new Rectangle(this.AutoScrollPosition.X,this.AutoScrollPosition.Y,(int) (bitmapImage.Width * Zoom), (int) (bitmapImage.Height * Zoom)));


        }

        private void subMenuSave_Click(object sender, EventArgs e)
        {
            //Save Dialogue to Save the Modified Image
            SaveFileDialog saveDlg = new SaveFileDialog();
          //  saveDlg.InitialDirectory = "C:\\Documents and Settings\\saroj\\My Documents\\My Pictures";
            saveDlg.InitialDirectory = "C:\\";
            saveDlg.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveDlg.FilterIndex = 1;
            saveDlg.RestoreDirectory = true;

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                bitmapImage.Save(saveDlg.FileName);

            }


        }

        private void subMenuExit_Click(object sender, EventArgs e)
        {
            //Exit
            this.Close();
        }

        // Adjust the image to GrayScale 

        private void subMenuGrayScale_Click(object sender, EventArgs e)
        {
            if(Filters.GrayScale(bitmapImage))
            this.Invalidate();


        }

        private void subMenuColor_Click(object sender, EventArgs e)
        {
            //Gets the RGB Value from User and sets the image accoirdingly

            RGB_Input rgb_values = new RGB_Input();
            if (DialogResult.OK == rgb_values.ShowDialog())
            {
                if(Filters.Color(bitmapImage,rgb_values.redval,rgb_values.greenval,rgb_values.blueval))
                this.Invalidate();
            }

        }

        private void subMenuBrightness_Click(object sender, EventArgs e)
        {
            //Gets Brightness Value from User and sets the Brightness
           
            Brightness br = new Brightness();
            if (DialogResult.OK == br.ShowDialog())
            {
                if (Filters.Brightness(bitmapImage, br.brightval))
                    this.Invalidate();
            }

        }

        private void subMenuContrast_Click(object sender, EventArgs e)
        {
            
            //Gets Contrast Value from User and sets the Contrast
            //we are utilizing the same Brightness Dialogue Box to Get COntrast Value as well

            Brightness br = new Brightness();
            if (DialogResult.OK == br.ShowDialog())
            {
                if (Filters.Contrast(bitmapImage, (sbyte) br.brightval))
                    this.Invalidate();
            }
        }

        private void subMenuInvertColor_Click(object sender, EventArgs e)
        {
            //Just Invert the color of all the pixels
            if (Filters.Invert(bitmapImage))
                this.Invalidate();
        }

        private void subMenuGamma_Click(object sender, EventArgs e)
        {
            
            //Gets Gamma Value for RGB from User and sets the RGB Values
            Gamma_Input gamma = new Gamma_Input();
            if (DialogResult.OK == gamma.ShowDialog())
            {
                if(Filters.Gamma(bitmapImage,gamma.redval,gamma.greenval,gamma.blueval))
                    this.Invalidate();

            }

        }

        private void subMenuZoom100_Click(object sender, EventArgs e)
        {
            //zoom to 100%
            Zoom = 1.0;
            this.AutoScrollMinSize = new Size((int)(bitmapImage.Width * Zoom), (int)(bitmapImage.Height * Zoom));
            this.Invalidate();
        }

        private void subMenuZoom25_Click(object sender, EventArgs e)
        {
            //zoom to 25%
            Zoom = 0.25;
            this.AutoScrollMinSize = new Size((int)(bitmapImage.Width * Zoom), (int)(bitmapImage.Height * Zoom));
            this.Invalidate();
        }

        private void subMenuZoom50_Click(object sender, EventArgs e)
        {
            //zoom to 50%
            Zoom = 0.5;
            this.AutoScrollMinSize = new Size((int)(bitmapImage.Width * Zoom), (int)(bitmapImage.Height * Zoom));
            this.Invalidate();
        }

        private void subMenuZoom200_Click(object sender, EventArgs e)
        {
            //zoom to 20%
            Zoom = 2.0;
            this.AutoScrollMinSize = new Size((int)(bitmapImage.Width * Zoom), (int)(bitmapImage.Height * Zoom));
            this.Invalidate();
        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This Filter Rounds the Pixels to a range value so that the image turns smooth
           // set Pixel weight to 1 
                if(Filters.Smooth(bitmapImage,1))
                    this.Invalidate();

        }

        private void subMenuSharpen_Click(object sender, EventArgs e)
        {
            //This Filter is used to Sharpen the images by varying pixel values
            // set Pixel weight to 11
            if(Filters.Sharpen(bitmapImage,11))
                this.Invalidate();
        }

        private void subMenuBlur_Click(object sender, EventArgs e)
        {
            //Blur the image with pixel weight set to 4

            if (Filters.Blur(bitmapImage, 4))
                this.Invalidate();
        }

        private void subMenuMeanRemoval_Click(object sender, EventArgs e)
        {
            // meal removal technique with pixel weight 9
            if (Filters.MeanRemoval(bitmapImage, 9))
                this.Invalidate();
        }

        private void subMenuSimiliarImages_Click(object sender, EventArgs e)
        {
            // Similar Image detector tool for a different Image  set
            ImageSelector imgSelect = new ImageSelector();
            imgSelect.ShowDialog();

        }

        private void subMenuReload_Click(object sender, EventArgs e)
        {
            bitmapImage = (Bitmap)Bitmap.FromFile(openDlg.FileName, false);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size((int)(bitmapImage.Width * Zoom), (int)(bitmapImage.Height * Zoom));
            this.Invalidate();

        }

        
    }
}
