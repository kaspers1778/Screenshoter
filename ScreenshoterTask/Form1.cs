using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshoterTask
{
    public partial class Form1 : Form
    {
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
            Screenshoter screenshoter = new Screenshoter(resolution,path,threads,timeout,input);
            screenshoter.GetAllScreenshots();
        }
    }
}
