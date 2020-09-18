namespace dllInventoryScaners
{
    partial class frmEditTime
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.dgvEditTime = new System.Windows.Forms.DataGridView();
            this.numberScaner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Image = global::dllInventoryScaners.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(576, 291);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(35, 35);
            this.btSave.TabIndex = 0;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Image = global::dllInventoryScaners.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(617, 291);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(35, 35);
            this.btClose.TabIndex = 1;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dgvEditTime
            // 
            this.dgvEditTime.AllowUserToAddRows = false;
            this.dgvEditTime.AllowUserToDeleteRows = false;
            this.dgvEditTime.AllowUserToResizeRows = false;
            this.dgvEditTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEditTime.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvEditTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberScaner,
            this.id,
            this.timeStart,
            this.timeEnd,
            this.typeName});
            this.dgvEditTime.Location = new System.Drawing.Point(12, 12);
            this.dgvEditTime.MultiSelect = false;
            this.dgvEditTime.Name = "dgvEditTime";
            this.dgvEditTime.RowHeadersVisible = false;
            this.dgvEditTime.Size = new System.Drawing.Size(652, 269);
            this.dgvEditTime.TabIndex = 2;
            this.dgvEditTime.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEditTime_CellEndEdit);
            this.dgvEditTime.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvEditTime_EditingControlShowing);
            this.dgvEditTime.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEditTime_MouseDoubleClick);
            // 
            // numberScaner
            // 
            this.numberScaner.DataPropertyName = "numberScaner";
            this.numberScaner.HeaderText = "Номер сканера";
            this.numberScaner.Name = "numberScaner";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // timeStart
            // 
            this.timeStart.DataPropertyName = "timeStart";
            dataGridViewCellStyle1.Format = "T";
            dataGridViewCellStyle1.NullValue = null;
            this.timeStart.DefaultCellStyle = dataGridViewCellStyle1;
            this.timeStart.HeaderText = "Время взятия";
            this.timeStart.MaxInputLength = 8;
            this.timeStart.Name = "timeStart";
            // 
            // timeEnd
            // 
            this.timeEnd.DataPropertyName = "timeEnd";
            this.timeEnd.HeaderText = "Время сдачи";
            this.timeEnd.MaxInputLength = 8;
            this.timeEnd.Name = "timeEnd";
            // 
            // typeName
            // 
            this.typeName.DataPropertyName = "typeName";
            this.typeName.HeaderText = "Тип";
            this.typeName.Name = "typeName";
            this.typeName.ReadOnly = true;
            this.typeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::dllInventoryScaners.Properties.Resources.view2;
            this.btAdd.Location = new System.Drawing.Point(535, 291);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(35, 35);
            this.btAdd.TabIndex = 3;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // frmEditTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(676, 335);
            this.ControlBox = false;
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dgvEditTime);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование ведомости";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridView dgvEditTime;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberScaner;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeName;
    }
}