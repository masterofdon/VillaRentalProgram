namespace VillaRentalProgramVol1
{
    partial class MainWindow
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
            this.btn_cts = new System.Windows.Forms.Button();
            this.btn_user_options = new System.Windows.Forms.Button();
            this.btn_about_me = new System.Windows.Forms.Button();
            this.pb_progress_indicator = new System.Windows.Forms.ProgressBar();
            this.lbl_progress_indicator = new System.Windows.Forms.Label();
            this.lbl_progress_value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cts
            // 
            this.btn_cts.BackColor = System.Drawing.Color.Gray;
            this.btn_cts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cts.ForeColor = System.Drawing.Color.Lime;
            this.btn_cts.Location = new System.Drawing.Point(52, 55);
            this.btn_cts.Name = "btn_cts";
            this.btn_cts.Size = new System.Drawing.Size(220, 36);
            this.btn_cts.TabIndex = 0;
            this.btn_cts.Text = "Connect To Sites";
            this.btn_cts.UseVisualStyleBackColor = false;
            this.btn_cts.Click += new System.EventHandler(this.btn_cts_Click);
            // 
            // btn_user_options
            // 
            this.btn_user_options.BackColor = System.Drawing.Color.Gray;
            this.btn_user_options.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_user_options.ForeColor = System.Drawing.Color.Lime;
            this.btn_user_options.Location = new System.Drawing.Point(52, 138);
            this.btn_user_options.Name = "btn_user_options";
            this.btn_user_options.Size = new System.Drawing.Size(220, 36);
            this.btn_user_options.TabIndex = 1;
            this.btn_user_options.Text = "User Options";
            this.btn_user_options.UseVisualStyleBackColor = false;
            this.btn_user_options.Click += new System.EventHandler(this.btn_user_options_Click);
            // 
            // btn_about_me
            // 
            this.btn_about_me.BackColor = System.Drawing.Color.Gray;
            this.btn_about_me.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_about_me.ForeColor = System.Drawing.Color.Lime;
            this.btn_about_me.Location = new System.Drawing.Point(52, 223);
            this.btn_about_me.Name = "btn_about_me";
            this.btn_about_me.Size = new System.Drawing.Size(220, 36);
            this.btn_about_me.TabIndex = 2;
            this.btn_about_me.Text = "About Me!";
            this.btn_about_me.UseVisualStyleBackColor = false;
            this.btn_about_me.Click += new System.EventHandler(this.btn_about_me_Click);
            // 
            // pb_progress_indicator
            // 
            this.pb_progress_indicator.BackColor = System.Drawing.SystemColors.Info;
            this.pb_progress_indicator.ForeColor = System.Drawing.Color.Lime;
            this.pb_progress_indicator.Location = new System.Drawing.Point(52, 422);
            this.pb_progress_indicator.Name = "pb_progress_indicator";
            this.pb_progress_indicator.Size = new System.Drawing.Size(699, 28);
            this.pb_progress_indicator.TabIndex = 3;
            // 
            // lbl_progress_indicator
            // 
            this.lbl_progress_indicator.AutoSize = true;
            this.lbl_progress_indicator.BackColor = System.Drawing.SystemColors.InfoText;
            this.lbl_progress_indicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_progress_indicator.ForeColor = System.Drawing.Color.Lime;
            this.lbl_progress_indicator.Location = new System.Drawing.Point(49, 366);
            this.lbl_progress_indicator.Name = "lbl_progress_indicator";
            this.lbl_progress_indicator.Size = new System.Drawing.Size(143, 16);
            this.lbl_progress_indicator.TabIndex = 4;
            this.lbl_progress_indicator.Text = "Progress Indicator :";
            // 
            // lbl_progress_value
            // 
            this.lbl_progress_value.AutoSize = true;
            this.lbl_progress_value.ForeColor = System.Drawing.Color.Lime;
            this.lbl_progress_value.Location = new System.Drawing.Point(197, 366);
            this.lbl_progress_value.Name = "lbl_progress_value";
            this.lbl_progress_value.Size = new System.Drawing.Size(0, 13);
            this.lbl_progress_value.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(835, 492);
            this.Controls.Add(this.lbl_progress_value);
            this.Controls.Add(this.lbl_progress_indicator);
            this.Controls.Add(this.pb_progress_indicator);
            this.Controls.Add(this.btn_about_me);
            this.Controls.Add(this.btn_user_options);
            this.Controls.Add(this.btn_cts);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cts;
        private System.Windows.Forms.Button btn_user_options;
        private System.Windows.Forms.Button btn_about_me;
        private System.Windows.Forms.ProgressBar pb_progress_indicator;
        private System.Windows.Forms.Label lbl_progress_indicator;
        private System.Windows.Forms.Label lbl_progress_value;
    }
}