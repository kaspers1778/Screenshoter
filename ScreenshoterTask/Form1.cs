using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshoterTask
{
    public partial class Form1 : Form
    {
        CloudScreenshoter Clscreenshoter;
        Screenshoter screenshoter;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            string resolution = tb_resolution.Text;
            string path = tb_path.Text;
            int threads = Convert.ToInt32(mtb_threads.Text);
            int timeout = Convert.ToInt32(mtb_timeout.Text);
            string input = tb_input.Text;
          //  Clscreenshoter = new CloudScreenshoter(resolution,path,threads,timeout,input);
            //Clscreenshoter.GetAllScreenshots();
            screenshoter = new Screenshoter(resolution, path, threads, timeout, input);
            screenshoter.GetAllScreenshots();



        }


        private void btn_goToScreenshots_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(tb_path.Text);
            }
            catch(Exception f)
            {
                MessageBox.Show("The invalid path to directory","EROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            tb_input.Clear();
            string newLine = Environment.NewLine;
            if (screenshoter.GetLogs().Count == 0)
            {
                tb_input.Text += "Running...\n";
            }
            else if(screenshoter.GetLogs().Count() == screenshoter.GetAmountOfURLs())
            {
                foreach (string result in screenshoter.GetLogs())
                {
                    tb_input.Text += "*" + result+";" + newLine ;
                }

                tb_input.Text += "Done";
            }
            else
            {
                tb_input.Text += "Running...\n";
                foreach (string result in screenshoter.GetLogs())
                {
                    tb_input.Text += "* " + result + ";" + newLine;
                }
            }
        }
    }
}
