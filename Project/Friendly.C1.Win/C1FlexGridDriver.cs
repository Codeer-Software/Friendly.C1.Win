using System;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Friendly.C1.Win.Inside;
using System.Collections.Generic;

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


#if ENG
        /// <summary>
        /// Row of cursor.
        /// </summary>
#else
        /// <summary>
        /// カーソルを含む行。
        /// </summary>
#endif
        public int Row { get { return (int)AppVar["Row"]().Core; } }

#if ENG
        /// <summary>
        /// Col of cursor.
        /// </summary>
#else
        /// <summary>
        /// カーソルを含む列。
        /// </summary>
#endif        
        public int Col { get { return (int)AppVar["Col"]().Core; } }

#if ENG
        /// <summary>
        /// Last row of selection.
        /// </summary>
#else
        /// <summary>
        /// 現在の選択範囲の最後の行。
        /// </summary>
#endif
        public int RowSel { get { return (int)AppVar["RowSel"]().Core; } }
  
#if ENG
        /// <summary>
        /// Last col of selection.
        /// </summary>
#else
        /// <summary>
        /// 現在の選択範囲の最後の列。
        /// </summary>
#endif      
        public int ColSel { get { return (int)AppVar["ColSel"]().Core; } }

#if ENG
        /// <summary>
        /// Rows of selection.
        /// </summary>
#else
        /// <summary>
        /// 選択行。
        /// </summary>
#endif      
        public int[] SelectedRows { get { return (int[])AppVar.App[GetType(), "GetSelectedRows"](this).Core; } }

        static int[] GetSelectedRows(Control grid)
        {
            return GetSelectedCllection(grid, "get_Rows");
        }

#if ENG
        /// <summary>
        /// Cols of selection.
        /// </summary>
#else
        /// <summary>
        /// 選択列。
        /// </summary>
#endif    
        public int[] SelectedCols { get { return (int[])AppVar.App[GetType(), "GetSelectedCols"](this).Core; } }

        static int[] GetSelectedCols(Control grid)
        {
            return GetSelectedCllection(grid, "get_Cols");
        }

        static int[] GetSelectedCllection(Control grid, string getter)
        {
            var items = Invoker.Call(grid, getter);
            var count = (int)Invoker.Call(items, "get_Count");
            var l = new List<int>();
            for (int i = 0; i < count; i++)
            {
                var item = Invoker.Call(items, "get_Item", i);
                if ((bool)Invoker.Call(item, "get_Selected"))
                {
                    l.Add(i);
                }
            }
            return l.ToArray();
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

#if ENG
        /// <summary>
        /// Get cell's text.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
#else
        /// <summary>
        /// セルのテキストを取得します。
        /// </summary>
        /// <param name="row">アプリケーション内変数。</param>
        /// <param name="col">アプリケーション内変数。</param>
#endif
        public string GetCellText(int row, int col)
        {
            var cell = AppVar["[,]"](row, col);
            return cell.IsNull ? string.Empty : cell.ToString();
        }

        public string[][] GetCellTexts(int topRow, int bottomRow, int leftCol, int rightCol)
        {
            return (string[][])AppVar.App[GetType(), "GetCellTexts"](this, topRow, bottomRow, leftCol, rightCol).Core;
        }

        static string[][] GetCellTexts(Control grid, int topRow, int bottomRow, int leftCol, int rightCol)
        {
            var cols = Invoker.Call(grid, "get_Cols");
            var objs = GetCellObjects(grid, topRow, bottomRow, leftCol, rightCol);
            string[][] ret = new string[objs.Length][];
            for (int i = 0; i < objs.Length; i++) 
            {
                ret[i] = new string[objs[i].Length];
                for (int j = 0, col = leftCol; col <= rightCol; j++, col++)
                {
                    var obj = objs[i][j];
                    if (obj == null)
                    {
                        ret[i][j] = string.Empty;
                    }
                    else
                    {
                        var colsetting = Invoker.Call(cols, "get_Item", col);
                        var format = (string)Invoker.Call(colsetting, "get_Format");
                        if (string.IsNullOrEmpty(format))
                        {
                            ret[i][j] = obj.ToString();
                        }
                        else
                        {
                            var m = obj.GetType().GetMethod("ToString", new Type[] { typeof(string) });
                            if (m != null)
                            {
                                ret[i][j] = (string)m.Invoke(obj, new object[] { format });
                            }
                            else 
                            {
                                ret[i][j] = obj.ToString();
                            }
                        }
                    }
                    ret[i][j] = objs[i][j] == null ? string.Empty : objs[i][j].ToString();
                }
            }
            return ret;
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

        static object[][] GetCellObjects(Control grid, int topRow, int bottomRow, int leftCol, int rightCol)
        {
            object[][] ret = new object[bottomRow - topRow + 1][];
            for (int i = 0, row = topRow; row <= bottomRow; i++, row++)
            {
                ret[i] = new object[rightCol - leftCol + 1];
                for (int j = 0, col = leftCol; col <= rightCol; j++, col++)
                {
                    var obj = Invoker.Call(grid, "get_Item", row, col);
                    ret[i][j] = obj;
                }
            }
            return ret;
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

        static void EmulateSelect(Control grid, int row, int col, int rowSel, int colSel)
        {
            grid.Focus();
            Invoker.Call(grid, "Select", row, col, rowSel, colSel);
        }

        public void EmulateAddRowSelect(int row)
        {
            AppVar.App[GetType(), "EmulateAddRowSelect"](this, row);
        }

        public void EmulateAddRowSelect(int row, Async async)
        {
            AppVar.App[GetType(), "EmulateAddRowSelect", async](this, row);
        }

        static void EmulateAddRowSelect(Control grid, int row)
        {
            var items = Invoker.Call(grid, "get_Rows");
            var item = Invoker.Call(items, "get_Item", row);
            Invoker.Call(item, "set_Selected", true);
        }

        public void EmulateEditText(string text)
        {
            AppVar.App[GetType(), "EmulateEditText"](this, text);
        }

        public void EmulateEditText(string text, Async async)
        {
            AppVar.App[GetType(), "EmulateEditText", async](this, text);
        }

        static void EmulateEditText(Control grid, string text)
        {
            grid.Focus();
            Invoker.Call(grid, "StartEditing");
            var edit = (Control)Invoker.Call(grid, "get_Editor");
            edit.Focus();
            Invoker.Call(edit, "set_Text", text);
            Invoker.Call(grid, "FinishEditing");
        }

        public void EmulateEditCheck(bool check)
        {
            AppVar.App[GetType(), "EmulateEditCheck"](this, Row, Col, check);
        }

        public void EmulateEditCheck(bool check, Async async)
        {
            AppVar.App[GetType(), "EmulateEditCheck", async](this, Row, Col, check);
        }

        static void EmulateEditCheck(Control grid, int row, int col, bool check)
        {
            grid.Focus();
            while (true)
            {
                var data = Invoker.Call(grid, "get_Item", row, col);
                if (check == (data != null && (bool)data))
                {
                    break;
                }
                Invoker.Call(grid, "StartEditing");
                Invoker.Call(grid, "FinishEditing");
            }
        }

        public void EmulateEditCombo(int index)
        {
            AppVar.App[GetType(), "EmulateEditCombo"](this, index);
        }

        public void EmulateEditCombo(int index, Async async)
        {
            AppVar.App[GetType(), "EmulateEditCombo", async](this, index);
        }

        static void EmulateEditCombo(Control grid, int index)
        {
            grid.Focus();
            Invoker.Call(grid, "StartEditing");
            var edit = (Control)Invoker.Call(grid, "get_Editor");
            edit.Focus();
            Invoker.Call(edit, "set_SelectedIndex", index);
            Invoker.Call(grid, "FinishEditing");
        }
    }
}
