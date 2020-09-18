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
    public partial class frmEditPlace : Form
    {
        public DataRowView row { get; set; }
        private bool isEdit = false;
        public frmEditPlace()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmEditPlace_Load(object sender, EventArgs e)
        {
            init_combobox_deps();
            tbNameDeps.Text = row["InvDeps"].ToString();
            tbNamePlace.Text = row["place"].ToString();
            if (row["id_departments"]!=DBNull.Value)
            {
                cbDeps.SelectedValue = row["id_departments"].ToString();
                if (cbDeps.SelectedIndex != -1)
                {
                    init_combobox_people(int.Parse(cbDeps.SelectedValue.ToString()));
                    cbPeople.SelectedValue = row["id_Kadr"].ToString();
                    isEdit = cbPeople.SelectedValue != null;
                }
            }
            dtpStart.Value = DateTime.Parse(row["TimeStartPlan"].ToString());
            dtpEnd.Value = DateTime.Parse(row["TimeEndPlan"].ToString());
        }
        
        private void init_combobox_deps()
        {
            DataTable dtDeps = readSQL.getDepsForScaner();
            cbDeps.DataSource = dtDeps;
            cbDeps.DisplayMember = "name";
            cbDeps.ValueMember = "id";
            cbDeps.SelectedIndex = -1;
        }
       
        private void init_combobox_people(int id_deps)
        {
            cbPeople.Enabled = true;
            DataTable dtPeople= readSQL.getPeopleForScaner(id_deps);
            cbPeople.DataSource = dtPeople;
            cbPeople.DisplayMember = "FIO";
            cbPeople.ValueMember = "id";
            cbPeople.SelectedIndex = -1;
        }

        private void cbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cbPeople.Enabled = true;
            init_combobox_people(int.Parse(cbDeps.SelectedValue.ToString()));
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (cbDeps.SelectedIndex == -1)
            {
                return;
            }
            else
                if (cbPeople.SelectedIndex == -1)
                {
                    return;
                }

            String timeStart = dtpStart.Value.ToLongTimeString();
            String timeEnd = dtpEnd.Value.ToLongTimeString();
            int id_kadr = int.Parse(cbPeople.SelectedValue.ToString());
            int id_ttost = int.Parse(row["id_DateRemains"].ToString());
            int id_place = int.Parse(row["id"].ToString());
            DataTable dtResult = readSQL.setPlaneForScaner(id_place, id_ttost, id_kadr, timeStart, timeEnd);
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                if (dtResult.Rows[0]["id"].ToString().Equals("-1"))
                {
                    MessageBox.Show("Добавление сотрудника на это место невозможно!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Logging.StartFirstLevel(117);
            Logging.Comment("Начало " + (isEdit ? "редактирования" : "добавления") + " сотрудника");
            Logging.Comment("Id места инвентаризации = " + row["id"].ToString() + ", название места инв-ции = " + tbNamePlace.Text);
            Logging.Comment("Название отдела инв-ции = " + tbNameDeps.Text);
            if (isEdit)
            {
                Logging.VariableChange("Id отдела сотрудника", cbDeps.SelectedValue.ToString(), row["id_departments"].ToString());
                Logging.VariableChange("Название отдела сотрудника", cbDeps.Text.Trim(), row["nameDeps"].ToString());
                Logging.VariableChange("Id сотрудника", cbPeople.SelectedValue.ToString(), row["id_Kadr"].ToString());
                Logging.VariableChange("ФИО сотрудника", cbPeople.Text.Trim(), row["FIO"].ToString());
                Logging.VariableChange("Время начала подсчёта", dtpStart.Value.ToShortTimeString(), DateTime.Parse(row["TimeStartPlan"].ToString()).ToShortTimeString());
                Logging.VariableChange("Время окончания подсчёта", dtpEnd.Value.ToShortTimeString(), DateTime.Parse(row["TimeEndPlan"].ToString()).ToShortTimeString());
            }
            else
            {
                Logging.Comment("Id отдела сотрудника = " + cbDeps.SelectedValue.ToString() + ", название отдела сотрудника = " + cbDeps.Text.Trim());
                Logging.Comment("Id сотрудника = " + cbPeople.SelectedValue.ToString() + ", ФИО сотрудника = " + cbPeople.Text.Trim());
                Logging.Comment("Время начала подсчёта = " + dtpStart.Value.ToShortTimeString() + ", время окончания подсчёта = " + dtpEnd.Value.ToShortTimeString());
            }
            Logging.Comment("Конец " + (isEdit ? "редактирования" : "добавления") + " сотрудника");
            Logging.StopFirstLevel();

            MessageBox.Show("Данные сохранены!", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }
}
