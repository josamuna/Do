using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionClinic_WIN
{
    public partial class Apropos : UserControl
    {
        public Apropos()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
