using Nwuram.Framework.Settings.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dllInventoryScaners
{
    public partial class frmMainForm : Form
    {
        private DataTable dtMainTable;
        private int countDayForEdit = 0;
        private ToolTip tp = new ToolTip();
        public frmMainForm()
        {
            InitializeComponent();

            tsslServerDataBase.Text = $"Сервер: {Nwuram.Framework.Settings.Connection.ConnectionSettings.GetServer()}; База данных: {Nwuram.Framework.Settings.Connection.ConnectionSettings.GetDatabase()};";
            //this.Text += $"  {Nwuram.Framework.Settings.User.UserSettings.User.Status}  {Nwuram.Framework.Settings.User.UserSettings.User.FullUsername}";
            this.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName + "; " + Nwuram.Framework.Settings.User.UserSettings.User.Status + "; " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername;


            dgvPlane.AutoGenerateColumns = false;
            dgvScaners.AutoGenerateColumns = false;
            settingsViewButton();
            inti_combobobox();


            tp.ShowAlways = true;
            tp.SetToolTip(btHelp,"Помощь");
            tp.SetToolTip(btFindPlace, "Поиск");
            tp.SetToolTip(btSaveTimeToHoliday, "Сохранить");
            tp.SetToolTip(btGetDataTimeWorkInInvent, "Расчет отгулов");
            tp.SetToolTip(btDicExeption, "Справочник исключений");
            tp.SetToolTip(btReport, "Печать");
            tp.SetToolTip(btSettings, "Настройки отгулов");
            //tp.SetToolTip(btHelp, "Редактирование ведомости");
            tp.SetToolTip(btAddScaner, "Выдача сканера/ведомости");
            tp.SetToolTip(btClose, "Выход");
            tp.SetToolTip(btDel, "Удалить связь");
            tp.SetToolTip(btEditPlace, "Редактировать место");
            tp.SetToolTip(btComTime, "Ввод первичных данных об отгулах");
        }

        private void btAddScaner_Click(object sender, EventArgs e)
        {
            int id_ttost = int.Parse(cbInventDate.SelectedValue.ToString());
            frmAddScaner frm = new frmAddScaner() { id_shop = (int)cmbShop.SelectedValue, nameShop = cmbShop.Text };
            frm.id_invent = id_ttost;
            frm.date_invent = cbInventDate.Text;
            frm.ShowDialog();
        }

        private void get_data(string namePlace = "")
        {
            int id_ttost = int.Parse(cbInventDate.SelectedValue.ToString());
            int id_PersonnelType = 1;
            if (rbShop.Checked) id_PersonnelType = 2;
            string value = getSettings("dkor");
            countDayForEdit =  int.Parse(value);


            btSaveTimeToHoliday.Visible = btGetDataTimeWorkInInvent.Visible =  DateTime.Parse(cbInventDate.Text).AddDays(countDayForEdit).Date >= DateTime.Now.Date && UserSettings.User.StatusCode.ToLower().Equals("кнт");



            dtMainTable = readSQL.getMainTableForScaner(id_ttost, id_PersonnelType, namePlace);

            filter();
            dgvPlane.DataSource = dtMainTable;

            Task<DataTable> task = readSQL.getInfoCalcCompensatoryTime((int)cbInventDate.SelectedValue);
            task.Wait();

            DialogResult dlgResult = DialogResult.Cancel;

            if (task.Result != null && task.Result.Rows.Count > 0 && (int)task.Result.Rows[0]["id"] == 1)
            {
                btReport.Enabled = true;
            }
            else btReport.Enabled = false;
        }

        private string getSettings(string id_value)
        {
            Task<DataTable> task = readSQL.getSettings(id_value);
            task.Wait();
            if (task != null && task.Result.Rows.Count > 0)
                return task.Result.Rows[0]["value"].ToString();
            return "0";
        }

        private void getSingleData()
        { 
            if(dgvPlane.CurrentRow!=null && dgvPlane.CurrentRow.Index!=-1)
            {
                int selected_row = dtMainTable.DefaultView.Count - 1 < dgvPlane.CurrentRow.Index ? dtMainTable.DefaultView.Count - 1 : dgvPlane.CurrentRow.Index;
                if (selected_row < 0)
                    return;
                if (dtMainTable.DefaultView[selected_row]["id_kadr"] != DBNull.Value)
                {
                    int id_kadr = int.Parse(dtMainTable.DefaultView[selected_row]["id_kadr"].ToString());
                    int id_ttost = int.Parse(cbInventDate.SelectedValue.ToString());
                    int id_Shop = (int)dtMainTable.DefaultView[selected_row]["id_Shop"];
                    DataTable dtSingleTable = readSQL.getSingleTableForScaner(id_kadr, id_ttost);
                    //
                    if (id_Shop == 0 || id_Shop == 2)
                    {
                        if (dtSingleTable != null)
                        {
                            EnumerableRowCollection<DataRow> rowCollect = dtSingleTable.AsEnumerable()
                                .Where(r => r.Field<int>("id_Shop") == 2 && r.Field<object>("id_spacing") != null);

                            if (rowCollect.Count() > 0)
                            {
                                Task<DataTable> task = readSQL.getInfoSpasingAndPlace(DateTime.Parse(cbInventDate.Text), id_kadr, true);
                                task.Wait();

                                foreach (DataRow r in rowCollect)
                                {
                                    r["dttost_n"] = DBNull.Value;
                                    r["dttost_k"] = DBNull.Value;
                                    r["place"] = DBNull.Value;
                                    r["nameDep"] = DBNull.Value;
                                    if (task.Result != null && task.Result.Rows.Count > 0)
                                    {
                                        EnumerableRowCollection<DataRow> rowFind = task.Result.AsEnumerable()
                                            .Where(rr => rr.Field<int>("id") == (int)r["id_spacing"]);
                                        if (rowFind.Count() > 0)
                                        {
                                            r["dttost_n"] = rowFind.First()["dttost_n"];
                                            r["dttost_k"] = rowFind.First()["dttost_k"];
                                            r["place"] = rowFind.First()["place"];
                                            r["nameDep"] = rowFind.First()["nameDep"];
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //
                    dgvScaners.DataSource = dtSingleTable;
                }
                else
                {
                    dgvScaners.DataSource = null;
                }
            }
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            btEditPlace.Visible = (Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower() == "кио" ||
                Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower() == "адм");

            btAddScaner.Visible = Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower() == "оои";
            get_data();
        }

        private void dgvPlane_SelectionChanged(object sender, EventArgs e)
        {
            getSingleData();
        }

        private void tbFIo_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void filter()
        {
            try {
                string filter = "";
                filter += tbFIo.Text.Length == 0 ? "" : string.Format("fio like '%{0}%' ", tbFIo.Text);

                filter += tbDeps.Text.Length == 0 ? "" : (filter.Length == 0 ? "" : " and ") + string.Format("nameDeps like '%{0}%' ", tbDeps.Text);
                //filter += tbDepsInv.Text.Length == 0 ? "" : (filter.Length == 0 ? "" : " and ") + string.Format("InvDeps like '%{0}%' ", tbDepsInv.Text);
                //filter += tbPlace.Text.Length == 0 ? "" : (filter.Length == 0 ? "" : " and ") + string.Format("place like '%{0}%' ", tbPlace.Text);
                filter+=(int)cmbShop.SelectedValue==0?"" : (filter.Length == 0 ? "" : " and ") + $"(id_Shop = {cmbShop.SelectedValue} or id_Shop = 0)";

                dtMainTable.DefaultView.RowFilter = filter;
                if (dtMainTable.DefaultView.Count == 0)
                    dgvScaners.DataSource = null;
            }
            catch {
                dtMainTable.DefaultView.RowFilter = "FIO = '-99999999999999'";
                dgvScaners.DataSource = null;
            }
        }

        private void btEditPlace_Click(object sender, EventArgs e)
        {
            //if (dgvPlane.CurrentRow != null && dgvPlane.CurrentRow.Index != -1)
            //{
            //    //if (int.Parse(dtMainTable.DefaultView[dgvPlane.CurrentRow.Index]["id"].ToString()) != -1)
            //    //{
            //        frmEditPlace frm = new frmEditPlace();
            //        frm.row = dtMainTable.DefaultView[dgvPlane.CurrentRow.Index];
            //        if (DialogResult.OK == frm.ShowDialog())
            //            get_data();
            //    //}
            //}
        }

        private void inti_combobobox()
        {
            DataTable dtInventDate = readSQL.getDttostForScaner();
            cbInventDate.DataSource = dtInventDate;
            cbInventDate.DisplayMember = "dttost";
            cbInventDate.ValueMember = "id";

            Task<DataTable> task = readSQL.getShop(!Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower().Equals("оои"));
            task.Wait();
            if (task.Result != null)
            {
                cmbShop.DataSource = task.Result.Copy();
                cmbShop.DisplayMember = "cName";
                cmbShop.ValueMember = "id";
            }

        }

        private void cbInventDate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            get_data();
        }

        private void rbOffice_CheckedChanged(object sender, EventArgs e)
        {
            //btEditPlace.Visible = rbOffice.Checked;
            btEditPlace.Visible = rbOffice.Checked && (Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower() == "кио" ||
            Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower() == "адм");
            get_data();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPlane_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Color rColor = Color.White;//dgvPlane.Rows[e.RowIndex].DefaultCellStyle.BackColor;
            if (int.Parse(dtMainTable.DefaultView[e.RowIndex]["color"].ToString()) != 0)
                rColor = panel1.BackColor;//Color.BurlyWood;
            dgvPlane.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                dgvPlane.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
            dgvPlane.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

            if (dtMainTable.DefaultView[e.RowIndex]["id_exception"] != DBNull.Value)
                dgvPlane.Rows[e.RowIndex].Cells[cFio.Index].Style.SelectionBackColor = dgvPlane.Rows[e.RowIndex].Cells[cFio.Index].Style.BackColor = panel2.BackColor;
        }

        private void dgvPlane_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport(int.Parse(cbInventDate.SelectedValue.ToString())); 
            frm.ShowDialog();
        }

        private void dgvPlane_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbFIo.Location = new Point(dgvPlane.Location.X+1, tbFIo.Location.Y);
            tbFIo.Size = new Size(cFio.Width, tbFIo.Height);

            tbDeps.Location = new Point(dgvPlane.Location.X+cFio.Width+1, tbDeps.Location.Y);
            tbDeps.Size = new Size(cDeps.Width, tbDeps.Height);
        }

        private void btComTime_Click(object sender, EventArgs e)
        {
            new compensatoryTime.frmMain().ShowDialog();
        }

        private void settingsViewButton()
        {
            Task<DataTable> task = readSQL.getSettings("vpdo");
            task.Wait();

            btComTime.Visible = (task.Result != null && task.Result.Rows.Count > 0 && task.Result.Rows[0]["value"].ToString().Equals("1") && Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower().Equals("кнт"));


            btSettings.Visible = btReport.Visible  = //btDicExeption.Visible = 
                btEditTime.Visible = Nwuram.Framework.Settings.User.UserSettings.User.StatusCode.ToLower().Equals("кнт");
        }

        private void cmbShop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void tbNamePlace_TextChanged(object sender, EventArgs e)
        {
            //btFindPlace.Enabled = !string.IsNullOrEmpty(tbNamePlace.Text);
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvScaners.CurrentRow == null) return;
            if (dgvScaners.CurrentRow.Index == -1) return;

            if (DialogResult.No == MessageBox.Show("Удалить выбранную запись?","Удалить запись",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)) return;

            int id = (int)(dgvScaners.DataSource as DataTable).DefaultView[dgvScaners.CurrentRow.Index]["id"];

            Task<DataTable> task = readSQL.setScanerBlank(id, 1, true);
            task.Wait();
            if (task.Result == null || task.Result.Rows.Count == 0 || (int)task.Result.Rows[0]["id"] < 0)
            {
                MessageBox.Show("Мастер Киноби, Произошла ошибка! Дроны напали на нас!", "Да прибудет с тобой сила!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            getSingleData();
        }

        private void btGetDataTimeWorkInInvent_Click(object sender, EventArgs e)
        {
            Task<DataTable> task = readSQL.getDataForCalculateTimeInvent(DateTime.Parse(cbInventDate.Text));
            task.Wait();

            if (task.Result == null) return;
            if (task.Result.Rows.Count == 0) return;

            DataTable dtMainTime = task.Result.Copy();

            task = readSQL.getInfoSpasingAndPlace(DateTime.Parse(cbInventDate.Text), 0, true);
            task.Wait();
            DataTable dtSecondTime = task.Result.Copy();

            task = readSQL.getTableHourForHoliday();
            task.Wait();

            DataTable dtMinuteToDay = task.Result.Copy();

            //Dictionary<int, int> dicUserVsMinutes = new Dictionary<int, int>();



            var groupIdKadr = dtMainTime.AsEnumerable().GroupBy(r => new { id_kadr = r.Field<int>("id_kadr") }).Select(s => new { s.Key.id_kadr });
            foreach (var gKadr in groupIdKadr)
            {
                int totalMinutes = 0;
                EnumerableRowCollection<DataRow> rowCollect = dtMainTime.AsEnumerable().Where(r => r.Field<int>("id_kadr") == gKadr.id_kadr);
                foreach (DataRow row in rowCollect)
                {
                    int id_Shop = (int)row["id_Shop"];

                    DateTime? scanerTake = (DateTime)row["scanerTake"];
                    DateTime? scanerDrop = (DateTime)row["scanerDrop"];
                    DateTime? endWorkTime = null;
                    if (row["endWorkTime"] != DBNull.Value) endWorkTime = (DateTime)row["endWorkTime"];
                    DateTime? dttost_n = null;
                    if (row["dttost_n"] != DBNull.Value) dttost_n = (DateTime)row["dttost_n"];


                    if (id_Shop == 2)
                    {
                        dttost_n = null;
                        if (dtSecondTime != null && row["id_spacing"] != DBNull.Value)
                        {
                            EnumerableRowCollection<DataRow> rowCollectSecond = dtSecondTime.AsEnumerable().Where(rr => rr.Field<int>("id") == (int)row["id_spacing"]);
                            if (rowCollectSecond.Count() > 0)
                            {
                                if (rowCollectSecond.First()["dttost_n"] != DBNull.Value) dttost_n = (DateTime)rowCollectSecond.First()["dttost_n"];
                            }
                        }
                    }

                    DateTime? dateStart = scanerTake;
                    if (endWorkTime != null && dateStart < endWorkTime) dateStart = endWorkTime;
                    if (dttost_n != null && dateStart < dttost_n) dateStart = dttost_n;

                    TimeSpan? span = scanerDrop - dateStart;
                    totalMinutes += span.Value.TotalMinutes < 0 ? 0 : (int)span.Value.TotalMinutes;
                }

                bool isException = false;
                decimal countDayAdd = 0;
                int isa = 0;
                if (rowCollect.Count() > 0)
                {
                    if (rowCollect.First()["id_exception"] != DBNull.Value)
                    {
                        countDayAdd = (decimal)rowCollect.First()["CountDays"];
                        isException = true;
                    }

                    isa = (int)rowCollect.First()["isa"];
                }

                //dicUserVsMinutes.Add(gKadr.id_kadr, totalMinutes);
                EnumerableRowCollection<DataRow> rowCollectMain = dtMainTable.AsEnumerable().Where(r => r.Field<object>("id_kadr")!=null && r.Field<int>("id_kadr") == gKadr.id_kadr);
                if (rowCollectMain.Count() > 0)
                {
                    rowCollectMain.First()["TimeWorked"] = totalMinutes;
                    rowCollectMain.First()["TimeWorked_to_Time"] = $"{totalMinutes / 60}:{totalMinutes % 60}";


                    DateTime tmpTime = new DateTime(1900, 1, 1).AddMinutes(totalMinutes);
                    EnumerableRowCollection<DataRow> rowMinutes = dtMinuteToDay.AsEnumerable().Where(r => r.Field<DateTime>("hourStart") <= tmpTime && tmpTime <= r.Field<DateTime>("hourEnd"));
                    if (rowMinutes.Count() > 0)
                        rowCollectMain.First()["CompensatoryTime"] = rowMinutes.First()["day"];
                    else
                    {
                        rowMinutes = dtMinuteToDay.AsEnumerable().Where(r => r.Field<DateTime>("hourEnd") <= tmpTime).OrderByDescending(r => r.Field<DateTime>("hourEnd"));
                        if (rowMinutes.Count() > 0)
                        {
                            rowCollectMain.First()["CompensatoryTime"] = rowMinutes.First()["day"];
                        }
                        else
                        {
                            rowCollectMain.First()["CompensatoryTime"] = 0;
                        }
                    }


                    if (isException)
                    {
                        if (isa == 0)
                        {
                            rowCollectMain.First()["CompensatoryTime"] = (decimal)rowCollectMain.First()["CompensatoryTime"] + countDayAdd;
                            if ((decimal)rowCollectMain.First()["CompensatoryTime"] > 2)
                                rowCollectMain.First()["CompensatoryTime"] = 2;
                        }
                        else
                            rowCollectMain.First()["CompensatoryTime"] = countDayAdd;
                    }
                }
            }

            MessageBox.Show("Расчёт завершён!","Расчёт отгулов",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btSaveTimeToHoliday_Click(object sender, EventArgs e)
        {

            Task<DataTable> task = readSQL.getInfoCalcCompensatoryTime((int)cbInventDate.SelectedValue);
            task.Wait();

            DialogResult dlgResult = DialogResult.Cancel;

            if (task.Result != null && task.Result.Rows.Count > 0 && (int)task.Result.Rows[0]["id"] == 1)
            {
                dlgResult = new MyMessageBox.MyMessageBox("В базе уже присутствуют ранее сохранёные результаты расчётов на сохраняемую дату основной инвентаризации.\n\nПерезаписать новыми результатами расчёта?", "Сохранение результатов расчёта отгулов",
                   MyMessageBox.MessageBoxButtons.YesNoCancel,
                   new List<string> { "Новыми", "Обновить", "Отмена" })
                {
                    ControlBox = false
                }.ShowDialog();
            }
            else dlgResult = DialogResult.Yes;

            if (dlgResult == DialogResult.Cancel) return;

            if (dlgResult == DialogResult.Yes)
            {
                setComTimeToBase(true);
                return;
            }
            else if (dlgResult == DialogResult.No)
            {
                setComTimeToBase(false);
                return;
            }
        }

        private void setComTimeToBase(bool isDeleteData)
        {
            if (isDeleteData) readSQL.setCalcCompensatoryTime((int)cbInventDate.SelectedValue, 0, 0, 0, true).Wait();

            EnumerableRowCollection<DataRow> rowCollect = dtMainTable.AsEnumerable()
                       .Where(r => r.Field<object>("TimeWorked") != null);

            foreach (DataRow row in rowCollect)
            {
                readSQL.setCalcCompensatoryTime((int)cbInventDate.SelectedValue, (int)row["id_kadr"], (int)row["TimeWorked"], (decimal)row["CompensatoryTime"], false).Wait();
            }

            MessageBox.Show("Данные сохранены!", "Сохранение отгулов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btReport.Enabled = true;
        }

        private void btDicExeption_Click(object sender, EventArgs e)
        {
            new CompensatoryTime.frmList() { FormBorderStyle = FormBorderStyle.FixedSingle }.ShowDialog();
        }

        private void btEditTime_Click(object sender, EventArgs e)
        {
            if (dgvPlane.CurrentRow == null) return;
            if (dgvPlane.CurrentRow.Index == -1) return;
            if (dgvScaners.Rows.Count == 0) return;

            int id_kadr = int.Parse(dtMainTable.DefaultView[dgvPlane.CurrentRow.Index]["id_Kadr"].ToString());
            int id_ttost = int.Parse(cbInventDate.SelectedValue.ToString());
            string FIO = (string)dtMainTable.DefaultView[dgvPlane.CurrentRow.Index]["fio"];
            int id_Shop = (int)dtMainTable.DefaultView[dgvPlane.CurrentRow.Index]["id_Shop"];

            frmEditTime frm = new frmEditTime((dgvScaners.DataSource as DataTable), id_kadr, id_ttost) { fio = FIO, id_Shop = id_Shop, dateInvent = DateTime.Parse(cbInventDate.Text) };
            if (DialogResult.OK == frm.ShowDialog())
                get_data();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            get_data();
        }

        private void btFindPlace_Click(object sender, EventArgs e)
        {
            get_data(tbNamePlace.Text.Trim());
        }

        Control usedControl = null;
        private void frmMainForm_MouseMove(object sender, MouseEventArgs e)
        {
            //foreach (Control cnt in this.Controls)
            //{
            //    if (cnt is Button && !cnt.Enabled)
            //    {
            //        if (cnt.Location.X <= e.Location.X && e.Location.X <= cnt.Location.X + cnt.Size.Width && (usedControl == null || !usedControl.Equals(cnt)))
            //        {
            //            usedControl = cnt;
            //            Console.WriteLine($"X:{e.Location.X},Y:{e.Location.Y}");                        
            //            string value = tp.GetToolTip(cnt);
            //            //tp.Show(value, this,2000);
            //            //tp.AutomaticDelay = 5;
            //            // (value, this);
            //            break;
            //        }                  
            //    }
            //}

        }

        private void btAddTime_Click(object sender, EventArgs e)
        {
            int id_kadr = -1;
            int id_ttost = int.Parse(cbInventDate.SelectedValue.ToString());

            DataTable dtSingleTable = readSQL.getSingleTableForScaner(id_kadr, id_ttost);


            frmEditTime frm = new frmEditTime(dtSingleTable, id_kadr, id_ttost) { dateInvent = DateTime.Parse(cbInventDate.Text) };
            if (DialogResult.OK == frm.ShowDialog())
                get_data();
        }
    }
}
