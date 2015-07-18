using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.Windows;
using Codeer.Friendly.Windows.Grasp;
using Friendly.C1.Win;
using Codeer.Friendly.Windows.NativeStandardControls;
using Ong.Friendly.FormsStandardControls;

namespace Test
{
    [TestClass]
    public class FlexGridTest
    {
        WindowsAppFriend _app;
        WindowControl _dlg;
        C1FlexGridDriver _grid;

        [TestInitialize]
        public void TestInitialize()
        {
            _app = new WindowsAppFriend(Process.Start(Target.Path));
            var main = WindowControl.FromZTop(_app);
            var a = new Async();

            new FormsButton(main.Dynamic()._buttonFlexGrid).EmulateClick(a);
            _dlg = main.WaitForNextModal();
            _grid = new C1FlexGridDriver(_dlg.Dynamic()._grid);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Process.GetProcessById(_app.ProcessId).Kill();
        }

        [TestMethod]
        public void TestSelect()
        {
            _grid.EmulateSelect(1, 2);
            _grid.Row.Is(1);
            _grid.Col.Is(2);
            _grid.RowSel.Is(1);
            _grid.ColSel.Is(2);
        }

        [TestMethod]
        public void TestGetTexts()
        {
            _grid.EmulateSelect(1, 1);
            _grid.EmulateEditText("1");
            _grid.EmulateSelect(1, 2);
            _grid.EmulateEditCheck(true);
            _grid.EmulateEditCheck(false);
            _grid.EmulateSelect(2, 2);
            _grid.EmulateEditCheck(true);
            var ret = _grid.GetCellTexts(1, 2, 1, 2);
            ret.Length.Is(2);
            ret[0].Length.Is(2);
            ret[0][0].Is("1");
            ret[0][1].Is(false.ToString());
            ret[1][0].Is(string.Empty);
            ret[1][1].Is(true.ToString());

            _grid.EmulateSelect(1, 3);
            _grid.EmulateEditCombo(2);
        }

        [TestMethod]
        public void XXX() 
        {
            _grid.Dynamic().SelectionMode = _app.Type().C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            _grid.EmulateAddRowSelect(1);
            _grid.EmulateAddRowSelect(3);
            _grid.EmulateAddRowSelect(5);
        }
    }
}
