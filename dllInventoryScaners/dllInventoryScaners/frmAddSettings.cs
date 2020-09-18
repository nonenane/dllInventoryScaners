using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nwuram.Framework.Logging;

namespace dllInventoryScaners
{
    public partial class frmAddSettings : Form
    {
        private int id;
        public DataRowView row { set; get; }
        
        public bool isEdit { set; get; }
        
        public frmAddSettings()
        {
            InitializeComponent();
        }

        private void tbCountDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.ToString().Contains(e.KeyChar) || (sender as TextBox).Text.ToString().Length == 0))
            {
                e.Handled = true;
            }
            else

                if ((!Char.IsNumber(e.KeyChar) && (e.KeyChar != ',')))
                {
                    if (e.KeyChar != '\b')
                    { e.Handled = true; }
                }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                dtpEnd.Value = dtpStart.Value;
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                dtpStart.Value = dtpEnd.Value;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            DataTable dtResult = readSQL.setTableCountHourForScaner(id, dtpStart.Value, dtpEnd.Value, decimal.Parse(tbCountDay.Text));
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                if (dtResult.Rows[0]["id"].ToString().Equals("-1"))
                {
                    MessageBox.Show("Добавление такого диапазона невозможно!","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }

            LogSave();
            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void LogSave()
        {
            Logging.StartFirstLevel(isEdit ? 939 : 938);
            Logging.Comment("Начало " + (isEdit ? "редактирования" : "сохранения") + " настроек");
            if (isEdit)
            {
                Logging.VariableChange("Минимальное кол-во часов", dtpStart.Value.ToShortTimeString(), DateTime.Parse(row["hourStart"].ToString()).ToShortTimeString());
                Logging.VariableChange("Максимальное кол-во часов", dtpEnd.Value.ToShortTimeString(), DateTime.Parse(row["hourEnd"].ToString()).ToShortTimeString());
                Logging.VariableChange("Количество отгулов", tbCountDay.Text, row["day"].ToString());
            }
            else
            {
                Logging.Comment("Минимальное кол-во часов = " + dtpStart.Value.ToShortTimeString());
                Logging.Comment("Максимальное кол-во часов = " + dtpEnd.Value.ToShortTimeString());
                Logging.Comment("Количество отгулов = " + tbCountDay.Text);
            }
            Logging.Comment("Конец " + (isEdit ? "редактирования" : "сохранения") + " настроек");
            Logging.StopFirstLevel();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmAddSettings_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                this.Text = "Редактировать запись";
                dtpStart.Value = DateTime.Parse(row["hourStart"].ToString());
                dtpEnd.Value = DateTime.Parse(row["hourEnd"].ToString());
                tbCountDay.Text = row["day"].ToString();
                id = int.Parse(row["id"].ToString());
            }
            else
            {
                this.Text = "Добавить запись";
                id = -1;
            }

        }
    }
}
