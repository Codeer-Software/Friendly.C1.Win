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
        public void TestCount()
        {
            _grid.RowCount.Is(50);
            _grid.ColCount.Is(5);
            _grid.FixedRowCount.Is(1);
            _grid.FixedColCount.Is(1);
        }

        [TestMethod]
        public void TestSelectCell()
        {
            _grid.EmulateSelect(1, 2);
            _grid.Row.Is(1);
            _grid.Col.Is(2);
            _grid.RowSel.Is(1);
            _grid.ColSel.Is(2);
        }

        [TestMethod]
        public void TestSelectCellAsync()
        {
            _dlg.Dynamic().ConnectRowColChange();
            _grid.EmulateSelect(1, 2, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _grid.Row.Is(1);
            _grid.Col.Is(2);
            _grid.RowSel.Is(1);
            _grid.ColSel.Is(2);
        }

        [TestMethod]
        public void TestSelectCells()
        {
            _grid.EmulateSelect(1, 2, 5, 3);
            _grid.Row.Is(1);
            _grid.Col.Is(2);
            _grid.RowSel.Is(5);
            _grid.ColSel.Is(3);
        }

        [TestMethod]
        public void TestSelectCellsAsync()
        {
            _dlg.Dynamic().ConnectRowColChange();
            _grid.EmulateSelect(1, 2, 5, 3, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _grid.Row.Is(1);
            _grid.Col.Is(2);
            _grid.RowSel.Is(5);
            _grid.ColSel.Is(3);
        }

        [TestMethod]
        public void TestAddRow()
        {
            _grid.Dynamic().SelectionMode = _app.Type().C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            _grid.EmulateAddSelectedRow(1);
            _grid.EmulateAddSelectedRow(3);
            _grid.EmulateAddSelectedRow(5);
            var selectedRow = _grid.SelectedRows;
            selectedRow.Length.Is(3);
            selectedRow[0].Is(1);
            selectedRow[1].Is(3);
            selectedRow[2].Is(5);
        }

        [TestMethod]
        public void TestAddRowAsync()
        {
            _grid.Dynamic().SelectionMode = _app.Type().C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;
            _dlg.Dynamic().ConnectSelChange();
            _grid.EmulateAddSelectedRow(2, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            var selectedRow = _grid.SelectedRows;
            selectedRow.Length.Is(2);
            selectedRow[0].Is(1);
            selectedRow[1].Is(2);
        }

        [TestMethod]
        public void TestGetObjects()
        {
            var ret = _grid.GetCellObjects(0, 0, 2, 4);

            ret.Length.Is(3);
            ret[0].Length.Is(5);
            ret[0][0].Is("/");
            ret[0][1].Is("text");
            ret[0][2].Is("combo");
            ret[0][3].Is("check");
            ret[0][4].Is("format");

            ret[1][0].Is("1");
            ret[1][1].Is("text-1");
            ret[1][2].Is("a");
            ret[1][3].Is(true);
            ret[1][4].Is(12345);

            ret[2][0].Is("2");
            ret[2][1].Is("text-2");
            ret[2][2].Is("b");
            ret[2][3].Is(false);
            ret[2][4].Is(6789);

            _grid.GetCellObject(1, 2).Is("a");
        }

        [TestMethod]
        public void TestGetTexts()
        {
            var ret = _grid.GetCellTexts(0, 0, 2, 4);

            ret.Length.Is(3);
            ret[0].Length.Is(5);
            ret[0][0].Is("/");
            ret[0][1].Is("text");
            ret[0][2].Is("combo");
            ret[0][3].Is("check");
            ret[0][4].Is("format");

            ret[1][0].Is("1");
            ret[1][1].Is("text-1");
            ret[1][2].Is("a");
            ret[1][3].Is("True");
            ret[1][4].Is("12,345");

            ret[2][0].Is("2");
            ret[2][1].Is("text-2");
            ret[2][2].Is("b");
            ret[2][3].Is("False");
            ret[2][4].Is("6,789");

            _grid.GetCellText(1, 2).Is("a");
        }

        [TestMethod]
        public void TestEditText()
        {
            _grid.EmulateSelect(1, 1);
            _grid.EmulateEditText("1-1");
            _grid.GetCellText(1, 1).Is("1-1");
        }

        [TestMethod]
        public void TestEditTextAsync()
        {
            _dlg.Dynamic().ConnectAfterEdit();
            _grid.EmulateSelect(1, 1);
            _grid.EmulateEditText("1-1", new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _grid.GetCellText(1, 1).Is("1-1");
        }

        [TestMethod]
        public void TestEditCombo()
        {
            _grid.EmulateSelect(1, 2);
            _grid.EmulateEditText("b");
            _grid.GetCellText(1, 2).Is("b");

            _grid.EmulateSelect(2, 2);
            _grid.EmulateEditCombo(2);
            _grid.GetCellText(2, 2).Is("c");
        }

        [TestMethod]
        public void TestEditComboAsync()
        {
            _dlg.Dynamic().ConnectAfterEdit();
            _grid.EmulateSelect(2, 2);
            _grid.EmulateEditCombo(2, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _grid.GetCellText(2, 2).Is("c");
        }

        [TestMethod]
        public void TestEditCheck()
        {
            _grid.EmulateSelect(1, 3);
            _grid.EmulateEditCheck(false);
            _grid.GetCellObject(1, 3).Is(false);
        }

        [TestMethod]
        public void TestEditCheckAsync()
        {
            _dlg.Dynamic().ConnectAfterEdit();
            _grid.EmulateSelect(1, 3);
            _grid.EmulateEditCheck(false, new Async());
            new NativeMessageBox(_dlg.WaitForNextModal()).EmulateButtonClick("OK");
            _grid.GetCellObject(1, 3).Is(false);
        }
    }
}
