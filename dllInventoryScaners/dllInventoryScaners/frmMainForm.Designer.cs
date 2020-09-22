namespace dllInventoryScaners
{
    partial class frmMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvScaners = new System.Windows.Forms.DataGridView();
            this.cPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDepsPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPlane_s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPlace_e = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNumberScaner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlane = new System.Windows.Forms.DataGridView();
            this.cFio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDeps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGraph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItogTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTakeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbInventDate = new System.Windows.Forms.ComboBox();
            this.tbFIo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbOffice = new System.Windows.Forms.RadioButton();
            this.rbShop = new System.Windows.Forms.RadioButton();
            this.tbDeps = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNamePlace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslServerDataBase = new System.Windows.Forms.ToolStripStatusLabel();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btDicExeption = new System.Windows.Forms.Button();
            this.btComTime = new System.Windows.Forms.Button();
            this.btGetDataTimeWorkInInvent = new System.Windows.Forms.Button();
            this.btSaveTimeToHoliday = new System.Windows.Forms.Button();
            this.btEditTime = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.btFindPlace = new System.Windows.Forms.Button();
            this.btHelp = new System.Windows.Forms.Button();
            this.btEditPlace = new System.Windows.Forms.Button();
            this.btReport = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btAddScaner = new System.Windows.Forms.Button();
            this.btAddTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlane)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvScaners
            // 
            this.dgvScaners.AllowUserToAddRows = false;
            this.dgvScaners.AllowUserToDeleteRows = false;
            this.dgvScaners.AllowUserToResizeRows = false;
            this.dgvScaners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScaners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScaners.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvScaners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScaners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPlace,
            this.cDepsPlace,
            this.cPlane_s,
            this.cPlace_e,
            this.cNumberScaner,
            this.cTimeStart,
            this.cTimeEnd,
            this.cType});
            this.dgvScaners.Location = new System.Drawing.Point(12, 300);
            this.dgvScaners.MultiSelect = false;
            this.dgvScaners.Name = "dgvScaners";
            this.dgvScaners.ReadOnly = true;
            this.dgvScaners.RowHeadersVisible = false;
            this.dgvScaners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScaners.Size = new System.Drawing.Size(1113, 200);
            this.dgvScaners.TabIndex = 1;
            // 
            // cPlace
            // 
            this.cPlace.DataPropertyName = "place";
            this.cPlace.HeaderText = "Место инвентаризации";
            this.cPlace.Name = "cPlace";
            this.cPlace.ReadOnly = true;
            // 
            // cDepsPlace
            // 
            this.cDepsPlace.DataPropertyName = "nameDep";
            this.cDepsPlace.HeaderText = "Отдел";
            this.cDepsPlace.Name = "cDepsPlace";
            this.cDepsPlace.ReadOnly = true;
            // 
            // cPlane_s
            // 
            this.cPlane_s.DataPropertyName = "dttost_n";
            this.cPlane_s.HeaderText = "План начало";
            this.cPlane_s.Name = "cPlane_s";
            this.cPlane_s.ReadOnly = true;
            // 
            // cPlace_e
            // 
            this.cPlace_e.DataPropertyName = "dttost_k";
            this.cPlace_e.HeaderText = "План окончание";
            this.cPlace_e.Name = "cPlace_e";
            this.cPlace_e.ReadOnly = true;
            // 
            // cNumberScaner
            // 
            this.cNumberScaner.DataPropertyName = "numberScaner";
            this.cNumberScaner.HeaderText = "Номер сканера";
            this.cNumberScaner.Name = "cNumberScaner";
            this.cNumberScaner.ReadOnly = true;
            // 
            // cTimeStart
            // 
            this.cTimeStart.DataPropertyName = "timeStart";
            dataGridViewCellStyle8.Format = "T";
            dataGridViewCellStyle8.NullValue = null;
            this.cTimeStart.DefaultCellStyle = dataGridViewCellStyle8;
            this.cTimeStart.HeaderText = "Время взятия";
            this.cTimeStart.Name = "cTimeStart";
            this.cTimeStart.ReadOnly = true;
            // 
            // cTimeEnd
            // 
            this.cTimeEnd.DataPropertyName = "timeEnd";
            dataGridViewCellStyle9.Format = "T";
            dataGridViewCellStyle9.NullValue = null;
            this.cTimeEnd.DefaultCellStyle = dataGridViewCellStyle9;
            this.cTimeEnd.HeaderText = "Время сдачи";
            this.cTimeEnd.Name = "cTimeEnd";
            this.cTimeEnd.ReadOnly = true;
            // 
            // cType
            // 
            this.cType.DataPropertyName = "typeName";
            this.cType.HeaderText = "Тип";
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            // 
            // dgvPlane
            // 
            this.dgvPlane.AllowUserToAddRows = false;
            this.dgvPlane.AllowUserToDeleteRows = false;
            this.dgvPlane.AllowUserToResizeRows = false;
            this.dgvPlane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlane.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlane.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPlane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFio,
            this.cDeps,
            this.cGraph,
            this.cItogTime,
            this.cTakeTime});
            this.dgvPlane.Location = new System.Drawing.Point(12, 62);
            this.dgvPlane.MultiSelect = false;
            this.dgvPlane.Name = "dgvPlane";
            this.dgvPlane.ReadOnly = true;
            this.dgvPlane.RowHeadersVisible = false;
            this.dgvPlane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlane.Size = new System.Drawing.Size(1113, 188);
            this.dgvPlane.TabIndex = 1;
            this.dgvPlane.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvPlane_ColumnWidthChanged);
            this.dgvPlane.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPlane_RowPostPaint);
            this.dgvPlane.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPlane_RowPrePaint);
            this.dgvPlane.SelectionChanged += new System.EventHandler(this.dgvPlane_SelectionChanged);
            // 
            // cFio
            // 
            this.cFio.DataPropertyName = "fio";
            this.cFio.HeaderText = "ФИО";
            this.cFio.Name = "cFio";
            this.cFio.ReadOnly = true;
            // 
            // cDeps
            // 
            this.cDeps.DataPropertyName = "nameDeps";
            this.cDeps.HeaderText = "Отдел";
            this.cDeps.Name = "cDeps";
            this.cDeps.ReadOnly = true;
            // 
            // cGraph
            // 
            this.cGraph.DataPropertyName = "graphWork";
            this.cGraph.HeaderText = "График работы";
            this.cGraph.Name = "cGraph";
            this.cGraph.ReadOnly = true;
            // 
            // cItogTime
            // 
            this.cItogTime.DataPropertyName = "TimeWorked_to_Time";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.NullValue = null;
            this.cItogTime.DefaultCellStyle = dataGridViewCellStyle11;
            this.cItogTime.HeaderText = "Итоговое время подсчета участка";
            this.cItogTime.Name = "cItogTime";
            this.cItogTime.ReadOnly = true;
            // 
            // cTakeTime
            // 
            this.cTakeTime.DataPropertyName = "CompensatoryTime";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.cTakeTime.DefaultCellStyle = dataGridViewCellStyle12;
            this.cTakeTime.HeaderText = "Заработанный отгул";
            this.cTakeTime.Name = "cTakeTime";
            this.cTakeTime.ReadOnly = true;
            // 
            // cbInventDate
            // 
            this.cbInventDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInventDate.FormattingEnabled = true;
            this.cbInventDate.Location = new System.Drawing.Point(140, 8);
            this.cbInventDate.Name = "cbInventDate";
            this.cbInventDate.Size = new System.Drawing.Size(88, 21);
            this.cbInventDate.TabIndex = 2;
            this.cbInventDate.SelectionChangeCommitted += new System.EventHandler(this.cbInventDate_SelectionChangeCommitted);
            // 
            // tbFIo
            // 
            this.tbFIo.Location = new System.Drawing.Point(12, 36);
            this.tbFIo.Name = "tbFIo";
            this.tbFIo.Size = new System.Drawing.Size(229, 20);
            this.tbFIo.TabIndex = 3;
            this.tbFIo.TextChanged += new System.EventHandler(this.tbFIo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Дата инвентаризации:";
            // 
            // rbOffice
            // 
            this.rbOffice.AutoSize = true;
            this.rbOffice.Checked = true;
            this.rbOffice.Location = new System.Drawing.Point(512, 10);
            this.rbOffice.Name = "rbOffice";
            this.rbOffice.Size = new System.Drawing.Size(53, 17);
            this.rbOffice.TabIndex = 5;
            this.rbOffice.TabStop = true;
            this.rbOffice.Text = "Офис";
            this.rbOffice.UseVisualStyleBackColor = true;
            this.rbOffice.CheckedChanged += new System.EventHandler(this.rbOffice_CheckedChanged);
            // 
            // rbShop
            // 
            this.rbShop.AutoSize = true;
            this.rbShop.Location = new System.Drawing.Point(571, 10);
            this.rbShop.Name = "rbShop";
            this.rbShop.Size = new System.Drawing.Size(83, 17);
            this.rbShop.TabIndex = 5;
            this.rbShop.Text = "Универсам";
            this.rbShop.UseVisualStyleBackColor = true;
            // 
            // tbDeps
            // 
            this.tbDeps.Location = new System.Drawing.Point(237, 36);
            this.tbDeps.Name = "tbDeps";
            this.tbDeps.Size = new System.Drawing.Size(229, 20);
            this.tbDeps.TabIndex = 3;
            this.tbDeps.TextChanged += new System.EventHandler(this.tbFIo_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(134, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выдан сканер/ведомость";
            // 
            // cmbShop
            // 
            this.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShop.FormattingEnabled = true;
            this.cmbShop.Location = new System.Drawing.Point(305, 8);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(195, 21);
            this.cmbShop.TabIndex = 9;
            this.cmbShop.SelectionChangeCommitted += new System.EventHandler(this.cmbShop_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Магазин";
            // 
            // tbNamePlace
            // 
            this.tbNamePlace.Location = new System.Drawing.Point(756, 8);
            this.tbNamePlace.MaxLength = 150;
            this.tbNamePlace.Name = "tbNamePlace";
            this.tbNamePlace.Size = new System.Drawing.Size(194, 20);
            this.tbNamePlace.TabIndex = 10;
            this.tbNamePlace.TextChanged += new System.EventHandler(this.tbNamePlace_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(663, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Поиск по месту";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Исключения";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(324, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslServerDataBase});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1137, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslServerDataBase
            // 
            this.tsslServerDataBase.Name = "tsslServerDataBase";
            this.tsslServerDataBase.Size = new System.Drawing.Size(13, 17);
            this.tsslServerDataBase.Text = "_";
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate.BackgroundImage = global::dllInventoryScaners.Properties.Resources.reload_8055;
            this.btUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btUpdate.Location = new System.Drawing.Point(1047, 2);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 17;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btDicExeption
            // 
            this.btDicExeption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDicExeption.BackgroundImage = global::dllInventoryScaners.Properties.Resources.security;
            this.btDicExeption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDicExeption.Location = new System.Drawing.Point(89, 506);
            this.btDicExeption.Name = "btDicExeption";
            this.btDicExeption.Size = new System.Drawing.Size(32, 32);
            this.btDicExeption.TabIndex = 16;
            this.btDicExeption.UseVisualStyleBackColor = true;
            this.btDicExeption.Click += new System.EventHandler(this.btDicExeption_Click);
            // 
            // btComTime
            // 
            this.btComTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btComTime.BackgroundImage = global::dllInventoryScaners.Properties.Resources.keyboard;
            this.btComTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btComTime.Location = new System.Drawing.Point(127, 506);
            this.btComTime.Name = "btComTime";
            this.btComTime.Size = new System.Drawing.Size(32, 32);
            this.btComTime.TabIndex = 16;
            this.btComTime.UseVisualStyleBackColor = true;
            this.btComTime.Click += new System.EventHandler(this.btComTime_Click);
            // 
            // btGetDataTimeWorkInInvent
            // 
            this.btGetDataTimeWorkInInvent.BackgroundImage = global::dllInventoryScaners.Properties.Resources.calculator;
            this.btGetDataTimeWorkInInvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btGetDataTimeWorkInInvent.Location = new System.Drawing.Point(783, 258);
            this.btGetDataTimeWorkInInvent.Name = "btGetDataTimeWorkInInvent";
            this.btGetDataTimeWorkInInvent.Size = new System.Drawing.Size(32, 32);
            this.btGetDataTimeWorkInInvent.TabIndex = 16;
            this.btGetDataTimeWorkInInvent.UseVisualStyleBackColor = true;
            this.btGetDataTimeWorkInInvent.Click += new System.EventHandler(this.btGetDataTimeWorkInInvent_Click);
            // 
            // btSaveTimeToHoliday
            // 
            this.btSaveTimeToHoliday.BackgroundImage = global::dllInventoryScaners.Properties.Resources.filesave_2175;
            this.btSaveTimeToHoliday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSaveTimeToHoliday.Location = new System.Drawing.Point(821, 258);
            this.btSaveTimeToHoliday.Name = "btSaveTimeToHoliday";
            this.btSaveTimeToHoliday.Size = new System.Drawing.Size(32, 32);
            this.btSaveTimeToHoliday.TabIndex = 16;
            this.btSaveTimeToHoliday.UseVisualStyleBackColor = true;
            this.btSaveTimeToHoliday.Click += new System.EventHandler(this.btSaveTimeToHoliday_Click);
            // 
            // btEditTime
            // 
            this.btEditTime.BackgroundImage = global::dllInventoryScaners.Properties.Resources.x_office_spreadsheet;
            this.btEditTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btEditTime.Location = new System.Drawing.Point(1047, 258);
            this.btEditTime.Name = "btEditTime";
            this.btEditTime.Size = new System.Drawing.Size(32, 32);
            this.btEditTime.TabIndex = 16;
            this.btEditTime.UseVisualStyleBackColor = true;
            this.btEditTime.Click += new System.EventHandler(this.btEditTime_Click);
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDel.BackgroundImage = global::dllInventoryScaners.Properties.Resources.editdelete_3805;
            this.btDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDel.Location = new System.Drawing.Point(165, 506);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(32, 32);
            this.btDel.TabIndex = 14;
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btFindPlace
            // 
            this.btFindPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFindPlace.BackgroundImage = global::dllInventoryScaners.Properties.Resources.find;
            this.btFindPlace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btFindPlace.Location = new System.Drawing.Point(956, 1);
            this.btFindPlace.Name = "btFindPlace";
            this.btFindPlace.Size = new System.Drawing.Size(32, 32);
            this.btFindPlace.TabIndex = 11;
            this.btFindPlace.UseVisualStyleBackColor = true;
            this.btFindPlace.Click += new System.EventHandler(this.btFindPlace_Click);
            // 
            // btHelp
            // 
            this.btHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHelp.BackgroundImage = global::dllInventoryScaners.Properties.Resources.info1;
            this.btHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btHelp.Location = new System.Drawing.Point(1093, 2);
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(32, 32);
            this.btHelp.TabIndex = 11;
            this.btHelp.UseVisualStyleBackColor = true;
            // 
            // btEditPlace
            // 
            this.btEditPlace.Image = global::dllInventoryScaners.Properties.Resources.edit_1761;
            this.btEditPlace.Location = new System.Drawing.Point(16, 258);
            this.btEditPlace.Name = "btEditPlace";
            this.btEditPlace.Size = new System.Drawing.Size(32, 32);
            this.btEditPlace.TabIndex = 0;
            this.btEditPlace.UseVisualStyleBackColor = true;
            this.btEditPlace.Click += new System.EventHandler(this.btEditPlace_Click);
            // 
            // btReport
            // 
            this.btReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btReport.Image = global::dllInventoryScaners.Properties.Resources.klpq_2511;
            this.btReport.Location = new System.Drawing.Point(51, 506);
            this.btReport.Name = "btReport";
            this.btReport.Size = new System.Drawing.Size(32, 32);
            this.btReport.TabIndex = 0;
            this.btReport.UseVisualStyleBackColor = true;
            this.btReport.Click += new System.EventHandler(this.btReport_Click);
            // 
            // btSettings
            // 
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSettings.Image = global::dllInventoryScaners.Properties.Resources.Set1;
            this.btSettings.Location = new System.Drawing.Point(13, 506);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(32, 32);
            this.btSettings.TabIndex = 0;
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::dllInventoryScaners.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(1093, 506);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 0;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAddScaner
            // 
            this.btAddScaner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddScaner.Image = global::dllInventoryScaners.Properties.Resources.view2;
            this.btAddScaner.Location = new System.Drawing.Point(1085, 258);
            this.btAddScaner.Name = "btAddScaner";
            this.btAddScaner.Size = new System.Drawing.Size(32, 32);
            this.btAddScaner.TabIndex = 0;
            this.btAddScaner.UseVisualStyleBackColor = true;
            this.btAddScaner.Click += new System.EventHandler(this.btAddScaner_Click);
            // 
            // btAddTime
            // 
            this.btAddTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAddTime.Image = global::dllInventoryScaners.Properties.Resources.view2;
            this.btAddTime.Location = new System.Drawing.Point(1009, 258);
            this.btAddTime.Name = "btAddTime";
            this.btAddTime.Size = new System.Drawing.Size(32, 32);
            this.btAddTime.TabIndex = 18;
            this.btAddTime.UseVisualStyleBackColor = true;
            this.btAddTime.Click += new System.EventHandler(this.btAddTime_Click);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 563);
            this.ControlBox = false;
            this.Controls.Add(this.btAddTime);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btDicExeption);
            this.Controls.Add(this.btComTime);
            this.Controls.Add(this.btGetDataTimeWorkInInvent);
            this.Controls.Add(this.btSaveTimeToHoliday);
            this.Controls.Add(this.btEditTime);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btFindPlace);
            this.Controls.Add(this.btHelp);
            this.Controls.Add(this.tbNamePlace);
            this.Controls.Add(this.cmbShop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbShop);
            this.Controls.Add(this.rbOffice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDeps);
            this.Controls.Add(this.tbFIo);
            this.Controls.Add(this.cbInventDate);
            this.Controls.Add(this.dgvPlane);
            this.Controls.Add(this.dgvScaners);
            this.Controls.Add(this.btEditPlace);
            this.Controls.Add(this.btReport);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAddScaner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация по инвентаризации";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlane)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddScaner;
        private System.Windows.Forms.DataGridView dgvScaners;
        private System.Windows.Forms.DataGridView dgvPlane;
        private System.Windows.Forms.ComboBox cbInventDate;
        private System.Windows.Forms.TextBox tbFIo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbOffice;
        private System.Windows.Forms.RadioButton rbShop;
        private System.Windows.Forms.Button btEditPlace;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.Button btReport;
        private System.Windows.Forms.TextBox tbDeps;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbShop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNamePlace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btHelp;
        private System.Windows.Forms.Button btFindPlace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerDataBase;
        private System.Windows.Forms.Button btEditTime;
        private System.Windows.Forms.Button btSaveTimeToHoliday;
        private System.Windows.Forms.Button btGetDataTimeWorkInInvent;
        private System.Windows.Forms.Button btDicExeption;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDepsPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPlane_s;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPlace_e;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNumberScaner;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.Button btComTime;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDeps;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGraph;
        private System.Windows.Forms.DataGridViewTextBoxColumn cItogTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTakeTime;
        private System.Windows.Forms.Button btAddTime;
    }
}

