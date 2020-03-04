using C1.Win.C1FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TargetApp
{
    public partial class FlexGridForm : Form
    {
        public FlexGridForm()
        {
            InitializeComponent();

            //初期表示
            _grid[0, 0] = "/";
            _grid[0, 1] = "text";
            _grid[0, 2] = "combo";
            _grid[0, 3] = "check";
            _grid[0, 4] = "format";

            _grid[1, 0] = "1";
            _grid[1, 1] = "text-1";
            _grid[1, 2] = "a";
            _grid[1, 3] = true;
            _grid[1, 4] = 12345;

            _grid[2, 0] = "2";
            _grid[2, 1] = "text-2";
            _grid[2, 2] = "b";
            _grid[2, 3] = false;
            _grid[2, 4] = 6789;
        }

        void ConnectRowColChange()
        {
            _grid.RowColChange += delegate { MessageBox.Show(""); };
        }

        void ConnectSelChange()
        {

            _grid.SelChange += delegate { MessageBox.Show(""); };
        }

        void ConnectAfterEdit()
        {
            _grid.AfterEdit += delegate { MessageBox.Show(""); };
        }
    }
}
