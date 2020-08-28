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
            string browser = "";
            if (rb_Chrome.Checked)
            {
                browser = "Chrome";
            }
            else if (rb_Firefox.Checked)
            {
                browser = "Firefox";
            }
            string resolution = tb_resolution.Text;
            string path = tb_path.Text;
            int threads = Convert.ToInt32(mtb_threads.Text);
            int timeout = Convert.ToInt32(mtb_timeout.Text);
            string input = tb_input.Text;
            screenshoter = new Screenshoter(resolution, path, threads, timeout,browser, input);
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
                tb_input.Text += "Running..." + newLine;
            }
            else if(screenshoter.GetLogs().Count() == screenshoter.GetAmountOfURLs())
            {
                foreach (string result in screenshoter.GetLogs())
                {
                    tb_input.Text += result+";" + newLine ;
                }

                tb_input.Text += "Done";
            }
            else
            {
                tb_input.Text += "Running..."+ newLine;
                foreach (string result in screenshoter.GetLogs())
                {
                    tb_input.Text += result + ";" + newLine;
                }
            }
        }
    }
}
