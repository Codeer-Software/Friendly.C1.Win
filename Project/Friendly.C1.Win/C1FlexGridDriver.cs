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
    }
}
