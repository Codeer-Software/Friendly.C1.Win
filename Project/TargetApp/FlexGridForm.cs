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

            var ps = _grid.GetType().GetProperties();
            List<string> l = new List<string>();
            for (int i = 0; i < ps.Length; i++) 
            {
                l.Add(ps[i].Name);
            }
            var m = _grid.GetType().GetMethod("get_Item", new Type[] { typeof(int), typeof(int) });
            /*

            var m = this.GetType().GetMethod("set_Text",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                new Type[] { typeof(string) },
                new ParameterModifier[1]);
               // Invoke(this, new object[] { t0 });
            int dmuy = 0;*/
            
        }
    }
}
