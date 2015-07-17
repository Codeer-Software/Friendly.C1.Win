using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TargetApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonFlexGridClick(object sender, EventArgs e)
        {
            using (var dlg = new FlexGridForm()) 
            {
                dlg.ShowDialog(this);
            }
        }
    }
}
