using System;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;

namespace Friendly.C1.Win
{
#if ENG
    /// <summary>
    /// Provides operations on controls of type C1.Win.C1FlexGrid.C1FlexGrid.
    /// </summary>
#else
    /// <summary>
    /// TypeがC1.Win.C1FlexGrid.C1FlexGridに対応した操作を提供します。
    /// </summary>
#endif
    public class C1FlexGridDriver : IAppVarOwner
    {
#if ENG
        /// <summary>
        /// Returns an AppVar for a .NET object for the corresponding window.
        /// </summary>
#else
        /// <summary>
        /// 対応するウィンドウの.Netのオブジェクトが格納されたAppVarを取得します。
        /// </summary>
#endif
        public AppVar AppVar { get; set; }

        public int Row { get { return (int)AppVar["Row"]().Core; } }
        public int Col { get { return (int)AppVar["Col"]().Core; } }
        public int RowSel { get { return (int)AppVar["RowSel"]().Core; } }
        public int ColSel { get { return (int)AppVar["ColSel"]().Core; } }

        public int[] SelectedRows { get { return (int[])AppVar.App[GetType(), "GetSelectedRows"](this).Core; } }

        static int[] GetSelectedRows(object grid)
        {
            return new int[0];
        }


        public int[] SelectedCols { get { return (int[])AppVar.App[GetType(), "GetSelectedCols"](this).Core; } }

        static int[] GetSelectedCols(object grid)
        {
            return new int[0];
        }

#if ENG
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appVar">Application variable object for the control.</param>
#else
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="appVar">アプリケーション内変数。</param>
#endif
        public C1FlexGridDriver(AppVar appVar)
        {
            AppVar = appVar;
            WindowsAppExpander.LoadAssembly((WindowsAppFriend)AppVar.App, typeof(C1FlexGridDriver).Assembly);
        }

        public string GetCellText(int row, int col)
        {
            var cell = AppVar["[,]"](row, col);
            return cell.IsNull ? string.Empty : cell.ToString();
        }

        public string[] GetCellTexts(int topRow, int bottomRow, int leftCol, int rightCol)
        {
            return (string[])AppVar.App[GetType(), "GetCellTexts"](this, topRow, bottomRow, leftCol, rightCol).Core;
        }

        static string[] GetCellTexts(object grid, int topRow, int bottomRow, int leftCol, int rightCol)
        {
            throw new NotImplementedException();
        }

        public object GetCellObject(int row, int col)
        {
            var cell = AppVar["[,]"](row, col);
            return cell.Core;
        }

        public object[] GetCellObjects(int topRow, int bottomRow, int leftCol, int rightCol)
        {
            return (string[])AppVar.App[GetType(), "GetCellObjects"](this, topRow, bottomRow, leftCol, rightCol).Core;
        }

        static object[] GetCellObjects(object grid, int topRow, int bottomRow, int leftCol, int rightCol)
        {
            throw new NotImplementedException();
        }

        public void EmulateSelect(int row, int col)
        {
            AppVar.App[GetType(), "EmulateSelect"](this, row, col, row, col);
        }

        public void EmulateSelect(int row, int col, Async async)
        {
            AppVar.App[GetType(), "EmulateSelect", async](this, row, col, row, col);
        }

        public void EmulateSelect(int row, int col, int rowSel, int colSel)
        {
            AppVar.App[GetType(), "EmulateSelect"](this, row, col, rowSel, colSel);
        }

        public void EmulateSelect(int row, int col, int rowSel, int colSel, Async async)
        {
            AppVar.App[GetType(), "EmulateSelect", async](this, row, col, rowSel, colSel);
        }

        static void EmulateSelect(object grid, int row, int col, int rowSel, int colSel)
        {
            throw new NotImplementedException();
        }

        public void EmulateAddRowSelect(int row)
        {
            AppVar.App[GetType(), "EmulateAddRowSelect"](this, row);
        }

        public void EmulateAddRowSelect(int row, Async async)
        {
            AppVar.App[GetType(), "EmulateAddRowSelect", async](this, row);
        }

        static void EmulateAddRowSelect(object grid, int row)
        {
            throw new NotImplementedException();
        }

        public void EmulateEditText(string text)
        {
            AppVar.App[GetType(), "EmulateEditText"](this, text);
        }

        public void EmulateEditText(string text, Async async)
        {
            AppVar.App[GetType(), "EmulateEditText", async](this, text);
        }

        static void EmulateEditText(object grid, string text)
        {
            throw new NotImplementedException();
        }

        public void EmulateEditCheck(bool check)
        {
            AppVar.App[GetType(), "EmulateEditCheck"](this, check);
        }

        public void EmulateEditCheck(bool check, Async async)
        {
            AppVar.App[GetType(), "EmulateEditCheck", async](this, check);
        }

        static void EmulateEditCheck(object grid, bool check)
        {
            throw new NotImplementedException();
        }

        public void EmulateEditCombo(int index)
        {
            AppVar.App[GetType(), "EmulateEditCombo"](this, index);
        }

        public void EmulateEditCombo(int index, Async async)
        {
            AppVar.App[GetType(), "EmulateEditCombo", async](this, index);
        }

        static void EmulateEditCombo(object grid, int index)
        {
            throw new NotImplementedException();
        }
    }
}
