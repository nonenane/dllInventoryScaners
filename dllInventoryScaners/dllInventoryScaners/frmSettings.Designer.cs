namespace dllInventoryScaners
{
    partial class frmSettings
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCountHour = new System.Windows.Forms.DataGridView();
            this.cStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClose = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountHour)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCountHour
            // 
            this.dgvCountHour.AllowUserToAddRows = false;
            this.dgvCountHour.AllowUserToDeleteRows = false;
            this.dgvCountHour.AllowUserToResizeRows = false;
            this.dgvCountHour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCountHour.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCountHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountHour.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cStart,
            this.cEnd,
            this.cDay});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCountHour.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCountHour.Location = new System.Drawing.Point(12, 12);
            this.dgvCountHour.MultiSelect = false;
            this.dgvCountHour.Name = "dgvCountHour";
            this.dgvCountHour.ReadOnly = true;
            this.dgvCountHour.RowHeadersVisible = false;
            this.dgvCountHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCountHour.Size = new System.Drawing.Size(436, 282);
            this.dgvCountHour.TabIndex = 0;
            // 
            // cStart
            // 
            this.cStart.DataPropertyName = "hourStart";
            this.cStart.HeaderText = "Начальное кол-во часов";
            this.cStart.Name = "cStart";
            this.cStart.ReadOnly = true;
            // 
            // cEnd
            // 
            this.cEnd.DataPropertyName = "hourEnd";
            this.cEnd.HeaderText = "Конечное кол-во часов";
            this.cEnd.Name = "cEnd";
            this.cEnd.ReadOnly = true;
            // 
            // cDay
            // 
            this.cDay.DataPropertyName = "day";
            this.cDay.HeaderText = "Кол-во отгулов";
            this.cDay.Name = "cDay";
            this.cDay.ReadOnly = true;
            // 
            // btClose
            // 
            this.btClose.Image = global::dllInventoryScaners.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(414, 300);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(34, 34);
            this.btClose.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btDel
            // 
            this.btDel.Image = global::dllInventoryScaners.Properties.Resources.editdelete_3805;
            this.btDel.Location = new System.Drawing.Point(374, 300);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(34, 34);
            this.btDel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btDel, "Удалить");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btEdit
            // 
            this.btEdit.Image = global::dllInventoryScaners.Properties.Resources.edit_1761;
            this.btEdit.Location = new System.Drawing.Point(334, 300);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(34, 34);
            this.btEdit.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btEdit, "Редактировать");
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Image = global::dllInventoryScaners.Properties.Resources.filetypes_7401;
            this.btAdd.Location = new System.Drawing.Point(294, 300);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(34, 34);
            this.btAdd.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btAdd, "Добавить");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 344);
            this.ControlBox = false;
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvCountHour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки отгулов";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountHour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCountHour;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDay;
    }
}