namespace dllInventoryScaners
{
    partial class frmAddScaner
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
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCodeBaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.btScaner = new System.Windows.Forms.Button();
            this.btBlank = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(356, 21);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "Выход";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код бейджика:";
            // 
            // tbCodeBaje
            // 
            this.tbCodeBaje.Location = new System.Drawing.Point(100, 9);
            this.tbCodeBaje.MaxLength = 13;
            this.tbCodeBaje.Name = "tbCodeBaje";
            this.tbCodeBaje.Size = new System.Drawing.Size(243, 20);
            this.tbCodeBaje.TabIndex = 0;
            this.tbCodeBaje.TextChanged += new System.EventHandler(this.tbCodeBaje_TextChanged);
            this.tbCodeBaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodeBaje_KeyDown);
            this.tbCodeBaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodeBaje_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ф.И.О.";
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(12, 61);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(420, 20);
            this.tbFIO.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Время:";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(243, 35);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(100, 20);
            this.tbTime.TabIndex = 2;
            // 
            // btScaner
            // 
            this.btScaner.Enabled = false;
            this.btScaner.Location = new System.Drawing.Point(100, 87);
            this.btScaner.Name = "btScaner";
            this.btScaner.Size = new System.Drawing.Size(75, 23);
            this.btScaner.TabIndex = 1;
            this.btScaner.Text = "Сканер";
            this.btScaner.UseVisualStyleBackColor = true;
            this.btScaner.Click += new System.EventHandler(this.btScaner_Click);
            // 
            // btBlank
            // 
            this.btBlank.Enabled = false;
            this.btBlank.Location = new System.Drawing.Point(268, 87);
            this.btBlank.Name = "btBlank";
            this.btBlank.Size = new System.Drawing.Size(75, 23);
            this.btBlank.TabIndex = 2;
            this.btBlank.Text = "Ведомость";
            this.btBlank.UseVisualStyleBackColor = true;
            this.btBlank.Click += new System.EventHandler(this.btBlank_Click);
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // frmAddScaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 115);
            this.ControlBox = false;
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCodeBaje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btBlank);
            this.Controls.Add(this.btScaner);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddScaner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выдача сканера/ведомости";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddScaner_FormClosing);
            this.Load += new System.EventHandler(this.frmAddScaner_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddScaner_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCodeBaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Button btScaner;
        private System.Windows.Forms.Button btBlank;
        private System.ComponentModel.BackgroundWorker bw;
    }
}