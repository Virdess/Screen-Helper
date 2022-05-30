using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace RoboMate.Controller.Components
{
    [Component("Ram")]
    public class RamComponent : ComponentBase
    {
        private int counter;
        private float totalRam;
        public override void InitComponent()
        {
            counter = 0;
            base.InitComponent();
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

        public override void ResumeComponent()
        {
            long memKb;
            GetPhysicallyInstalledSystemMemory(out memKb);
            totalRam = memKb / 1024;
            base.ResumeComponent();
        }

        public override void RunComponent()
        {
            var availableRam = new PerformanceCounter("Memory", "Available MBytes", null).RawValue;
            Debug.WriteLine(availableRam);
            Debug.WriteLine(totalRam);
            Debug.WriteLine(100 - (availableRam / totalRam * 100));
            //Debug.WriteLine(mate.IsRam);
            if (100 - (availableRam / totalRam * 100) > configurations.RamThreshold && counter < 25)
                counter++;
            else
                counter = Math.Max(0, --counter);
            mate.IsRam = counter > 20;
            Debug.WriteLine($"Ram: {mate.IsRam}");
            if (mate.IsRam && !mate.IsIdle)
                mate.CurrentSpriteRow = mate.IsProcessor ? 6 : 4;
            
        }

        public override void SuspendComponent()
        {
            base.SuspendComponent();
            counter = 0;
            mate.IsRam = false;
        }
    }
}
