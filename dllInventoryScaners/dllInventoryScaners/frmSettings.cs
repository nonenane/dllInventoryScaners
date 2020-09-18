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
    public partial class frmSettings : Form
    {
        private DataTable dtCountHour;
        public frmSettings()
        {
            InitializeComponent();
            dgvCountHour.AutoGenerateColumns = false;
            get_data();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddSettings frm = new frmAddSettings();
            frm.isEdit = false;
            if (DialogResult.OK == frm.ShowDialog())
                get_data();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            frmAddSettings frm = new frmAddSettings();
            frm.isEdit = true;
            frm.row = dtCountHour.DefaultView[dgvCountHour.CurrentRow.Index];
            if (DialogResult.OK == frm.ShowDialog())
                get_data();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Удалить запись?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                int id = int.Parse(dtCountHour.DefaultView[dgvCountHour.CurrentRow.Index]["id"].ToString());

                Logging.StartFirstLevel(940);
                Logging.Comment("Начало удаления настройки");
                Logging.Comment("Минимальное кол-во часов = " + dtCountHour.DefaultView[dgvCountHour.CurrentRow.Index]["hourStart"].ToString());
                Logging.Comment("Максимальное кол-во часов = " + dtCountHour.DefaultView[dgvCountHour.CurrentRow.Index]["hourEnd"].ToString());
                Logging.Comment("Количество отгулов = " + dtCountHour.DefaultView[dgvCountHour.CurrentRow.Index]["day"].ToString());

                readSQL.delTableCountHourForScaner(id);

                Logging.Comment("Конец удаления настройки");
                Logging.StopFirstLevel();

                get_data();
            }
        }
    
        private void get_data()
        {
            dtCountHour = readSQL.getTableCountHourForScaner();
            btDel.Enabled = btEdit.Enabled = dtCountHour.DefaultView.Count != 0;
            dgvCountHour.DataSource = dtCountHour;

        }
    }
}
