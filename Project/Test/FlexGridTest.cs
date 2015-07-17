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
        public void Test()
        {
        }
    }
}
