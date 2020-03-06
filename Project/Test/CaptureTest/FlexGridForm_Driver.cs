using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Friendly.C1.Win;

namespace Test.CaptureTest
{
    [WindowDriver(TypeFullName = "TargetApp.FlexGridForm")]
    public class FlexGridForm_Driver
    {
        public WindowControl Core { get; }
        public C1FlexGridDriver _grid => Core.Dynamic()._grid;

        public FlexGridForm_Driver(WindowControl core)
        {
            Core = core;
        }

        public FlexGridForm_Driver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class FlexGridForm_Driver_Extensions
    {
        [WindowDriverIdentify(TypeFullName = "TargetApp.FlexGridForm")]
        public static FlexGridForm_Driver Attach_FlexGridForm(this WindowsAppFriend app)
            => new FlexGridForm_Driver(app.WaitForIdentifyFromTypeFullName("TargetApp.FlexGridForm"));
    }
}