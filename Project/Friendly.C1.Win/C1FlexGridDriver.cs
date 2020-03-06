using System;
using System.Windows.Forms;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Friendly.C1.Win.Inside;
using System.Collections.Generic;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Drawing;

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
    [ControlDriver(TypeFullName = "C1.Win.C1FlexGrid.C1FlexGrid")]
    public class C1FlexGridDriver : WindowControl
    {
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
        /// Row count.
        /// </summary>
#else
        /// <summary>
        /// 行数
        /// </summary>
#endif
        public int RowCount { get { return (int)AppVar["Rows"]()["Count"]().Core; } }

#if ENG
        /// <summary>
        /// Col count.
        /// </summary>
#else
        /// <summary>
        /// 列数
        /// </summary>
#endif
        public int ColCount { get { return (int)AppVar["Cols"]()["Count"]().Core; } }

#if ENG
        /// <summary>
        /// Fixed row count.
        /// </summary>
#else
        /// <summary>
        /// 固定行数
        /// </summary>
#endif
        public int FixedRowCount { get { return (int)AppVar["Rows"]()["Fixed"]().Core; } }

#if ENG
        /// <summary>
        /// Fixed col count.
        /// </summary>
#else
        /// <summary>
        /// 固定列数
        /// </summary>
#endif
        public int FixedColCount { get { return (int)AppVar["Cols"]()["Fixed"]().Core; } }
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
        /// Get cell rectangle
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Col</param>
        /// <returns>Cell rectangle</returns>
#else
        /// <summary>
        /// セル矩形取得
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns>セル矩形</returns>
#endif
        public Rectangle GetCellRect(int row, int col)
            => (Rectangle)AppVar["GetCellRect"](row, col).Core;

#if ENG
        /// <summary>
        /// Get cell
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Col</param>
        /// <returns>Cell</returns>
#else
        /// <summary>
        /// セル取得
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <returns>セル</returns>
#endif
        public CellDriver GetCell(int row, int col) => new CellDriver(this, row, col);

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
            var items = Invoker.Call(grid, "get_Rows");
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
        public C1FlexGridDriver(AppVar appVar) : base(appVar)
        {
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
        /// <param name="row">行。</param>
        /// <param name="col">列。</param>
#endif
        public string GetCellText(int row, int col)
        {
            var cell = AppVar["[,]"](row, col);
            return cell.IsNull ? string.Empty : cell.ToString();
        }

#if ENG
        /// <summary>
        /// Get cell's texts.
        /// </summary>
        /// <param name="topRow">Top row.</param>
        /// <param name="bottomRow">Bottom row.</param>
        /// <param name="leftCol">Left col.</param>
        /// <param name="rightCol">Right col.</param>
#else
        /// <summary>
        /// セルのテキストを取得します。
        /// </summary>
        /// <param name="topRow">上行。</param>
        /// <param name="bottomRow">下列。</param>
        /// <param name="leftCol">左行。</param>
        /// <param name="rightCol">右列。</param>
#endif
        public string[][] GetCellTexts(int topRow, int leftCol, int bottomRow, int rightCol)
        {
            return (string[][])AppVar.App[GetType(), "GetCellTexts"](this, topRow, leftCol, bottomRow, rightCol).Core;
        }

        static string[][] GetCellTexts(Control grid, int topRow, int leftCol, int bottomRow, int rightCol)
        {
            var cols = Invoker.Call(grid, "get_Cols");
            var objs = GetCellObjects(grid, topRow, leftCol, bottomRow, rightCol);
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
                }
            }
            return ret;
        }

#if ENG
        /// <summary>
        /// Get cell's object.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
#else
        /// <summary>
        /// セルのオブジェクトを取得します。
        /// </summary>
        /// <param name="row">行。</param>
        /// <param name="col">列。</param>
#endif
        public object GetCellObject(int row, int col)
        {
            var cell = AppVar["[,]"](row, col);
            return cell.Core;
        }

#if ENG
        /// <summary>
        /// Get cell's objects.
        /// </summary>
        /// <param name="topRow">Top row.</param>
        /// <param name="bottomRow">Bottom row.</param>
        /// <param name="leftCol">Left col.</param>
        /// <param name="rightCol">Right col.</param>
#else
        /// <summary>
        /// セルのオブジェクトを取得します。
        /// </summary>
        /// <param name="topRow">上行。</param>
        /// <param name="bottomRow">下列。</param>
        /// <param name="leftCol">左行。</param>
        /// <param name="rightCol">右列。</param>
#endif
        public object[][] GetCellObjects(int topRow, int leftCol, int bottomRow, int rightCol)
        {
            return (object[][])AppVar.App[GetType(), "GetCellObjects"](this, topRow, leftCol, bottomRow, rightCol).Core;
        }

        static object[][] GetCellObjects(Control grid, int topRow, int leftCol, int bottomRow, int rightCol)
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

#if ENG
        /// <summary>
        /// Select cell.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
#else
        /// <summary>
        /// 指定のセルを選択します。
        /// </summary>
        /// <param name="row">行。</param>
        /// <param name="col">列。</param>
#endif
        public void EmulateSelect(int row, int col)
        {
            AppVar.App[GetType(), "EmulateSelect"](this, row, col, row, col);
        }

#if ENG
        /// <summary>
        /// Select cell.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定のセルを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="row">行。</param>
        /// <param name="col">列。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateSelect(int row, int col, Async async)
        {
            AppVar.App[GetType(), "EmulateSelect", async](this, row, col, row, col);
        }

#if ENG
        /// <summary>
        /// Select cell.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        /// <param name="rowSel">Last row of selection.</param>
        /// <param name="colSel">Last col of selection.</param>
#else
        /// <summary>
        /// 指定のセルを選択します。
        /// </summary>
        /// <param name="row">選択行。</param>
        /// <param name="col">選択列。</param>
        /// <param name="rowSel">現在の選択範囲の最後の行。</param>
        /// <param name="colSel">現在の選択範囲の最後の列。</param>
#endif
        public void EmulateSelect(int row, int col, int rowSel, int colSel)
        {
            AppVar.App[GetType(), "EmulateSelect"](this, row, col, rowSel, colSel);
        }

#if ENG
        /// <summary>
        /// Select cell.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        /// <param name="rowSel">Last row of selection.</param>
        /// <param name="colSel">Last col of selection.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 指定のセルを選択します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="row">選択行。</param>
        /// <param name="col">選択列。</param>
        /// <param name="rowSel">現在の選択範囲の最後の行。</param>
        /// <param name="colSel">現在の選択範囲の最後の列。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateSelect(int row, int col, int rowSel, int colSel, Async async)
        {
            AppVar.App[GetType(), "EmulateSelect", async](this, row, col, rowSel, colSel);
        }


        static void EmulateSelect(Control grid, int row, int col, int rowSel, int colSel)
        {
            grid.Focus();
            Invoker.Call(grid, "Select", row, col, rowSel, colSel);
        }

#if ENG
        /// <summary>
        /// Add selected row.
        /// </summary>
        /// <param name="row">Row.</param>
#else
        /// <summary>
        /// 選択行を追加します。
        /// </summary>
        /// <param name="row">行。</param>
#endif
        public void EmulateAddSelectedRow(int row)
        {
            AppVar.App[GetType(), "EmulateAddSelectedRow"](this, row);
        }

#if ENG
        /// <summary>
        /// Add selected row.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// 選択行を追加します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="row">行。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
        public void EmulateAddSelectedRow(int row, Async async)
        {
            AppVar.App[GetType(), "EmulateAddSelectedRow", async](this, row);
        }

        static void EmulateAddSelectedRow(Control grid, int row)
        {
            var items = Invoker.Call(grid, "get_Rows");
            var item = Invoker.Call(items, "get_Item", row);
            Invoker.Call(item, "set_Selected", true);
        }

#if ENG
        /// <summary>
        /// Edit cell's text.
        /// </summary>
        /// <param name="text">Text.</param>
#else
        /// <summary>
        /// セルのテキストを編集します。
        /// </summary>
        /// <param name="text">テキスト。</param>
#endif
        public void EmulateEditText(string text)
        {
            AppVar.App[GetType(), "EmulateEditText"](this, text);
        }

#if ENG
        /// <summary>
        /// Edit cell's text.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// セルのテキストを編集します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="text">テキスト。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
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

#if ENG
        /// <summary>
        /// Edit cell's check.
        /// </summary>
        /// <param name="check">Check.</param>
#else
        /// <summary>
        /// セルのチェック状態を編集します。
        /// </summary>
        /// <param name="check">チェック状態。</param>
#endif
        public void EmulateEditCheck(bool check)
        {
            AppVar.App[GetType(), "EmulateEditCheck"](this, Row, Col, check);
        }

#if ENG
        /// <summary>
        /// Edit cell's check.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="check">Check.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// セルのチェック状態を編集します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="check">チェック状態。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif
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

#if ENG
        /// <summary>
        /// Edit cell's combobox index.
        /// </summary>
        /// <param name="index">Index.</param>
#else
        /// <summary>
        /// セルのコンボボックスの選択インデックスを編集します。
        /// </summary>
        /// <param name="index">選択インデックス。</param>
#endif 
        public void EmulateEditCombo(int index)
        {
            AppVar.App[GetType(), "EmulateEditCombo"](this, index);
        }

#if ENG
        /// <summary>
        /// Edit cell's combobox index.
        /// Executes asynchronously. 
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="async">Asynchronous execution.</param>
#else
        /// <summary>
        /// セルのコンボボックスの選択インデックスを編集します。
        /// 非同期で実行します。
        /// </summary>
        /// <param name="index">選択インデックス。</param>
        /// <param name="async">非同期実行オブジェクト。</param>
#endif 
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
