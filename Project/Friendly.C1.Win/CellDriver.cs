using System.Drawing;
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;

namespace Friendly.C1.Win
{
#if ENG
    /// <summary>
    /// Provides operations on controls of Cell.
    /// </summary>
#else
    /// <summary>
    /// Cellに対応した操作を提供します。
    /// </summary>
#endif
    public class CellDriver : IUIObject
    {
        C1FlexGridDriver _grid;

#if ENG
        /// <summary>
        /// Row.
        /// </summary>
#else
        /// <summary>
        /// 行。
        /// </summary>
#endif
        public int Row { get; }

#if ENG
        /// <summary>
        /// Col.
        /// </summary>
#else
        /// <summary>
        /// 列。
        /// </summary>
#endif
        public int Col { get; }
#if ENG
        /// <summary>
        /// Text.
        /// </summary>
#else
        /// <summary>
        /// セル内の書式付きテキスト。
        /// </summary>
#endif
        public string Text => _grid.GetCellText(Row, Col);

#if ENG
        /// <summary>
        /// Returns the associated application manipulation object.
        /// </summary>
#else
        /// <summary>
        /// アプリケーション操作クラスを取得します。
        /// </summary>
#endif
        public WindowsAppFriend App => _grid.App;

#if ENG
        /// <summary>
        /// Returns the size of IUIObject.
        /// </summary>
#else
        /// <summary>
        /// IUIObjectのサイズを取得します。
        /// </summary>
#endif
        public Size Size => GetRectangle().Size;

#if ENG
        /// <summary>
        /// Convert IUIObject's client coordinates to screen coordinates.
        /// </summary>
        /// <param name="clientPoint">client coordinates.</param>
        /// <returns>screen coordinates.</returns>
#else
        /// <summary>
        /// IUIObjectのクライアント座標からスクリーン座標に変換します。
        /// </summary>
        /// <param name="clientPoint">クライアント座標</param>
        /// <returns>スクリーン座標</returns>
#endif
        public Point PointToScreen(Point clientPoint)
        {
            var location = GetRectangle().Location;
            clientPoint.Offset(location.X, location.Y);
            return _grid.PointToScreen(clientPoint);
        }

#if ENG
        /// <summary>
        /// Make it active.
        /// </summary>
#else
        /// <summary>
        /// アクティブな状態にします。
        /// </summary>
#endif
        public void Activate() => _grid.Activate();

        internal CellDriver(C1FlexGridDriver grid, int row, int col)
        {
            _grid = grid;
            Row = row;
            Col = col;
        }

#if ENG
        /// <summary>
        /// Get cell rectangle
        /// </summary>
        /// <returns>Cell rectangle</returns>
#else
        /// <summary>
        /// セル矩形取得
        /// </summary>
        /// <returns>セル矩形</returns>
#endif
        Rectangle GetRectangle()
            => _grid.GetCellRect(Row, Col);
    }
}
