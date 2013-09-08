namespace VillaRentalProgramVol1
{
    partial class ServiceTraceWindow
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
            this.service_trace_logs = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // service_trace_logs
            // 
            this.service_trace_logs.BackColor = System.Drawing.Color.Black;
            this.service_trace_logs.Cursor = System.Windows.Forms.Cursors.Default;
            this.service_trace_logs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.service_trace_logs.ForeColor = System.Drawing.Color.Lime;
            this.service_trace_logs.Location = new System.Drawing.Point(12, 22);
            this.service_trace_logs.Name = "service_trace_logs";
            this.service_trace_logs.ReadOnly = true;
            this.service_trace_logs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.service_trace_logs.Size = new System.Drawing.Size(455, 470);
            this.service_trace_logs.TabIndex = 0;
            this.service_trace_logs.Text = "";
            // 
            // ServiceTraceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(479, 513);
            this.Controls.Add(this.service_trace_logs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ServiceTraceWindow";
            this.Text = "ServiceTraceWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox service_trace_logs;
    }
}