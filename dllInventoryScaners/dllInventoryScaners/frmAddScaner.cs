using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nwuram.Framework.Logging;

namespace dllInventoryScaners
{
    public partial class frmAddScaner : Form
    {
        public int id_shop { set; private get; }
        public string nameShop { set; private get; }

        private int type { set; get; }

        private int id_kadr { set; get; }

        public int id_invent { set; get; }
        public string date_invent { get; set; }


        private string numberScaner { set; get; }
        private bool vozvrat = false;

        private Nwuram.Framework.UI.Forms.frmLoad frm;
        private bool isAltF4 = false;
        public frmAddScaner()
        {
            InitializeComponent();
            tbCodeBaje.ContextMenuStrip = new ContextMenuStrip();
        }

        private void btScaner_Click(object sender, EventArgs e)
        {

            Task<DataTable> task =  readSQL.getIdSpasingForForm(DateTime.Parse(date_invent), id_kadr, id_shop == 2);
            task.Wait();
            int? id_spacing = null;
            if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0][0]!=DBNull.Value)
                id_spacing = (int)task.Result.Rows[0][0];

            type = 1;
            numberScaner = "";
            DataTable dtResult = readSQL.setScanerOrBlankForKadrs(id_kadr, id_invent, tbTime.Text, type, numberScaner, true,id_shop, id_spacing);
            int result = int.Parse(dtResult.Rows[0]["result"].ToString());
            if (result == 0)
            {
                frmAddNumberScaner frm = new frmAddNumberScaner();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    vozvrat = false;
                    type = 1;
                    numberScaner = frm.numberScaner;
                    saveData();
                }
            }
            else
            {
                vozvrat = true;
                numberScaner = dtResult.Rows[0]["numberScaner"].ToString();
                type = 1;
                saveData();
            }

        }

        private void btBlank_Click(object sender, EventArgs e)
        {
            type = 2;
            numberScaner = "";

            Task<DataTable> task = readSQL.getIdSpasingForForm(DateTime.Parse(date_invent), id_kadr, id_shop == 2);
            task.Wait();
            int? id_spacing = null;
            if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0][0] != DBNull.Value)
                id_spacing = (int)task.Result.Rows[0][0];

            DataTable dtResult = readSQL.setScanerOrBlankForKadrs(id_kadr, id_invent, tbTime.Text, type, numberScaner, true, id_shop, id_spacing);
            int result = int.Parse(dtResult.Rows[0]["result"].ToString());
            vozvrat = result == 1;

            saveData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbCodeBaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void tbCodeBaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Int64 _code;
                if (!Int64.TryParse(tbCodeBaje.Text, out _code))
                {
                    tbFIO.Clear();
                    tbTime.Clear();
                    tbDate.Clear();
                    tbNumBeject.Clear();
                    tbCodeBaje.Clear();
                    tbCodeBaje.Focus();
                    btBlank.Enabled = btScaner.Enabled = false;
                    return;
                }
                DataTable dtResult = readSQL.getKadForScaner(Int64.Parse(tbCodeBaje.Text),null);
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    tbTime.Text = dtResult.Rows[0]["nowTime"].ToString();
                    tbDate.Text = dtResult.Rows[0]["nowDate"].ToString();
                    tbFIO.Text = dtResult.Rows[0]["FIO"].ToString();
                    id_kadr = int.Parse(dtResult.Rows[0]["id_kadr"].ToString());
                    btBlank.Enabled = btScaner.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Данный сотрудник не найден в базе!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbFIO.Clear();
                    tbTime.Clear();
                    tbDate.Clear();
                    tbNumBeject.Clear();
                    tbCodeBaje.Clear();
                    tbCodeBaje.Focus();
                    btBlank.Enabled = btScaner.Enabled = false;
                }
            }
        }

        private void frmAddScaner_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isAltF4;
            isAltF4 = false;
        }

        private void frmAddScaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F4)
            {
                isAltF4 = true;
            }
            else
                if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.S)
                {
                    if (btScaner.Enabled)
                        btScaner_Click(sender, e);
                }
                else
                    if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.W)
                    {
                        if (btBlank.Enabled)
                            btBlank_Click(sender, e);
                    }
        }

        private void saveData()
        {
            if (!bw.IsBusy)
            {
                Nwuram.Framework.UI.Service.EnableControlsService.SaveControlsEnabledState(this);
                Nwuram.Framework.UI.Service.EnableControlsService.SetControlsEnabled(this, false);
                frm = new Nwuram.Framework.UI.Forms.frmLoad();
                frm.TextWait = "Сохранение данных";
                frm.Show();
                bw.RunWorkerAsync();
            }
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Logging.StartFirstLevel(vozvrat ? (type == 1 ? 941 : 942) : (type == 1 ? 936 : 937));
            Logging.Comment("Начало сохранения" + (vozvrat ? " возврата " : " выдачи ") + (type == 1 ? "сканера" : "ведомости"));
            Logging.Comment("Id инвентаризации = " + id_invent.ToString() + ", Дата инвентаризации = " + date_invent);
            Logging.Comment("Id сотрудника = " + id_kadr.ToString() + ", ФИО = " + tbFIO.Text);
            Logging.Comment("Код бейджика = " + tbCodeBaje.Text);
            Logging.Comment("Время " + (vozvrat ? "возврата" : "выдачи") + " = " + tbTime.Text);
            Logging.Comment($"Магазин ID:{id_shop}; Наименование:{nameShop}");
            if (type == 1)
            {
                Logging.Comment("Номер сканера = " + numberScaner);
            }

            Task<DataTable> task = readSQL.getIdSpasingForForm(DateTime.Parse(date_invent), id_kadr,id_shop==2);
            task.Wait();
            int? id_spacing = null;
            if (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0][0] != DBNull.Value)
                id_spacing = (int)task.Result.Rows[0][0];

            readSQL.setScanerOrBlankForKadrs(id_kadr, id_invent, tbTime.Text, type, numberScaner, false, id_shop, id_spacing);

            Logging.Comment("Конец сохранения" + (vozvrat ? " возврата " : " выдачи ") + (type == 1 ? "сканера" : "ведомости"));
            Logging.StopFirstLevel();
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm.Dispose();
            Nwuram.Framework.UI.Service.EnableControlsService.SetControlsEnabled(this, true);
            tbFIO.Clear();
            tbTime.Clear();
            tbCodeBaje.Clear();
            tbCodeBaje.Focus();
            btBlank.Enabled = btScaner.Enabled = false;
        }

        private void tbCodeBaje_TextChanged(object sender, EventArgs e)
        {
            TextBox tbIn = (TextBox)sender;
            if (tbIn.Text.Length == 13)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void frmAddScaner_Load(object sender, EventArgs e)
        {
            this.Text += $" {nameShop}";
            lShopName.Text = nameShop;
        }

        private void tbNumBeject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Int64 _code;
                if (!Int64.TryParse(tbNumBeject.Text, out _code))
                {
                    tbFIO.Clear();
                    tbTime.Clear();
                    tbDate.Clear();
                    tbNumBeject.Clear();
                    tbCodeBaje.Clear();
                    tbNumBeject.Focus();
                    btBlank.Enabled = btScaner.Enabled = false;
                    return;
                }
                DataTable dtResult = readSQL.getKadForScaner(null, Int64.Parse(tbNumBeject.Text));
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    tbTime.Text = dtResult.Rows[0]["nowTime"].ToString();
                    tbDate.Text = dtResult.Rows[0]["nowDate"].ToString();
                    tbFIO.Text = dtResult.Rows[0]["FIO"].ToString();
                    id_kadr = int.Parse(dtResult.Rows[0]["id_kadr"].ToString());
                    btBlank.Enabled = btScaner.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Данный сотрудник не найден в базе!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbFIO.Clear();
                    tbTime.Clear();
                    tbDate.Clear();
                    tbNumBeject.Clear();
                    tbCodeBaje.Clear();
                    tbNumBeject.Focus();
                    btBlank.Enabled = btScaner.Enabled = false;
                }
            }
        }
    }
}
