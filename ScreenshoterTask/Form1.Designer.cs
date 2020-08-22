namespace ScreenshoterTask
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.mtb_threads = new System.Windows.Forms.MaskedTextBox();
            this.mtb_timeout = new System.Windows.Forms.MaskedTextBox();
            this.tb_resolution = new System.Windows.Forms.TextBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_goToScreenshots = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(15, 154);
            this.tb_input.Multiline = true;
            this.tb_input.Name = "tb_input";
            this.tb_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_input.Size = new System.Drawing.Size(451, 241);
            this.tb_input.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resolution :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path to save screebshots : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Amount of threads  : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Timeout of HTTP connection :";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(154, 60);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(227, 20);
            this.tb_path.TabIndex = 5;
            this.tb_path.Text = "D:\\Projects\\Screenshoter\\Screenshoter\\ScreenshoterTask\\Screenshots";
            this.tb_path.Leave += new System.EventHandler(this.btn_goToScreenshots_Click);
            // 
            // mtb_threads
            // 
            this.mtb_threads.Location = new System.Drawing.Point(123, 93);
            this.mtb_threads.Mask = "00000";
            this.mtb_threads.Name = "mtb_threads";
            this.mtb_threads.Size = new System.Drawing.Size(32, 20);
            this.mtb_threads.TabIndex = 6;
            this.mtb_threads.Text = "2";
            this.mtb_threads.ValidatingType = typeof(int);
            // 
            // mtb_timeout
            // 
            this.mtb_timeout.Location = new System.Drawing.Point(169, 128);
            this.mtb_timeout.Mask = "00000";
            this.mtb_timeout.Name = "mtb_timeout";
            this.mtb_timeout.Size = new System.Drawing.Size(32, 20);
            this.mtb_timeout.TabIndex = 7;
            this.mtb_timeout.Text = "10";
            this.mtb_timeout.ValidatingType = typeof(int);
            // 
            // tb_resolution
            // 
            this.tb_resolution.AutoCompleteCustomSource.AddRange(new string[] {
            "1920x1080",
            "1280x1024",
            "1600x900",
            "1440x900",
            "1366x768",
            "1280x800",
            "1280x720"});
            this.tb_resolution.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_resolution.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tb_resolution.Location = new System.Drawing.Point(83, 25);
            this.tb_resolution.Name = "tb_resolution";
            this.tb_resolution.Size = new System.Drawing.Size(96, 20);
            this.tb_resolution.TabIndex = 8;
            this.tb_resolution.Text = "1366x768";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(391, 58);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 9;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(15, 415);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(133, 23);
            this.btn_start.TabIndex = 10;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_goToScreenshots
            // 
            this.btn_goToScreenshots.Location = new System.Drawing.Point(320, 415);
            this.btn_goToScreenshots.Name = "btn_goToScreenshots";
            this.btn_goToScreenshots.Size = new System.Drawing.Size(145, 23);
            this.btn_goToScreenshots.TabIndex = 11;
            this.btn_goToScreenshots.Text = "Go to screenshots directory";
            this.btn_goToScreenshots.UseVisualStyleBackColor = true;
            this.btn_goToScreenshots.Click += new System.EventHandler(this.btn_goToScreenshots_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.btn_goToScreenshots);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.tb_resolution);
            this.Controls.Add(this.mtb_timeout);
            this.Controls.Add(this.mtb_threads);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_input);
            this.Name = "Form1";
            this.Text = "Screenshoter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.MaskedTextBox mtb_threads;
        private System.Windows.Forms.MaskedTextBox mtb_timeout;
        private System.Windows.Forms.TextBox tb_resolution;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_goToScreenshots;
    }
}

