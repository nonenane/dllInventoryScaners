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
using System.Threading.Tasks;

namespace dllInventoryScaners
{
    public partial class frmEditTime : Form
    {
        public string nameShop { set; private get; }
        public string fio { set; private get; }
        public DateTime dateInvent { set; private get; }
        public int id_Shop { set; private get; }

        private DateTime maxDate, minDate;
        public frmEditTime(DataTable dtSingleTable, int id_kadr, int id_ttost)
        {
            InitializeComponent();
            dgvEditTime.AutoGenerateColumns = false;
            copeDtSingleTable = dtSingleTable.Copy();
            oldDtSingletable = dtSingleTable.Copy();
            _id_kadr = id_kadr;
            _id_ttost = id_ttost;
            btAddKadr.Visible = id_kadr == -1;
            rbX14.Enabled = rbK21.Enabled = id_kadr == -1;
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
            if (_id_kadr == -1)
            {
                MessageBox.Show("Необходимо выбрать сотрудника","Сохранение данных",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btAddKadr.Focus();
                    return;
            }
            if (!rbX14.Checked && !rbK21.Checked)
            {
                MessageBox.Show($"Необходимо выбрать \"{lShop.Text}\"", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //cmbShop.Focus();
                return;
            }

            foreach (DataGridViewRow row in dgvEditTime.Rows)
            {
                DateTime _tmpDateStart, _tmpDateEnd;
                if (!DateTime.TryParse(row.Cells["timeStart"].Value.ToString(), out _tmpDateStart))
                {
                    MessageBox.Show("Не корректное значение времени","Сохранение",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (!DateTime.TryParse(row.Cells["timeEnd"].Value.ToString(), out _tmpDateEnd))
                {
                    MessageBox.Show("Не корректное значение времени", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ((_tmpDateStart < minDate || _tmpDateStart > maxDate) || (_tmpDateEnd < minDate || _tmpDateEnd > maxDate))
                {
                    MessageBox.Show($"Диапазон времени должен быть с {minDate.ToString()} по {maxDate.ToString()}", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_tmpDateStart > _tmpDateEnd)
                {
                    MessageBox.Show("Начальное значение должно быть меньше конечного", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }


            //try
            //{
            foreach (DataGridViewRow row in dgvEditTime.Rows)
            {

                Task<DataTable> task = readSQL.getIdSpasingForForm(dateInvent, _id_kadr, rbX14.Checked);
                task.Wait();
                int? id_spacing = null;
                if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0][0] != DBNull.Value)
                    id_spacing = (int)task.Result.Rows[0][0];

                DateTime _dateStart = DateTime.Parse(row.Cells["timeStart"].Value.ToString());
                DateTime _dateEnd= DateTime.Parse(row.Cells["timeEnd"].Value.ToString());


                if (row.Cells["id"].Value.ToString().Length == 0) //неподходит
                {
                    if (row.Cells["numberScaner"].Value.ToString().Length > 0)
                        type = 1;
                    else
                        type = 2;

                    DataTable rezylt = readSQL.AddNewTime(_id_kadr, _id_ttost, (DateTime)row.Cells["timeStart"].Value, (DateTime)row.Cells["timeEnd"].Value, type, row.Cells["numberScaner"].Value.ToString(), idCreater, id_spacing);
                    if (rezylt == null)
                    {
                        MessageBox.Show("Неправильно заведено время!");
                        return;
                    }
                    //   DataTable AddNewTime(int id_kadr, int id_ttost, DateTime timeS, DateTime timeEnd, int type, string scan, int idCreater
                }
                else
                {
                    DataTable rezylt = readSQL.EditSingleTableForScaner((Int32)row.Cells["id"].Value, (DateTime)row.Cells["timeStart"].Value
                        , (DateTime)row.Cells["timeEnd"].Value, id_spacing);
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
            if (dgvEditTime.CurrentCell.ColumnIndex == numberScaner.Index)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress -= new KeyPressEventHandler(tb_KeyPress);
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            }
            //// tb.TextChanged += new EventHandler(tb_TextChanged);
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
            row["timeStart"] = minDate;
            row["timeEnd"] = minDate;
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

        private void btAddKadr_Click(object sender, EventArgs e)
        {
            CompensatoryTime.users.frmSelect frmSelect = new CompensatoryTime.users.frmSelect() { dateInvent = dateInvent };
            if (DialogResult.OK == frmSelect.ShowDialog())
            {
                tbFIO.Text = frmSelect.nameUser;
                _id_kadr = frmSelect.id_kadr;
                //isEditData = true;
            }
        }

        private void frmEditTime_Load(object sender, EventArgs e)
        {
            tbFIO.Text = fio;
            if (id_Shop != 0)
                rbX14.Checked = !(rbK21.Checked = id_Shop == 1);

            minDate = dateInvent.Date.AddHours(8);
            maxDate = dateInvent.Date.AddDays(1).AddHours(9);                  
        }
    }
}
