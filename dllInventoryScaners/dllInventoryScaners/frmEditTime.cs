using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nwuram.Framework.Logging;
using Nwuram.Framework;
using Nwuram.Framework.Settings.Connection;

namespace dllInventoryScaners
{
    public partial class frmEditTime : Form
    {
        public frmEditTime(DataTable dtSingleTable, int id_kadr, int id_ttost)
        {
            InitializeComponent();
            dgvEditTime.AutoGenerateColumns = false;
            copeDtSingleTable = dtSingleTable.Copy();
            oldDtSingletable = dtSingleTable.Copy();
            _id_kadr = id_kadr;
            _id_ttost = id_ttost;
            dgvEditTime.DataSource = copeDtSingleTable.DefaultView;
            
        }

        private int _id_kadr;
        private int _id_ttost;

        private DataTable oldDtSingletable;
        private DataTable copeDtSingleTable;


        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private int idCreater = Nwuram.Framework.Settings.User.UserSettings.User.Id;
        private void btSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            foreach (DataGridViewRow row in dgvEditTime.Rows)
            {
                if (row.Cells["id"].Value.ToString().Length == 0) //неподходит
                {
                    if (row.Cells["numberScaner"].Value.ToString().Length > 0)
                        type = 1;
                    else
                        type = 2;

                    DataTable rezylt = readSQL.AddNewTime(_id_kadr, _id_ttost, row.Cells["timeStart"].Value.ToString(), row.Cells["timeEnd"].Value.ToString(), type, row.Cells["numberScaner"].Value.ToString(), idCreater);
                    if (rezylt == null)
                    {
                        MessageBox.Show("Неправильно заведено время!");
                        return;
                    }
                    //   DataTable AddNewTime(int id_kadr, int id_ttost, DateTime timeS, DateTime timeEnd, int type, string scan, int idCreater
                }
                else
                {
                    DataTable rezylt = readSQL.EditSingleTableForScaner((Int32)row.Cells["id"].Value, row.Cells["timeStart"].Value.ToString(), row.Cells["timeEnd"].Value.ToString());
                    if (rezylt == null)
                    {
                        MessageBox.Show("Неправильно заведено время!");
                        return;
                    }
                }
            }
            MessageBox.Show("Данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            //}
            //catch (Exception ex) { MessageBox.Show("Неправильно введено время!"); }
        }

        private void dgvEditTime_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress -= new KeyPressEventHandler(tb_KeyPress);
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            // tb.TextChanged += new EventHandler(tb_TextChanged);
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if ((tb.Text.Length == 2 || tb.Text.Length == 5))
            {
                tb.Text += ":";
                tb.SelectionStart = tb.Text.Length;
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            }
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= (char)48 && e.KeyChar <= (char)57) || (e.KeyChar == (char)8) || (e.KeyChar == (char)45) || (e.KeyChar == (char)44))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar != (char)8) && ((sender as TextBox).Text.ToString().Length == 2 || (sender as TextBox).Text.ToString().Length == 5))
            {
                TextBox tb = sender as TextBox;

                if ((tb.Text.Length == 2 || tb.Text.Length == 5))
                {
                    tb.Text += ":";
                    tb.SelectionStart = tb.Text.Length;
                    tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                }
            }

            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }


        private void btAdd_Click(object sender, EventArgs e)
        {

            DataRow row = copeDtSingleTable.NewRow();
            copeDtSingleTable.Rows.Add(row);

            dgvEditTime.DataSource = copeDtSingleTable.DefaultView;
        }

        private int type = 1;
        private void dgvEditTime_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEditTime.CurrentRow.Cells["numberScaner"].Value.ToString().Length > 0)
                dgvEditTime.CurrentRow.Cells["typeName"].Value = "Сканер";
            else
                dgvEditTime.CurrentRow.Cells["typeName"].Value = "Ведомость";
        }

        private void dgvEditTime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvEditTime.CurrentRow.Cells[0].Value.ToString().Length > 0)
                dgvEditTime.CurrentRow.ReadOnly = true;
            else
                dgvEditTime.CurrentRow.ReadOnly = false;
        }
    }
}
