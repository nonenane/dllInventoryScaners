using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dllInventoryScaners
{
    public partial class frmAddNumberScaner : Form
    {
        private bool isAltF4 = false;
        public string numberScaner { set; get; }
        public frmAddNumberScaner()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            numberScaner = tbNumberScaner.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void frmAddNumberScaner_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isAltF4;
            isAltF4 = false;
        }

        private void frmAddNumberScaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F4)
            {
                isAltF4 = true;
            }
            else
                if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.S)
                {
                    if (btSave.Enabled)
                        btSave_Click(sender, e);
                }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbNumberScaner_TextChanged(object sender, EventArgs e)
        {
            btSave.Enabled = tbNumberScaner.Text.Trim().Length != 0;
        }
    }
}
