using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Tier
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
            Form f = new Form();
            f.MdiParent = this;
            f.Show();
           
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            timer1.Enabled = false;
        }
    }
}
