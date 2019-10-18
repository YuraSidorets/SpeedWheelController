using System.Collections.Generic;
using System.Diagnostics;

namespace SpeedWheelController
{
    public static class ProcessHandler
    {
        public static IEnumerable<Process> GetProcessesByName(string processName)
        {
            return Process.GetProcessesByName(processName);
        }
    }
}
