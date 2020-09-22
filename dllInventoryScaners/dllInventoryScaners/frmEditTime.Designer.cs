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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.dgvEditTime = new System.Windows.Forms.DataGridView();
            this.btAdd = new System.Windows.Forms.Button();
            this.btAddKadr = new System.Windows.Forms.Button();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbK21 = new System.Windows.Forms.RadioButton();
            this.rbX14 = new System.Windows.Forms.RadioButton();
            this.lShop = new System.Windows.Forms.Label();
            this.numberScaner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStart = new dllInventoryScaners.datetimeCellCalendare.CalendarColumn();
            this.timeEnd = new dllInventoryScaners.datetimeCellCalendare.CalendarColumn();
            this.typeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEditTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEditTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberScaner,
            this.id,
            this.timeStart,
            this.timeEnd,
            this.typeName});
            this.dgvEditTime.Location = new System.Drawing.Point(12, 62);
            this.dgvEditTime.MultiSelect = false;
            this.dgvEditTime.Name = "dgvEditTime";
            this.dgvEditTime.RowHeadersVisible = false;
            this.dgvEditTime.Size = new System.Drawing.Size(652, 219);
            this.dgvEditTime.TabIndex = 2;
            this.dgvEditTime.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEditTime_CellEndEdit);
            this.dgvEditTime.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvEditTime_EditingControlShowing);
            this.dgvEditTime.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEditTime_MouseDoubleClick);
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
            // btAddKadr
            // 
            this.btAddKadr.Location = new System.Drawing.Point(629, 13);
            this.btAddKadr.Name = "btAddKadr";
            this.btAddKadr.Size = new System.Drawing.Size(35, 20);
            this.btAddKadr.TabIndex = 4;
            this.btAddKadr.Text = "...";
            this.btAddKadr.UseVisualStyleBackColor = true;
            this.btAddKadr.Click += new System.EventHandler(this.btAddKadr_Click);
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(80, 13);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(543, 20);
            this.tbFIO.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сотрудник";
            // 
            // rbK21
            // 
            this.rbK21.AutoSize = true;
            this.rbK21.Location = new System.Drawing.Point(81, 39);
            this.rbK21.Name = "rbK21";
            this.rbK21.Size = new System.Drawing.Size(44, 17);
            this.rbK21.TabIndex = 7;
            this.rbK21.TabStop = true;
            this.rbK21.Text = "K21";
            this.rbK21.UseVisualStyleBackColor = true;
            // 
            // rbX14
            // 
            this.rbX14.AutoSize = true;
            this.rbX14.Location = new System.Drawing.Point(131, 39);
            this.rbX14.Name = "rbX14";
            this.rbX14.Size = new System.Drawing.Size(44, 17);
            this.rbX14.TabIndex = 7;
            this.rbX14.TabStop = true;
            this.rbX14.Text = "X14";
            this.rbX14.UseVisualStyleBackColor = true;
            // 
            // lShop
            // 
            this.lShop.AutoSize = true;
            this.lShop.Location = new System.Drawing.Point(15, 41);
            this.lShop.Name = "lShop";
            this.lShop.Size = new System.Drawing.Size(51, 13);
            this.lShop.TabIndex = 6;
            this.lShop.Text = "Магазин";
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
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.timeStart.DefaultCellStyle = dataGridViewCellStyle2;
            this.timeStart.HeaderText = "Время взятия";
            this.timeStart.Name = "timeStart";
            this.timeStart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // timeEnd
            // 
            this.timeEnd.DataPropertyName = "timeEnd";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.timeEnd.DefaultCellStyle = dataGridViewCellStyle3;
            this.timeEnd.HeaderText = "Время сдачи";
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // typeName
            // 
            this.typeName.DataPropertyName = "typeName";
            this.typeName.HeaderText = "Тип";
            this.typeName.Name = "typeName";
            this.typeName.ReadOnly = true;
            this.typeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmEditTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(676, 335);
            this.ControlBox = false;
            this.Controls.Add(this.rbX14);
            this.Controls.Add(this.rbK21);
            this.Controls.Add(this.lShop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.btAddKadr);
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
            this.Text = "Добавление\\Редактирование данных по выдаче сканеров\\ведомостей";
            this.Load += new System.EventHandler(this.frmEditTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridView dgvEditTime;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btAddKadr;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbK21;
        private System.Windows.Forms.RadioButton rbX14;
        private System.Windows.Forms.Label lShop;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberScaner;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private datetimeCellCalendare.CalendarColumn timeStart;
        private datetimeCellCalendare.CalendarColumn timeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeName;
    }
}