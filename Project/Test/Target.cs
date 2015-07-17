namespace Test
{
    static class Target
    {
        internal static string Path 
        {
#if DEBUG
            get { return System.IO.Path.GetFullPath("../../../TargetApp/bin/Debug/TargetApp.exe"); }
#else
            get { return System.IO.Path.GetFullPath("../../../TargetApp/bin/Release/TargetApp.exe"); }
#endif
        }
    }
}
