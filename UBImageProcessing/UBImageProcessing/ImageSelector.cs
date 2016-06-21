// UB Image Processing Tool
//Final Year Project
//CPSC 597A-A/597B-A
//ADV Probs-CPSC
//By: Saroj Poudyal 
//ID: 0732761

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UBImageProcessing.Properties;
using UBImageProcessing.Processing;
using System.IO;
using System.Threading;

namespace UBImageProcessing
{
    public partial class ImageSelector : Form
    {
        //Declare Variables
        List<string> ImageDirectory;
        List<int> processed;
        List<ComparableBitmap> bitmaps;
        Dictionary<ComparableBitmap, List<ComparableBitmap>> comparisions;
        BackgroundWorker imageBGWorker;
        event EventHandler onSimilarImageFound;


        public ImageSelector()
        {
            InitializeComponent();
                       
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Selecting the image folder to compare images
            if(imageFolderBrowser.ShowDialog(this) ==DialogResult.OK)
            {
                txtImageFolder.Text = imageFolderBrowser.SelectedPath;
                ImageDirectory= new List<string>();
                ImageDirectory.Add(txtImageFolder.Text);
                btnProcess.Enabled = true;
                restoreDefaults();

            }
     
        }

        void restoreDefaults()
        {
            //restoring window size 
            this.MinimumSize = new Size(450,150);
            this.Size = this.MinimumSize;
         
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //Process the images of the selected folder from folder Browser
            //If BackGround work is already busy/Processing cancel this Process
            //Else Start Searching
            if (imageBGWorker != null && imageBGWorker.IsBusy)
                imageBGWorker.CancelAsync();
            else
                imageSearchBegin();
          
        }

        private void imageSearchBegin()
        {
            lstImageResult.Items.Clear();
           
            //EventHandler to handle Similar image found action
            onSimilarImageFound += new EventHandler(ImageSelector_onSimilarImageFound);
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            
            //start a new Backgroundwork to process image
            imageBGWorker = new BackgroundWorker();
            imageBGWorker.WorkerReportsProgress = imageBGWorker.WorkerSupportsCancellation = true;
            
            //3 event Handlers triggered on workdone, Progress changed and process Completed
            imageBGWorker.DoWork += new DoWorkEventHandler(imageBGWorker_DoWork);
            imageBGWorker.ProgressChanged += new ProgressChangedEventHandler(imageBGWorker_ProgressChanged);
            imageBGWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(imageBGWorker_RunWorkerCompleted);
            imageBGWorker.RunWorkerAsync();

        }

        void imageBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           //Trigerred when the job of searching is complete
            progressBar1.Visible = false;
          
            //Matching Images not found
            if (comparisions == null || lstImageResult.Items.Count <= 0)
                MessageBox.Show(this,"No Matching Images", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //similar images found, so trigger this eventHandler
            onSimilarImageFound -= new EventHandler(ImageSelector_onSimilarImageFound);
            bitmaps.Clear();
        }

        void imageBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           //Just Update the progress Bar
           progressBar1.Value = e.ProgressPercentage;
           
        }

        void imageBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           //Processing list of images
            bitmaps = new List<ComparableBitmap>();
            for(int i=0;i<ImageDirectory.Count;i++)
            {
                if(imageBGWorker.CancellationPending)
                    break;
                enumFiles(ImageDirectory[i], (int)((double)(i / 2) / (double)ImageDirectory.Count * 100));
                compareFiles((int)((double)(i) / (double)ImageDirectory.Count * 100));
                
            }
            
        }

        void enumFiles(string path, int progress)
        {
            // index image files and add the files to the bitmap file List with comparision for supported extension

            string[] files = getImgFiles(path, Settings.Default.SupporterFileExtentions.Split(';'));

            for (int i = 0; i < files.Length; i++)
            {
                if (imageBGWorker.CancellationPending)
                    break;
               
                bitmaps.Add(new ComparableBitmap(files[i]));
                imageBGWorker.ReportProgress((int)((double)i / (double)files.Length * 100),"Loading Images");
                
            }

        }

        string[] getImgFiles(string path, string[] extentions)
        {
            //get the image file from the path provided
            List<string> files = new List<string>();
            for (int i = 0; i < extentions.Length; i++)
            {
          files.AddRange(Directory.GetFiles(path,string.Format("*.{0}",extentions[i]),SearchOption.AllDirectories));
            }
            return files.ToArray();
        }

        void compareFiles(int progress)
        {
            //Create a new Dictionary with key as bitmap image and value as the acutal image from the Bitmap Image List
            if (bitmaps == null)
                return;
            comparisions = new Dictionary<ComparableBitmap, List<ComparableBitmap>>();
            processed = new List<int>();
            double p = 0;


            for (int i = 0; i < bitmaps.Count; i++)
            {
                if (imageBGWorker.CancellationPending)
                    break;

                if (!processed.Contains(i) && !comparisions.ContainsKey(bitmaps[i]))
                {
                    //Add the selected bitmap image into Dictionary with value as new ListItem to Bitmap List
                    comparisions.Add(bitmaps[i], new List<ComparableBitmap>());
                    processed.Add(i);
                    
                    //Create a Thread Queue with maxmium of 10 Threads
                    //Divide total images for Processing equally into all 10 threads
                    ThreadQueue q = new ThreadQueue(bitmaps.Count / 10);

                  //Normalized Levenshtein Distance Metric is an Algorithm for finding Normalized edit distance between
                  //two matric points which returns a edit distance 
                    Levenshtein alg = new Levenshtein();

                    for (int j = 0; j < bitmaps.Count; j++)
                    {
                        if (imageBGWorker.CancellationPending)
                            break;
                        q.QueueUserWorkItem((WaitCallback)delegate(object a)
                        {
                            int r = (int)a;
                            if (i != r && !processed.Contains(r))
                            {
                                //returns edit distance between two bitmap images
                                int k = alg.GetDistance<byte>(bitmaps[i], bitmaps[r]);
                                if (k <= Settings.Default.SimilarityTreshold)
                                {
                                    bitmaps[r].Similarity = k;
                                    comparisions[bitmaps[i]].Add(bitmaps[r]);
                                    processed.Add(r);
                                    if (onSimilarImageFound != null)
                                    {

                                        onSimilarImageFound(this, null);
                                    }
                                }
                            }


                        }, j);
                        imageBGWorker.ReportProgress((int)(++p / (double)(bitmaps.Count * bitmaps.Count) * 100),"Comparing Images");
                       
                    }
                    q.WaitAll();

                }

            }

        }


        void ImageSelector_onSimilarImageFound(object sender, EventArgs e)
        {
            //on similar image detection, list them in ImageResult and ImageDupe ListView
            fillData();
        }
       
        void fillData()
        {

         
            this.BeginInvoke((SendOrPostCallback)delegate
            {
                //populate the ImageResult and ImageDupe ListView
                ListView.SelectedIndexCollection rIdx = lstImageResult.SelectedIndices;
                ListView.SelectedIndexCollection dIdx = lstImageDupe.SelectedIndices;
                int iR = rIdx.Count > 0 ? rIdx[0] : -1;
                int iD = dIdx.Count > 0 ? dIdx[0] : -1;

                this.MinimumSize = new Size(539, 442);
                lstImageResult.Items.Clear();
                lstImageDupe.Items.Clear();
                foreach (ComparableBitmap cb in comparisions.Keys)
                {
                    List<ComparableBitmap> val;
                    if (comparisions.TryGetValue(cb, out val) && val.Count > 0)
                    {
                        string ar = cb.Path.Substring(cb.Path.LastIndexOf('\\') + 1);
                        lstImageResult.Items.Add(ar);
                    }
                }
                if (lstImageResult.Items.Count <= iR)
                    iR = lstImageResult.Items.Count - 1;

                if (lstImageDupe.Items.Count <= iD)
                    iD = lstImageDupe.Items.Count - 1;

                if (iR != -1 & lstImageResult.Items.Count > 0)
                {

                    lstImageResult.SelectedIndices.Add(iR);
                }
                if (iD != -1 & lstImageDupe.Items.Count > 0)
                {

                    lstImageDupe.SelectedIndices.Add(iD);
                }

                if (lstImageResult.Items.Count <= 0)
                    restoreDefaults();

            }, new object[] { null });
        }

        
        KeyValuePair<ComparableBitmap, List<ComparableBitmap>> getItemByParticalKeyName(string name)
        {
            foreach (ComparableBitmap b in comparisions.Keys)
            {
                if (b.Path.Contains(name))
                    return new KeyValuePair<ComparableBitmap, List<ComparableBitmap>>(b, comparisions[b]);
            }
            return new KeyValuePair<ComparableBitmap, List<ComparableBitmap>>();

        }

        double getRatio(Size s)
        {
            //simply get the image width to hight ratio
            //Make sure the ratio is always less than 1

            double r = 0;
            if (s.Width < s.Height)
                r = (double)sourceImage.Width / (double)s.Width;
            else
                r = (double)sourceImage.Height / (double)s.Height;
            return r;
        }
        KeyValuePair<ComparableBitmap, List<ComparableBitmap>> kvp;
        private void lstImageResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EventHandler to populate similar images Names in ImageDupe ListView
            //when the Source image is selected from ImageResult View
            lstImageDupe.Items.Clear();
            if (lstImageResult.SelectedItems.Count > 0)
            {
                string str = lstImageResult.SelectedItems[0].Text;
                kvp = getItemByParticalKeyName(str);

                Size s = displayPreviewImages();
                for (int i = 0; i < kvp.Value.Count; i++)
                {

                    ListViewItem item = new ListViewItem(new string[] {kvp.Value[i].Path.Substring(kvp.Value[i].Path.LastIndexOf('\\') + 1),
                    string.Format("{0:N2}%",100 - ((double)kvp.Value[0].Similarity / (double)Settings.Default.SimilarityTreshold * 100))});
                    lstImageDupe.Items.Add(item);
                }

            }
        }

        private void lstImageDupe_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EventHandler to Populate Image in the window when an item is selected in ImageDupe ListView
            if (kvp.Key != null && lstImageDupe.SelectedIndices.Count > 0)
            {
                displayPreviewDuplicate(lstImageDupe.SelectedIndices[0]);
            }
        }

        private Size displayPreviewDuplicate(int idx)
        {
            //get the similar image( matching to Source) for Preview as Picture2
            if (kvp.Key != null)
            {
                Image b = Image.FromFile(kvp.Value[idx].Path);
                if (similarImage.Image != null)
                {
                    similarImage.Image.Dispose();
                    similarImage.Image = null;
                }
                similarImage.Image = b.GetThumbnailImage((int)(b.Width * getRatio(b.Size)), (int)(b.Height * getRatio(b.Size)), null, IntPtr.Zero);
                similarImage.Tag = kvp.Value[idx].Path;
               
                return b.Size;
            }
            return Size.Empty;
        }

        private Size displayPreviewImages()
        {
            //get the Original Image for Preview as Picture1
            if (kvp.Key != null)
            {
                Image b = Image.FromFile(kvp.Key.Path);
                if (sourceImage.Image != null)
                {
                    sourceImage.Image.Dispose();
                    sourceImage.Image = null;
                }
                sourceImage.Image = b.GetThumbnailImage((int)(b.Width * getRatio(b.Size)), (int)(b.Height * getRatio(b.Size)), null, IntPtr.Zero);
                sourceImage.Tag = kvp.Key.Path;
                if (similarImage.Image != null)
                {
                    similarImage.Image.Dispose();
                    similarImage.Image = null;
                   
                }
             
                return b.Size;
            }
            return Size.Empty;
        }

        
    }
}
