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
    public partial class frmReport : Form
    {
        private DataTable dtDeps;
        private int id_ttost;
        public frmReport(int id_ttost)
        {
            this.id_ttost = id_ttost;
            InitializeComponent();
            init_combobox_deps();
            inti_combobobox();
        }
        
        private void init_combobox_deps()
        {
            dtDeps = readSQL.getDepsForScaner();
            cbDeps.DataSource = dtDeps;
            cbDeps.DisplayMember = "name";
            cbDeps.ValueMember = "id";
           // cbDeps.SelectedIndex = -1;
        }

        private void inti_combobobox()
        {
            DataTable dtInventDate = readSQL.getDttostForScaner();
            cbInventDate.DataSource = dtInventDate;
            cbInventDate.DisplayMember = "dttost";
            cbInventDate.ValueMember = "id";

            cbInventDate.SelectedValue = id_ttost;
            cbInventDate.Enabled = false;
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            int id_ttost = int.Parse(cbInventDate.SelectedValue.ToString());
            int id_deps = int.Parse(cbDeps.SelectedValue.ToString());
            DataTable dtReport = readSQL.getReportFreeDaysForScaner(id_ttost, id_deps);
            if (dtReport == null || dtReport.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для выгрузки отчёта!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                create_report(dtReport);
                LogPrint();
            }
        }

        private void LogPrint()
        {
            Logging.StartFirstLevel(79);
            Logging.Comment("Начало печати отчёта");
            Logging.Comment("Id инвентаризации = " + cbInventDate.SelectedValue.ToString() + ", дата инвентаризации = " + cbInventDate.Text);
            Logging.Comment("Id отдела = " + cbDeps.SelectedValue.ToString() + ", название отдела = " + cbDeps.Text);
            Logging.Comment("Конец печати отчёта");
            Logging.StopFirstLevel();
        }

        private void create_report(DataTable dtReport)
        {

            var result = from tab in dtReport.AsEnumerable()
                         group tab by tab["id_deps"]
                             into groupDt
                             select new
                             {
                                 deps = groupDt.Key,                               
                             };

           

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();
            int indexRow = 1;
            report.Merge(indexRow, 1, indexRow, 3);
            report.AddSingleValue("Отчёт по отгулам сотрудников офиса", indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 3);
            report.AddSingleValue("Дата инвентаризации: " + cbInventDate.Text, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 3);
            report.AddSingleValue("Отдел: "+cbDeps.Text.Trim(), indexRow, 1);
            indexRow++;
            indexRow++;


            foreach (var rDeps in result)
            {
                DataRow[] rowDep = dtDeps.Select("id  = " + rDeps.deps);

                report.Merge(indexRow, 1, indexRow, 3);
                if (rowDep.Count()>0)
                    report.AddSingleValue(rowDep[0]["name"].ToString().Trim(), indexRow, 1);

                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 3);
                report.SetFontBold(indexRow, 1, indexRow, 3);
                report.SetBorders(indexRow, 1, indexRow, 3);
                indexRow++;

                dtReport.DefaultView.RowFilter = string.Format("id_deps = {0}", rDeps.deps);

                report.AddSingleValue("ФИО сотрудника", indexRow, 1);
                report.AddSingleValue("Количество отработанных часов", indexRow, 2);
                report.AddSingleValue("Количество отгулов", indexRow, 3);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 3);
                report.SetBorders(indexRow, 1, indexRow, 3);
                indexRow++;

                foreach (DataRowView r in dtReport.DefaultView)
                {
                    report.AddSingleValue(r["FIO"].ToString(), indexRow, 1);
                    report.AddSingleValue(r["timeWork"].ToString(), indexRow, 2);
                    report.AddSingleValue(r["countFreeDay"].ToString(), indexRow, 3);
                    report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 3);
                    report.SetBorders(indexRow, 1, indexRow, 3);
                    indexRow++;
                }

                indexRow++;
            }
            report.SetColumnAutoSize(1, 1, indexRow, 3);
            report.Show();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
