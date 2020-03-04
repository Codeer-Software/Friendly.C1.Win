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
            _grid.AfterEdit += _grid_AfterEdit;
            _grid.BeforeEdit += _grid_BeforeEdit;
            _grid.ValidateEdit += _grid_ValidateEdit;


        }


        private void _grid_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
        }

        private void _grid_BeforeEdit(object sender, RowColEventArgs e)
        {
        }

        private void _grid_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void _grid_AfterEdit(object sender, RowColEventArgs e)
        {
            var x1 = _grid.Cols[0].DataType;
            var x2 = _grid.Cols[1].DataType;
            var x3 = _grid.Cols[2].DataType;

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
